using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int enemyMaxHealth = 100;
    public int enemyCurrentHealth;
    int scoreValue;
   //
   // int score;
    // Use this for initialization
    void Start () {
        //score = 0;
        if (this.gameObject.tag == "EnemyLvl1")
        {
            enemyMaxHealth = 100;
            scoreValue = 10;
        }
        if (this.gameObject.tag == "EnemyLvl2")
        {
            enemyMaxHealth = 110;
            scoreValue = 20;
        }
        if (this.gameObject.tag == "EnemyLvl3")
        {
            enemyMaxHealth = 145;
            scoreValue = 30;
        }
        if (this.gameObject.tag == "EnemyLvl4")
        {
            enemyMaxHealth = 180;
            scoreValue = 40;
        }
        if (this.gameObject.tag == "EnemyLvl5")
        {
            enemyMaxHealth = 180;
            scoreValue = 50;
        }
        enemyCurrentHealth = enemyMaxHealth;

    }
    public void enemyDamaged(int damage)
    {
        enemyCurrentHealth -= damage;

        if (enemyCurrentHealth <= 0)
        {    
            killEnemy();
          
        }
    }

    void killEnemy()
    {
        Destroy(gameObject);
        GameController.playerScore += scoreValue;
        GameController.enemiesKilled += 1;

    }

    void Update()
    {
        

    }

}
