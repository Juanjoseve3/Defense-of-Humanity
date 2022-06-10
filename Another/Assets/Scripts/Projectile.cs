using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Direcci�n del proyectil
    public Vector3 direction;

    //Velocidad del proyectil
    public float speed;

    //Acci�n de destruir
    public System.Action destroyed;

    //Se actualiza la posici�n del proyectil para que este siga cayendo o subiendo
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }


    //Se le agrega un colisionador que activa el destruir un objeto del juego
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (destroyed != null)
        {
            destroyed.Invoke();
        }

        Destroy(gameObject);
    }
}
