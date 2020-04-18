using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour
{
    public Text txtCoinsCollected;
    public static int coinsGathered = 0;
    private bool collected;

    void Start()
    {
        txtCoinsCollected.text = "Coins: " + coinsGathered.ToString();
        collected = false;
    }

    void Update()
    {
        txtCoinsCollected.text = "Coins: " + coinsGathered.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collected)
        {
            collected = true;
            increaseCount();
            txtCoinsCollected.text = "Coins: " + coinsGathered.ToString();
            Destroy(gameObject);
        }
    }

    static void increaseCount()
    {
        coinsGathered++;
    }
}
