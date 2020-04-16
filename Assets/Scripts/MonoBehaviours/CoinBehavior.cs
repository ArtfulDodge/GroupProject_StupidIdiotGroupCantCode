using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour
{
    public BoxCollider2D triggerbox;
    public BoxCollider2D hitbox;
    public Text txtCoinsCollected;
    public Text coinsCollected;
    public static int coinsGathered = 0;


    void Start()
    {
        txtCoinsCollected.text = "Coins: " + coinsGathered.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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
