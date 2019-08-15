using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponScript : MonoBehaviour {

    public float fireRate = 0.1f;
    public GameObject bullet;
    Quaternion bulletRot = new Quaternion(0f,0f,0f,0f);
    public LayerMask enemyCheck;
    Transform Muzzle;
    public float weaponRange = 10f;
    public float bulletTimer = 0f;
    public int playerAmmo = 15;
    public int ammunitionAddition = 10;
    Vector2 bulletSpawnPoint;
    public bool pickupActive = true;
    public float pickupResetTimer;

    public Text ammoAmountUI;



    float counter;
	// Use this for initialization
	void Start () {
        Muzzle = transform.Find("Fire Point");
        ammoAmountUI.text = playerAmmo.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        bulletTimer += Time.deltaTime;

        if (GameController.challengeMode == 1)
        {
            ammunitionAddition = 9;
        }
        if (GameController.challengeMode == 2)
        {
            ammunitionAddition = 12;
        }
        if (GameController.challengeMode == 3)
        {
            ammunitionAddition = 15;
        }
        if (GameController.challengeMode == 4)
        {
            ammunitionAddition = 16;
        }
        if (GameController.challengeMode == 5)
        {
            ammunitionAddition = 15;
        }

        if (Input.GetButtonDown("Fire1") && fireRate < bulletTimer && playerAmmo > 0)
        {
            fireGun();
            playerAmmo -= 1;
            ammoAmountUI.text = playerAmmo.ToString();
            GameController.playerAmmo = playerAmmo;
            bulletTimer = 0;
        }
        if (!pickupActive)
        {
            pickupResetTimer += Time.deltaTime;
        }
        
	}
    void fireGun()
    {
        bulletSpawnPoint = new Vector2(Muzzle.position.x, Muzzle.position.y);
        Instantiate(bullet, bulletSpawnPoint, bulletRot);
       // Debug.Log("Test");
        

    }

    void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (pickupResetTimer > 0.5f)
        {
            pickupActive = true;
            pickupResetTimer = 0;
        }
        if (collidingObject.gameObject.tag == "Ammo")
        //if (collidingObject.gameObject == enemy)
        {
            if (pickupActive)
            {
                pickupActive = false;
                Debug.Log("Ammo Detected");
                playerAmmo = playerAmmo + ammunitionAddition;
                GameController.playerAmmo = playerAmmo;
                ammoAmountUI.text = playerAmmo.ToString();
            }
        }
    }
}
