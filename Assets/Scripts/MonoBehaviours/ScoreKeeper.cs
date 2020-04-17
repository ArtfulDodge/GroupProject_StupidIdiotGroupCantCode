using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreKeeper : MonoBehaviour
{
    public GameObject coin;
    public Text txtScore;
    public static int coinsGathered = 0;
    public static int score = 0;
    public GameObject[] trees;


    // Start is called before the first frame update
    void Start()
    {
        txtScore.text = "Score: " + score.ToString();
        trees = GameObject.FindGameObjectsWithTag("TreeTop");
        foreach (GameObject tree in trees)
        {
            TreeDestructionDelegate del = tree.gameObject.GetComponent<TreeDestructionDelegate>();
            del.treeDelegate += OnTreeDestroy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CoinBehavior.coinsGathered > coinsGathered)
        {
            score += 100;
        }

        coinsGathered = CoinBehavior.coinsGathered;
        txtScore.text = "Score: " + score.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

    void OnEnemyDestroy(GameObject enemy)
    {
        score += 500;
    }

    void OnTreeDestroy(GameObject tree)
    {
        score -= 500;
    }
}
