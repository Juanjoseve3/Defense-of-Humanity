using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Projectile laserPrefab;

    public float speed = 5.0f;

    private bool _laserActive;

    public int life = 3;

    public Canvas PauseMenu;


    private void Start()
    {
        PauseMenu.enabled = false;
    }
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
        else if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.P))
        {
            PauseMenu.enabled = false;
            Time.timeScale = 1;
        }
    }

    private void Shoot()
    {
        if(!_laserActive)
        {
            Projectile projectile = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        }
    }

    private void LaserDestroyed()
    {
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader") || other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            Lifes.LifesCount -= 1;
        }
    }
}
