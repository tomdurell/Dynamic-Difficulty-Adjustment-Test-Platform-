using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public int bulletDamage = 35;
    bool enemyIsTarget = false;
    GameObject enemy;
    EnemyHealth enemyHealth;
    private Rigidbody2D bulletRigid;
    public float bulletSpeed = 1f;
    bool facingLeft = false;
    public GameObject player;
    public float flightTime;
    public bool miss = false;
    void Awake()
    {

       



    }

    void Start()
    {
        bulletRigid = GetComponent<Rigidbody2D>();
        if (PlayerController.facingLeft)
        {
            bulletRigid.AddForce(Vector2.left * bulletSpeed);
        }
        else
        {
            bulletRigid.AddForce(Vector2.right * bulletSpeed);
        }
    }
    void OnTriggerEnter2D(Collider2D collidingObject)
    {
       // Debug.Log("Collision Detected");
        if (collidingObject.gameObject.tag == "Enemy" || collidingObject.gameObject.tag == "EnemyLvl1" || collidingObject.gameObject.tag == "EnemyLvl2" || collidingObject.gameObject.tag == "EnemyLvl3" || collidingObject.gameObject.tag == "EnemyLvl4" || collidingObject.gameObject.tag == "EnemyLvl5")
        //if (collidingObject.gameObject == enemy)
        {
            enemy = collidingObject.gameObject;
            enemyHealth = enemy.GetComponent<EnemyHealth>();
          //  Debug.Log("Shooting Enemy - Hit!");
            enemyIsTarget = true;
            


        }
        else
        {
           // Debug.Log("Not enemy");
            miss = true;
        }
        }


    void Update()
    {
        flightTime += Time.deltaTime;
        if (enemyIsTarget)
        {
           // Debug.Log("Shooting Enemy - Hit! - Applying Damage");
            AttackEnemy();
            enemyIsTarget = false;
        }
        if (flightTime > 1f)
        {
            if (miss)
            {
                GameController.shotsMissed += 1;
                miss = false;
            }
            Destroy(this.gameObject);
        }
       

        

        
    }

    void AttackEnemy()
    {
        
 
        if (enemyHealth.enemyCurrentHealth > 0)
        {
            GameController.shotsHit += 1;
           // Debug.Log("Attack Enemy Function");
            enemyHealth.enemyDamaged(bulletDamage);
            Destroy(gameObject);
        }
    }
}
