using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTopBehavior : MonoBehaviour
{
    public BoxCollider2D hitbox;
    public BoxCollider2D triggerbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
