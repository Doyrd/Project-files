using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public float movementSpeed;
    public float jumpForce;

    private Rigidbody2D theRigidbody;
    private Collider2D theCollider;
    private Animator theAnimator;
    private SpriteRenderer theSpriteRenderer;

    public bool onPlatform;
    public LayerMask whatIsPlatform;
    /*public Transform platformChecker;
    public float platformCheckRadius;*/

    public bool isStandingStill;
    public bool isShooting;
    public bool isFlipped;

    public ShootingManager theShootingManagerScript;
    public SceneSwitch theSceneManagerScript;

    void Start()
    {
        theRigidbody = GetComponent<Rigidbody2D>();
        theCollider = GetComponent<Collider2D>();
        theAnimator = GetComponent<Animator>();
        theSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (isFlipped)
        {
            theSpriteRenderer.flipX = true;
            /*transform.localScale.x *= -1;*/
        }
        else if (!isFlipped)
        {
            theSpriteRenderer.flipX = false;
        }

        onPlatform = Physics2D.IsTouchingLayers(theCollider, whatIsPlatform);

        //Moving right
        if (Input.GetKey(KeyCode.RightArrow) && !isStandingStill)
        {
            theRigidbody.velocity = new Vector2(movementSpeed, theRigidbody.velocity.y);
            theAnimator.SetBool("Is walking", true);
            theAnimator.SetBool("Was walking is jumping", false);
            isFlipped = false;
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.Space) && !isStandingStill)
        {
            theAnimator.SetBool("Was walking is jumping", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && !isStandingStill)
        {
            theAnimator.SetBool("Is walking", false);
            theAnimator.SetBool("Was walking is jumping", false);
        }

        //Moving left
        if (Input.GetKey(KeyCode.LeftArrow) && !isStandingStill)
        {
            theRigidbody.velocity = new Vector2(-movementSpeed, theRigidbody.velocity.y);
            theAnimator.SetBool("Is walking", true);
            isFlipped = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.Space) && !isStandingStill)
        {
            theAnimator.SetBool("Was walking is jumping", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && !isStandingStill)
        {
            theAnimator.SetBool("Is walking", false);
        }

        //Aiming up
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.C))
        {
            theAnimator.SetBool("Is aiming up", true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.C))
        {
            theAnimator.SetBool("Is aiming up", false);
        }

        //Aiming right
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.C))
        {
            theAnimator.SetBool("Is aiming right", true);
            isFlipped = false;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.C))
        {
            theAnimator.SetBool("Is aiming right", false);
            isFlipped = false;
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.C))
        {
            theAnimator.SetBool("Is aiming right", true);
            isFlipped = false;
        }

        //Aiming left
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.C))
        {
            theAnimator.SetBool("Is aiming right", true);
            isFlipped = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.C))
        {
            theAnimator.SetBool("Is aiming right", false);
            isFlipped = true;
        }

        //Jumping
        if (Input.GetKey(KeyCode.Space))
        {
            if (onPlatform && !isStandingStill)
            {
                theRigidbody.velocity = new Vector2(theRigidbody.velocity.x, jumpForce);
                theAnimator.SetBool("Is jumping", true);
            }
        }
        else if (onPlatform)
        {
            theAnimator.SetBool("Is jumping", false);
        }

        //Crouching
        if (Input.GetKey(KeyCode.DownArrow) && isStandingStill)
        {
            theAnimator.SetBool("Is crouching", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            theAnimator.SetBool("Is crouching", false);
        }


        // Shooting up
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.D) && !isShooting)
        {
            theShootingManagerScript.ShootUp();
            isShooting = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            isShooting = false;
        }

        //Shooting right
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.D) && !isShooting)
        {
            theShootingManagerScript.ShootRight();
            isShooting = true;
            theAnimator.SetBool("Is shooting right", true);
            theAnimator.SetBool("Was aiming is shooting", true);
            theAnimator.SetBool("Is aiming right", false);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            isShooting = false;
            theAnimator.SetBool("Is shooting right", false);
        }

        //Shooting down
        /*if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.D) && !isShooting)
        {
            theShootingManagerScript.ShootDown();
            isShooting = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            isShooting = false;
        }*/


        //Shooting left
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.D) && !isShooting)
        {
            theShootingManagerScript.ShootLeft();
            theAnimator.SetBool("Is shooting right", true);
            theAnimator.SetBool("Was aiming is shooting", true);
            theAnimator.SetBool("Is aiming right", false);
            isShooting = true;
            isFlipped = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            isShooting = false;
        }

        //Standing still
        if (Input.GetKeyDown(KeyCode.C))
        {
            isStandingStill = true;
            theRigidbody.velocity = new Vector2(theRigidbody.velocity.x, theRigidbody.velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            isStandingStill = false;
        }

    }

    IEnumerator timeBetweenBullet(int theSecondsToWait)
    {
        yield return new WaitForSeconds(theSecondsToWait);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Death barrier")
        {
            theSceneManagerScript.OnSwitch(1);
        }

        if (other.gameObject.tag == "The end")
        {
            theSceneManagerScript.OnSwitch(2);
        }

        if (other.gameObject.tag == "Enemy")
        {
            theSceneManagerScript.OnSwitch(1);
        }

    }

}
