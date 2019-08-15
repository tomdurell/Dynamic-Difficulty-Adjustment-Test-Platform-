using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupManager : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D collidingObject)
    {
        
        if (collidingObject.gameObject.tag == "Player")
        {
            Debug.Log("Despawning Pickup");
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
