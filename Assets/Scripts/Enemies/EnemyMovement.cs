using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float enemySpeed = 5;
    private Rigidbody2D enemyRigidBody;
    public Transform enemyPosition;
    // Use this for initialization
    void Start () {
        enemyPosition = this.transform;
        enemyRigidBody = GetComponent<Rigidbody2D>();
        if (this.gameObject.tag == "EnemyLvl1")
        {
            enemySpeed = 5;
        }
        if (this.gameObject.tag == "EnemyLvl2")
        {
            enemySpeed = 5;
        }
        if (this.gameObject.tag == "EnemyLvl3")
        {
            enemySpeed = 5;
        }
        if (this.gameObject.tag == "EnemyLvl4")
        {
            enemySpeed = 6;
        }
        if (this.gameObject.tag == "EnemyLvl5")
        {
            enemySpeed = 7;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        moveEnemy();
	}

    public void moveEnemy()
    {
        Vector2 enemyVelocity = enemyRigidBody.velocity;
        enemyVelocity.x = -enemySpeed;
        enemyRigidBody.velocity = enemyVelocity;
    }
}
