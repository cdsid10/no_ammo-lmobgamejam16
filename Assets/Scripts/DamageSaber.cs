using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DamageSaber : MonoBehaviour
{
    private Enemy _enemy;
    
    [SerializeField] private GameObject saberAgileEffect, saberNormalEffect, saberHeavyEffect;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyAgile"))
        {
            Instantiate(saberAgileEffect, other.gameObject.transform.position, quaternion.identity);
        }
        
        if (other.CompareTag("EnemyNormal"))
        {
            Instantiate(saberNormalEffect, other.gameObject.transform.position, quaternion.identity);
        }
        
        if (other.CompareTag("EnemyHeavy"))
        {
            Instantiate(saberHeavyEffect, other.gameObject.transform.position, quaternion.identity);
        }
    }
}
