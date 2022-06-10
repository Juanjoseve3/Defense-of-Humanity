using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    //Los sprites que permiten la animación
    public Sprite[] animationSprites;

    //Tiempo que dura la animación
    public float animationTime = 1.0f;

    //Renderizador del sprite
    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;
    public static int score;
    public static int personValue = 20;

    public Vector3 direction;

    public float speed;

    public System.Action destroyed;

    //Antes de empezar se busca el componente que renderiza el sprite
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Cuando se inicia empieza la animación
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    //Actualiza la posición de las personas haciendo que caigan
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    //Anima cada persona
    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = animationSprites[_animationFrame];
    }

    //Se pone un colisionador para cuando el jugador recoja una persona esta desaparezca 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            gameObject.SetActive(false);
            score += personValue;
        }
    }

    //Retorna el valor de la persona
    public static int ScoreCount()
    {
        return score;
    }
}
