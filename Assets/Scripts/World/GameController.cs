using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{


    public static int enemiesKilled;
    public float enemiesKilledDebug;
    float enemiesKilledWeighting;
    public float enemiesKilledWeightingDebug;

    public float playerAccuracy;
    public static float shotsHit;
    public static float shotsMissed;
    public int shotsHitDebug;
    public int shotsMissedDebug;
    public float playerAccuracyDebug;
    public static int medKitsUsed;

    public static float elapsedTime;
    public static float playerPosX;
    float progressionWeighting;
    public float progressionWeightingDebug;

    public static float playerHealth;
    public float playerHealthWeighting;
    public float playerHealthDebug;

    public static int challengeMode;
    public int challengeModeDebug;

    public static int playerAmmo;
    public static int playerScore;

    public int maxGameTime = 190;
    public Text gameTimeMinutesUI, gameTimeSecondsUI;
    public float gameTime;
    public int gameTimeSeconds, gameTimeMinutes;
    public Text scoreUI;

    void Awake()
    {
        enemiesKilled = 0;
        elapsedTime = 0;
        playerHealth = 100;
        playerAmmo = 15;
        medKitsUsed = 1;
    }



    public static void playerDeath(playerStats player)
    {
        Destroy(player.gameObject);
        SceneManager.LoadScene("Stat Screen");
    }

    public static void otherDeath(playerHealth player)
    {
        Destroy(player.gameObject);
        SceneManager.LoadScene("Stat Screen");
    }

    void Update()
    {
       // Debug.Log(playerPosX);
        scoreUI.text = "Score: " + playerScore;
        gameTime += Time.deltaTime;
        //if we have minutes
        if (gameTime > 60)
        {
            //work them out 
            gameTimeMinutes = Mathf.FloorToInt(gameTime / 60);
            gameTimeSeconds = Mathf.FloorToInt(gameTime % 60);

        }
        else
        {
            //if we dont have minutes themn set minutes to 0 and carry on
            gameTimeSeconds = Mathf.FloorToInt(gameTime);
            gameTimeMinutes = 0;
        }
        if (gameTimeSeconds.ToString().Length == 1)
        {
            gameTimeMinutesUI.text = "Time: " + gameTimeMinutes.ToString() + ":" + "0" + gameTimeSeconds.ToString();
        }
        else
        {
            gameTimeMinutesUI.text = "Time: " + gameTimeMinutes.ToString() + ":" + gameTimeSeconds.ToString();
        }

        if (shotsHit + shotsMissed == 0)
        {
            playerAccuracy = 0.5f;
        } else
        {
            playerAccuracy = shotsHit / (shotsHit + shotsMissed);
            Debug.Log(playerAccuracy);
        }

        //(enemies killed * weighting (normalised)) + (player accuracy * weighting (normalised)) + (elapsed time * weighting -> normalised) + (playerHealth * weighting -> normalised)
        if (enemiesKilled == 0 && elapsedTime > 15)
        {
            enemiesKilledWeighting = 1;
        }
        else
        {
             
            enemiesKilledWeighting = (enemiesKilled / 10f);
            Debug.Log("Enemies Killed Weighting = " + enemiesKilled + " / 10 = " + enemiesKilledWeighting );
        }
        if (gameTime > 15f)
        {
            if(playerPosX < 100f)
            {
               // Debug.Log("Applying progression weighting ");
                progressionWeighting = 0.1f;
            }
            if(playerPosX > 100)
            {
                progressionWeighting = 0.3f;
                //Debug.Log("Applying progression weighting ");
            }
            if (playerPosX > 200)
            {
                progressionWeighting = 0.5f;
               // Debug.Log("Applying progression weighting ");
            }
            if (playerPosX > 300)
            {
                progressionWeighting = 0.7f;
               // Debug.Log("Applying progression weighting ");
            }
            if (playerPosX > 400)
            {
                progressionWeighting = 0.9f;
               // Debug.Log("Applying progression weighting ");
            }
            if (playerPosX > 500)
            {
                progressionWeighting = 1.0f;
               // Debug.Log("Applying progression weighting ");
            }
            
        }
        if (gameTime > 30)
        {
            if (playerPosX < 100)
            {
                progressionWeighting = 0.1f;
            }
            if (playerPosX > 100)
            {
                progressionWeighting = 0.2f;
            }
            if (playerPosX > 200)
            {
                progressionWeighting = 0.4f;
            }
            if (playerPosX > 300)
            {
                progressionWeighting = 0.6f;
            }
            if (playerPosX > 400)
            {
                progressionWeighting = 0.7f;
            }
            if (playerPosX > 500)
            {
                progressionWeighting = 0.8f;
            }

            playerHealthWeighting = (playerHealth / 100f);
            Debug.Log("Health Weighting = " + playerHealth + " / " + "100 = " + playerHealthWeighting);
            if (playerHealthWeighting == 1f && enemiesKilled > 3)
            {

                playerHealthWeighting = ((playerHealth / 100f) * ((enemiesKilled / 3) / medKitsUsed));
                
            }



        }




        // challengeMode = (enemiesKilled / 10) + (playerAccuracy) + (gameTime / playerPosX) + (playerHealth / 100);


        //challengeMode = Mathf.RoundToInt((enemiesKilledWeighting*2f) + playerAccuracy + (progressionWeighting*1.3f) + playerHealthWeighting);
        challengeMode = 1;
        if (challengeMode == 0)
        {
            challengeMode = 1;
        }
        challengeModeDebug = challengeMode;
        enemiesKilledWeightingDebug = enemiesKilledWeighting * 2f;
        playerAccuracyDebug = playerAccuracy;
        progressionWeightingDebug = progressionWeighting;
        playerHealthDebug = playerHealthWeighting;
       
        //

    }
}
