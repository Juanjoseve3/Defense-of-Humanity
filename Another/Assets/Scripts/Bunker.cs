using UnityEngine;


//Este código es el principal para las defensas que protegen al jugador de los ataques alienigenas
public class Bunker : MonoBehaviour
{
    public int bunkerLife;
    private void Start()
    {
        bunkerLife = 5;
    }

    //Hacemos que los sprites tengan colisión con los misiles del jugador y de los alienigenas
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            gameObject.SetActive(false);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Missile") || other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            bunkerLife --;
        }
        if (bunkerLife <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
