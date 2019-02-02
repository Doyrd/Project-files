using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    public float moveSpeed;
    private float moveSpeedSafe;
    public float moveSpeedMultiplier;

    public float speedIncreasePoint;
    private float speedIncreacePointSafe;

    public float speedPointMultiplier;

    private float speedPointCount;
    private float speedPointCountSafe;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJumping;

    private bool canDoubleJump;
    private bool hasJumped;

    private Rigidbody2D myRigidbody;

    private bool onPlatform;
    public LayerMask whatIsPlatform;
    public Transform platformChecker;
    public float platformCheckRadius;

    /*private Collider2D myCollider;*/

    private Animator myAnimator;

    public gameManager theGameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    public AudioSource landingSound;

    public scrollingBackground theScrollingBackgroundScript;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        /*myCollider = GetComponent<Collider2D>();*/
        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedPointCount = speedIncreasePoint;

        moveSpeedSafe = moveSpeed;
        speedPointCountSafe = speedPointCount;
        speedIncreacePointSafe = speedIncreasePoint;

        stoppedJumping = true;
    }

    void Update()
	{
		/*onPlatform = Physics2D.IsTouchingLayers(myCollider, whatIsPlatform);*/

		onPlatform = Physics2D.OverlapCircle (platformChecker.position, platformCheckRadius, whatIsPlatform);

		if (transform.position.x > speedPointCount) {
			speedPointCount += speedIncreasePoint;
			speedIncreasePoint = speedIncreasePoint * speedPointMultiplier;
			moveSpeed = moveSpeed * moveSpeedMultiplier;
		}

		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space))
        {
			if (onPlatform)
            {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				stoppedJumping = false;
                hasJumped = true;
				jumpSound.Play ();
			}
		}

        if (Input.GetKeyDown(KeyCode.Space) && !onPlatform && canDoubleJump && hasJumped)
            {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            canDoubleJump = false;
            stoppedJumping = false;
            hasJumped = false;
            jumpSound.Play();
        }

        if (Input.GetKey(KeyCode.Space) && !stoppedJumping)
        {
			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp(KeyCode.Space))
        {
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			theGameManager.Reset ();
		}

		if (onPlatform) {
			jumpTimeCounter = jumpTime;
            canDoubleJump = true;
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("onPlatform", onPlatform);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Death barrier")
        {
            theGameManager.RestartGame();
            moveSpeed = moveSpeedSafe;
            speedPointCount = speedPointCountSafe;
            speedIncreasePoint = speedIncreacePointSafe;
            deathSound.Play();
            theScrollingBackgroundScript.speed = 0.001f;
        }
    }

}
