using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject Player;
    public Vector3 cameraOffset;


    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        cameraOffset = transform.position - Player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = Player.transform.position + cameraOffset;
    }
}
