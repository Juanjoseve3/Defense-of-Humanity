using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invaders_lvl_2 : MonoBehaviour
{ 
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public AnimationCurve speed;
    public Projectile missilePrefab;
    public Person personPrefab;


    public float missileAttackRate = 1.0f;

    public float personSpawnRate = 0.5f;
    public int AmountKilled { get; private set; }
    public int AmountAlive => TotalInvaders - AmountKilled;
    public int TotalInvaders => rows * columns;
    public float PercentKilled => AmountKilled / TotalInvaders;
    private Vector3 _direction = Vector2.right;
    private void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float widht = 2.0f * (columns - 1);
            float height = 2.0f * (rows - 1);
            Vector2 centering = new Vector2(-widht / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);

            for (int col = 0; col < columns; col++)
            {
                Invader invader = Instantiate(prefabs[row], transform);
                invader.killed = InvaderKilled;
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), missileAttackRate, missileAttackRate);
        InvokeRepeating(nameof(PersonSpawn), personSpawnRate, personSpawnRate);
    }

    private void Update()   
    {
        float speed = this.speed.Evaluate(PercentKilled);
        transform.position += _direction * speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            { 
                continue; 
            }

            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
            {
                AdvanceRow();
            } else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;

        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position;
    }

    private void MissileAttack()
    {
        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            { 
                continue; 
            }
            if (UnityEngine.Random.value < (1.0f / AmountAlive))
            {
                Instantiate(missilePrefab, invader.position, Quaternion.identity);
                break;
            }

        }
    }

    private void PersonSpawn()
    {
        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (Random.value < (1.0f / AmountAlive))
            {
                Instantiate(personPrefab, invader.position, Quaternion.identity);
                break;
            }
        }
    }
    private void InvaderKilled()
    {
        AmountKilled++;

        if (AmountKilled >= TotalInvaders)
        {
            SceneManager.LoadScene("Credits");
        }    
    }
}
