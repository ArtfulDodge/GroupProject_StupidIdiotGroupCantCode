using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject coin;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 30f;
    float nextSpawn = 0.0f;
    private GameObject[] coinList;
    public int number;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinList = GameObject.FindGameObjectsWithTag("Coin");

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-3, 24);
            randY = Random.Range(-9, 13);
            whereToSpawn = new Vector2(randX, randY);
            Instantiate (coin, whereToSpawn, Quaternion.identity);
        }

    }
}
