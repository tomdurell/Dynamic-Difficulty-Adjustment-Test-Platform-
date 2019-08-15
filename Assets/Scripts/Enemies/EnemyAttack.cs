using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public float attackReset = 0.5f;
    public int attackDamage = 10;
    float counter = 0;
    bool playerIsTarget = false;
    GameObject player;
    playerHealth playerHealth;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerHealth>();
       

    }

    void Start()
    {
        if (this.gameObject.tag == "EnemyLvl1")
        {
            attackDamage = 10;
        }
        if (this.gameObject.tag == "EnemyLvl2")
        {
            attackDamage = 15;
        }
        if (this.gameObject.tag == "EnemyLvl3")
        {
            attackDamage = 20;
        }
        if (this.gameObject.tag == "EnemyLvl4")
        {
            attackDamage = 25;
        }
        if (this.gameObject.tag == "EnemyLvl5")
        {
            attackDamage = 25;
            attackReset = 0.4f;
        }
    }
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D collidingObject) {
        if (collidingObject.gameObject == player)
        {
            //Debug.Log("Touching");
            playerIsTarget = true;
        }
	}
    void OnTriggerStay2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject == player)
        {
            //Debug.Log("Touching");
            playerIsTarget = true;
        }
    }

    void OnTriggerExit2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject == player)
        {
            //Debug.Log("Not Touching");
            playerIsTarget = false;
        }
    }

    void Update()
    {
        counter += Time.deltaTime;
       //Debug.Log(playerIsTarget);
        if (counter >= attackReset && playerIsTarget)
        {
            
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        counter = 0f;
        Debug.Log(playerHealth.currentPlayerHealth.ToString());
        if (playerHealth.currentPlayerHealth > 0)
        {

            playerHealth.Damaged(attackDamage);

        }
    }
}
