using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Score _score;
    private Health _health;
    private Audio _audio;
    private Shake _shake;
    
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Transform player;

    [SerializeField] private float moveSpeed;

    public float health;

    private bool theForce;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerMovement>().transform;
        _score = FindObjectOfType<Score>();
        _health = FindObjectOfType<Health>();
        _audio = FindObjectOfType<Audio>();
        _shake = FindObjectOfType<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!theForce)
        {
            _rigidbody2D.AddForce((player.position - transform.position).normalized * (moveSpeed * Time.smoothDeltaTime), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("margaya madarchod");
            _health.DamagePlayer();
        }

        if (other.CompareTag("Saber"))
        {
            health--;
            _audio.Hit();
            StartCoroutine(EnableCollider());
            if (health <= 0)
            {
                if (gameObject.CompareTag("EnemyAgile"))
                {
                    _shake.CamShakeKill();
                    _score.PointsOne();
                    Destroy(gameObject);
                }
                else if (gameObject.CompareTag("EnemyNormal"))
                {
                    _shake.CamShakeKill();
                    _score.PointsTwo();
                    Destroy(gameObject);
                }
                else if (gameObject.CompareTag("EnemyHeavy"))
                {
                    _shake.CamShakeKill();
                    _score.PointsThree();
                    Destroy(gameObject);
                }
            }    
        }

        if (other.CompareTag("Force"))
        {
            theForce = true;
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Force"))
        {
            theForce = false;
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        theForce = false;
        _rigidbody2D.AddForce((player.position - transform.position).normalized * (moveSpeed * Time.smoothDeltaTime));
        
        
    }

    IEnumerator EnableCollider()
    {
        _boxCollider2D.enabled = false;
        _spriteRenderer.color -= new Color(0, 0, 0, 0.69f);
        yield return new WaitForSeconds(1.25f);
        _spriteRenderer.color += new Color(0, 0, 0, 0.69f);
        _boxCollider2D.enabled = true;
        yield return new WaitForSeconds(1f);
    }
}
