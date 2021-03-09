using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private GameObject[] enemies;

    [SerializeField] private float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Vector3 spawn = new Vector3(Random.Range(-15f, 15f), Random.Range(-9f, 9f), 0f);
            if ((spawn - player.transform.position).magnitude < 5)
            {
                return;
            }
            else
            {
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawn, quaternion.identity);
            }

            timeRemaining = Random.Range(0.5f, 1.75f);
        }        
        
        
    }
}
