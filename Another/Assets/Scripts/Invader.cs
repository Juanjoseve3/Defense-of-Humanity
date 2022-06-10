using UnityEngine;


//Este código se encarga de generar la matriz de alienigenas
public class Invader : MonoBehaviour
{
    //Sprites para animar
    public Sprite[] animationSprites;

    //Tiempo que dura la animación
    public float animationTime = 1.0f;

    //Acción de matar un alien
    public System.Action killed;

    //Renderizador del sprite
    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;
    public static int score;
    public static int alienValue = 10;

    //Antes de empezar se renderizan los enemigos
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Cuando se inicia el juego se inicia la animación de los enemigos
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    //Mientras se mueve la matriz de enemigos cada enemigo tiene una animación individual que se va ejecutando
    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = animationSprites[_animationFrame];
    }

    //Hacemos que los sprites tengan colisión con los ataques del jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            killed.Invoke();
            gameObject.SetActive(false);
            score += alienValue;
        }
    }

    //Hacemos que retorne un valor para acumularlo en el puntaje
    public static int ScoreCount()
    {
        return score;
    }
}
