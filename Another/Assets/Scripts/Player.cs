using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Plantilla del proyectil
    public Projectile laserPrefab;

    public float speed = 5.0f;

    private bool _laserActive;

    public int life = 3;

    public Canvas PauseMenu;

    //Cuando se empieza se pone que el menú de pausa no esté habilitado, principalmente 
    //para evitar errores al ejecutar
    private void Start()
    {
        PauseMenu.enabled = false;
    }

    //Actualiza posición del jugador, disparos y si activó el menú de pausa
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.P))
        {
            PauseMenu.enabled = true;
            Time.timeScale = 0;
        }
    }

    //Código que permite ver y activar los disparos
    private void Shoot()
    {
        if(!_laserActive)
        {
            Projectile projectile = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        }
    }

    //Cuando el laser sale de la visión del jugador se elimina, para evitar que la memoria colapse
    private void LaserDestroyed()
    {
        _laserActive = false;
    }

    //Se pone un colisionador al jugador para que este pueda recibir daño
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            Lifes.LifesCount -= 1;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            Lifes.LifesCount -= 3;
        }
    }
}
