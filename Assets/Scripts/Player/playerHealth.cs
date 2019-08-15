using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {


    public int maxHealth = 100;
    public int currentPlayerHealth;
    public Slider UIhealthSlider;
    public int healthKitValue = 50;
    public float damageSplashTime = 6f;
    public Color damageSpashColour = new Color(1f,0f,0f,0.1f);
    public Image playerDamagedImage;
    bool playerDamaged;
    bool pickupHealth = false;
    bool pickUpStar = false;
    public float pickupTimer = 0.0f;


    PlayerController player;
	// Use this for initialization
	void Start () {
        currentPlayerHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerDamaged)
        {
            playerDamagedImage.color = damageSpashColour;
        }
        else
        {
            playerDamagedImage.color = Color.Lerp(playerDamagedImage.color, Color.clear, damageSplashTime * Time.deltaTime);
        }
        playerDamaged = false;

        if (GameController.challengeMode == 1)
        {
            healthKitValue = 50;
        }
        if (GameController.challengeMode == 2)
        {
            healthKitValue = 40;
        }
        if (GameController.challengeMode == 3)
        {
            healthKitValue = 30;
        }
        if (GameController.challengeMode == 4)
        {
            healthKitValue = 20;
        }
        if (GameController.challengeMode == 5)
        {
            healthKitValue = 10;
        }

        if(!pickupHealth)
        {

            pickupTimer += Time.deltaTime;
        }
        else if (!pickUpStar)
        {
            pickupTimer += Time.deltaTime;
        }

    }

    public void Damaged(int damage)
    {
        Debug.Log("Getting Hit by enemy");
        playerDamaged = true;
        currentPlayerHealth -= damage;
        UIhealthSlider.value = currentPlayerHealth;
        GameController.playerHealth = currentPlayerHealth;
        if (currentPlayerHealth <= 0)
        {
            GameController.otherDeath(this);
        }
    }

    void OnTriggerEnter2D(Collider2D collidingObject)
    {
        
        if (collidingObject.gameObject.tag == "Health")
        {
            if (pickupTimer > 0.5f)
            {
                pickupHealth = true;
                pickupTimer = 0;
            }


            if (pickupHealth)

            {
                pickupHealth = false;
                Debug.Log("Health Kit Detected");
                currentPlayerHealth += healthKitValue;
                if (currentPlayerHealth > 100)
                {
                    currentPlayerHealth = 100;
                }
                UIhealthSlider.value = currentPlayerHealth;
                GameController.playerHealth = currentPlayerHealth;
                GameController.medKitsUsed += 1;
              
            }
        }

        if (collidingObject.gameObject.tag == "Star")
        {
            if (pickupTimer > 0.5f)
            {
                pickUpStar = true;
                pickupTimer = 0;
            }
            if (pickUpStar)
            {
                pickUpStar = false;
                Debug.Log("Star Detected");

                GameController.playerScore += 200;
             
            }
        }
    }
}
