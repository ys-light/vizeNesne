using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> enemies;

    private float duration = 5;
    private float timer = 0;
    [SerializeField]
    private PlayerController playerController;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= duration)
        {
            timer = 0;
            duration = Random.RandomRange(3, 5);
            var enemyCount = Random.RandomRange(1, playerController.Level);
            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5)),Quaternion.identity); 
            }
        }
        timer += Time.deltaTime;
    }
}
