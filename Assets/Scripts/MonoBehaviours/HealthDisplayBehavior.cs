using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayBehavior : MonoBehaviour
{
    private int playerHealth;
    private GameObject player;
    public int fullValue;

    public Sprite[] hearts;

    private SpriteRenderer render;
    
    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerBehavior>().health;
    }

    // Update is called once per frame
    void Update()
    {
        //playerHealth = player.GetComponent<PlayerBehavior>().health;
        if (playerHealth >= fullValue)
        {
            render.sprite = hearts[0];
        } 
        else if (playerHealth == fullValue - 1)
        {
            render.sprite = hearts[1];
        }
        else
        {
            render.sprite = hearts[2];
        }
    }
}
