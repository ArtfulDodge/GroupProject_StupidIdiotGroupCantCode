using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeTopBehavior : MonoBehaviour
{
    public BoxCollider2D hitbox;
    public BoxCollider2D triggerbox;
    public Text gameOverText;
    public Text txtTreesLeft;
    public static int treesLeft = 6;

    // Start is called before the first frame update
    void Start()
    {
        txtTreesLeft.text = "Remaining Trees: " + treesLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            DecreaseTrees();
            txtTreesLeft.text = "Remaining Trees: " + treesLeft.ToString();
            if (treesLeft <= 0)
            {
                GameOver();
            }
            Destroy(gameObject);
        }
    }

    static void DecreaseTrees()
    {
        treesLeft--;
    }

    void GameOver()
    {
        gameOverText.text = "Game Over";
    }
}
