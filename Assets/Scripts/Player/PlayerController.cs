using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRigidBody;


  
    public bool playerGrounded = true;


    public float jumpPower = 25f;
    public float playerSpeed = 20f;
   // public int playerScore;
    public Transform playerPosition;

    public LayerMask groundLayer;

	public static bool facingLeft = false;

    // Use this for initialization
    void Start()
    {
        playerPosition = this.transform;
        playerRigidBody = GetComponent<Rigidbody2D>();
    }


    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void Update()
    {
		float directionCheck = Input.GetAxisRaw("Horizontal");
		if (facingLeft && directionCheck > 0) 
		{
			playerFlip();
		}
		if (!facingLeft && directionCheck < 0) 
		{
			playerFlip();
		}
        playerGrounded = onGround();

        if (playerGrounded)
        {
            movePlayer(Input.GetAxisRaw("Horizontal"));
        }
        else
        {
            movePlayer(Input.GetAxisRaw("Horizontal") / 1.5f);
        }
        if (Input.GetButtonDown("Jump"))
        {
            playerJump();
        }
        GameController.playerPosX = playerPosition.position.x;
    }
    void FixedUpdate()
    {
        
    }

    bool onGround()
    {
        Vector2 playerPosition = transform.position;
        Vector2 playerDirection = Vector2.down;
        Vector2 offset, middleOffset;
        middleOffset = new Vector2(0f, -2f);
        if (!facingLeft)
        {
            offset = new Vector2(-2f, -2f);
        }
        else
        {
             offset = new Vector2(2f, -2f);
        }
        float checkDistance = .4f;
        Debug.DrawRay((playerPosition + offset), playerDirection, Color.green);
        Debug.DrawRay((playerPosition + middleOffset), playerDirection, Color.green);
        RaycastHit2D backfloorCheckRay = Physics2D.Raycast((playerPosition + middleOffset), playerDirection, checkDistance, groundLayer);
        RaycastHit2D floorCheckRay = Physics2D.Raycast((playerPosition + offset), playerDirection, checkDistance, groundLayer);
        if (floorCheckRay.collider != null || backfloorCheckRay.collider !=null)
        {
      
            return true;
        }
        
        return false;
    }

    public void movePlayer(float horizontalMovement)
    {
        Vector2 playerVelocity = playerRigidBody.velocity;
        playerVelocity.x = horizontalMovement * playerSpeed;
        playerRigidBody.velocity = playerVelocity;
    }

    public void playerJump()
    {
        if (playerGrounded)
        {
            playerRigidBody.velocity += Vector2.up * jumpPower;
        }
    }

	public void playerFlip()
	{
		facingLeft = !facingLeft;
		Vector3 playerScale = transform.localScale;
		playerScale.x = -playerScale.x;
		transform.localScale = playerScale;
	}
   
}