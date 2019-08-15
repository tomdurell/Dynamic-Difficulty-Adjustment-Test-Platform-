using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatGen : MonoBehaviour
{

    public Text myText;

    // Use this for initialization
    void Start()
    {
      
    }

    void Update()
    {
        myText.text = "Score: " + GameController.playerScore + "\n Enemies Killed: " + GameController.enemiesKilled + "\n Completion Time: " + "\n Shots Fired: " + (GameController.shotsHit + GameController.shotsMissed) +"\n Shots Missed: " + GameController.shotsMissed + "\n Accuracy:" + (GameController.shotsHit / (GameController.shotsHit + GameController.shotsMissed))+ "%";
    }
}