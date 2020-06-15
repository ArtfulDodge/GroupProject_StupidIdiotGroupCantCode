using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 7.75f;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    private Stopwatch stopwatch = new Stopwatch();
    private bool invuln = false;
    private bool healthRegening = false;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    public int health = 6;
    public long maxInvulnTime = 250;
    private long elapsedTime;
    public long healthRegenSpeed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!healthRegening)
        {
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            UpdateAnimationAndMove();

            if (invuln)
            {
                stopwatch.Stop();
                elapsedTime = stopwatch.ElapsedMilliseconds;
                if (elapsedTime >= maxInvulnTime)
                {
                    stopwatch.Reset();
                    invuln = false;
                }
                else
                {
                    if (elapsedTime % 100 <= 50)
                    { 
                        GetComponent<SpriteRenderer>().color = Color.red;
                    } else
                    {
                        GetComponent<SpriteRenderer>().color = Color.white;
                    }
                    stopwatch.Start();
                }
            }
        } else
        {
            stopwatch.Stop();
            elapsedTime = stopwatch.ElapsedMilliseconds;

            if (elapsedTime % 250 <= 150)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }

            if (elapsedTime >= healthRegenSpeed)
            {
                health = health + 1;
                stopwatch.Reset();
            }

            if (health >= 6)
            {
                health = 6;
                healthRegening = false;
                invuln = false;
                GetComponent<SpriteRenderer>().color = Color.white;
                stopwatch.Reset();
            } else
            {
                stopwatch.Start();
            }
        }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        } else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        float dist = speed * Time.fixedDeltaTime;
        myRigidBody.MovePosition(new Vector3(Mathf.Clamp(transform.position.x + change.x * dist, minPosition.x, maxPosition.x), 
                                            Mathf.Clamp(transform.position.y + change.y * dist, minPosition.y, maxPosition.y)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            if (!invuln)
            {
                health -= 1;
                invuln = true;

                if (health <= 0)
                {
                    health = 0;
                    healthRegening = true;
                }

                stopwatch.Start();
            }
        }
    }

    public Vector3 GetChange()
    {
        return change;
    }
}
