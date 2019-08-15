using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public GameObject enemy, enemy2, enemy3, enemy4, enemy5;
    GameObject player;          
    public Transform spawnPoint;
    bool spawnEnemy = false;
    public float enemySpawnCounter = 5;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPoint = this.gameObject.transform;
        

    }
    void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject == player)
        {
            //Debug.Log("Touching");
            spawnEnemy = true;
        }
    }

    void OnTriggerExit2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject == player)
        {
            //Debug.Log("Not Touching");
            spawnEnemy = false;
        }
    }

    void Update()
    {
        enemySpawnCounter += Time.deltaTime;
        if (spawnEnemy == true && enemySpawnCounter > 5)
        {
            if (GameController.challengeMode == 1)
            {
                Instantiate(enemy, spawnPoint);
                spawnEnemy = false;
                enemySpawnCounter = 0;
            }
            if (GameController.challengeMode == 2)
            {
                Instantiate(enemy2, spawnPoint);
                spawnEnemy = false;
                enemySpawnCounter = 0;
            }
			if (GameController.challengeMode == 3)
			{
				Instantiate(enemy3, spawnPoint);
				spawnEnemy = false;
				enemySpawnCounter = 0;
			}
			if (GameController.challengeMode == 4)
			{
				Instantiate(enemy4, spawnPoint);
				spawnEnemy = false;
				enemySpawnCounter = 0;
			}
			if (GameController.challengeMode == 5)
			{
				Instantiate(enemy5, spawnPoint);
				spawnEnemy = false;
				enemySpawnCounter = 0;
			}
        }
    }
}
