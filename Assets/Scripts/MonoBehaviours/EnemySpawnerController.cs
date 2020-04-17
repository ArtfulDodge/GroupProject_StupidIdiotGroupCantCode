using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{

    public GameObject enemy;
    public int startingEnemiesPerWave;
    private int enemiesInWave;
    public float spawnRate;
    public float betweenWaveTime;
    private float nextSpawn = 0.0f;
    private Vector2 whereToSpawn;
    private int enemies;
    private GameObject[] enemyList;

    // Start is called before the first frame update
    void Start()
    {
        whereToSpawn = new Vector2(20, 21);
        enemiesInWave = startingEnemiesPerWave;
        enemies = 0;
        nextSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyList.Length == 0 && enemies != 0)
        {
            enemies = 0;
            enemiesInWave++;
            nextSpawn = Time.time + betweenWaveTime;
            if (enemiesInWave % 5 == 0 && betweenWaveTime > 1)
            {
                betweenWaveTime--;
            }
        }

        if (Time.time > nextSpawn && enemies < enemiesInWave)
        {
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2(20, 21);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            enemies++;
        }

    }
}

