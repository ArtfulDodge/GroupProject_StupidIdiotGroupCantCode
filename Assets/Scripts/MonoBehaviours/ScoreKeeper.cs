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


    // Start is called before the first frame update
    void Start()
    {
        txtScore.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (CoinBehavior.coinsGathered > coinsGathered)
        {
            coinsGathered = CoinBehavior.coinsGathered;
            score += 100;
        }

        txtScore.text = "Score: " + score.ToString();
    }
}
