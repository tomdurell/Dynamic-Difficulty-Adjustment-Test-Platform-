using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {

    // Use this for initialization
    [System.Serializable]
    public class playerInfo
    {
        public int playerHealth = 100;
        
    }

    public playerInfo playerInformation = new playerInfo();

    public void playerHurt(int damage)
    {
        playerInformation.playerHealth -= damage;
        if (playerInformation.playerHealth <= 0)
        {
            GameController.playerDeath(this);
        }
    }

    void Update()
    {
        if (transform.position.y < -15)
        {
            playerHurt(200);
        }

    }

}
