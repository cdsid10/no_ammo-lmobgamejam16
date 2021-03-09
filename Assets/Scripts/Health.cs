using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private Audio _audio;
    private Shake _shake;
    
    [SerializeField] public int health;
    public TMP_Text healthText;
    
    private CircleCollider2D _circleCollider2D;
    [SerializeField] private SpriteRenderer _spriteRenderer, aimSpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _audio = FindObjectOfType<Audio>();
        _shake = FindObjectOfType<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.SetText(health.ToString());
    }

    public void DamagePlayer()
    {
        _shake.CamShake();
        health--;
        _audio.PlayHealthDecrease();
        StartCoroutine(EnableCollider());
        if (health <= 0)
        {
            SceneManager.LoadScene(3);
            Cursor.visible = true;
        }
    }
    
    IEnumerator EnableCollider()
    {
        _circleCollider2D.enabled = false;
        _spriteRenderer.color -= new Color(0, 0, 0, 0.69f);
        aimSpriteRenderer.color -= new Color(0, 0, 0, 0.69f);
        yield return new WaitForSeconds(1.25f);
        _spriteRenderer.color += new Color(0, 0, 0, 0.69f);
        aimSpriteRenderer.color += new Color(0, 0, 0, 0.69f);
        _circleCollider2D.enabled = true;
        yield return new WaitForSeconds(1f);
    }
}
