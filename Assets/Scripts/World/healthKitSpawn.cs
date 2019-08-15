using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthKitSpawn : MonoBehaviour
{


    public GameObject HealthKit;
    public Transform spawnPoint;


    void Start()
    {
        spawnPoint = this.gameObject.transform;
        Instantiate(HealthKit, spawnPoint);
    }


    void Update()
    {

        //if (GameController.challengeMode == 1)
        //{
        //    Instantiate(Ammo, spawnPoint);

        //}
        //if (GameController.challengeMode == 2)
        //{
        //    Instantiate(Ammo, spawnPoint);

        //}
        //if (GameController.challengeMode == 3)
        //{
        //    Instantiate(Ammo, spawnPoint);

        //}
        //if (GameController.challengeMode == 4)
        //{
        //    Instantiate(Ammo, spawnPoint);

        //}
        //if (GameController.challengeMode == 5)
        //{
        //    Instantiate(Ammo, spawnPoint);

        //}
    }

}

