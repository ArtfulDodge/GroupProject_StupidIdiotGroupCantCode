﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonBehavior : MonoBehaviour
{
    public List<GameObject> enemiesInRange;
    public GameObject player;
    private float lastShotTime;
    public float fireRate;
    public float projectileSpeed = 10f;
    public GameObject projectile;
    public bool grabable;
    public bool grabbed;
    public int level = 1;
    public Text CannonLevelText;

    // Start is called before the first frame update
    void Start()
    {
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
        grabable = false;
        grabbed = false;

        ProjectileBehavior pb = projectile.GetComponent<ProjectileBehavior>();
        pb.speed = projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = null;
       
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<EnemyBehavior>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        
        if (target != null && !grabbed)
        {
            if (Time.time - lastShotTime > fireRate)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }
            
            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI, new Vector3(0, 0, 1));
        }

        if (Input.GetKeyDown(KeyCode.Space) && grabable)
        {
            grabbed = !grabbed;
        }

        if (grabbed)
        {
            Vector3 newPosition = player.transform.position;
            newPosition.y = newPosition.y + 1.5f;
            transform.position = newPosition;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Upgrade();
        }
    }

    void Upgrade()
    {
        if (CoinBehavior.coinsGathered >= 5 && level < 9)
        {
            level++;
            CannonLevelText.text = "Cannon Level: " + level.ToString();
            CoinBehavior.coinsGathered -= 5;
            if (fireRate > 0.1f)
                fireRate -= 0.1f;

            ProjectileBehavior pb = projectile.GetComponent<ProjectileBehavior>();

            if (projectileSpeed < 100)
                projectileSpeed += 5;

            pb.speed = projectileSpeed;
        }
    }

    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    void Shoot(Collider2D target)
    {
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = projectile.transform.position.z;
        targetPosition.z = projectile.transform.position.z;

        GameObject newProjectile = (GameObject)Instantiate(projectile);
        newProjectile.transform.position = startPosition;
        ProjectileBehavior projectileComp = newProjectile.GetComponent<ProjectileBehavior>();
        projectileComp.target = target.gameObject;
        projectileComp.startPosition = startPosition;
        projectileComp.targetPosition = targetPosition;
    }
}
