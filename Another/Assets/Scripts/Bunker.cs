using UnityEngine;

public class Bunker : MonoBehaviour
{
    public int bunkerLife;
    private void Start()
    {
        bunkerLife = 5;
    }
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
