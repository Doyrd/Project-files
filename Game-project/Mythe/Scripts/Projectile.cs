using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    /// <summary> This script is meant for controlling everything related to the projectile. </summary> ///

    [Header("Float(s)")]
    [SerializeField]
    private float releaseTime = .05f;
    [SerializeField]
    private float maximumRatio = 1.5f;

    [Header("Component(s)")]
    private Rigidbody2D theRigidbody2DProjectile;
    private SpriteRenderer theSpriteRenderer;
    private SpringJoint2D theSpringJoint2D;

    [Header("Boolean(s)")]
    public bool isShot = false;
    private bool isPressed = false;
    private bool isRendering;

    [Header("Script(s)")]
    public Anchor theAnchorScript;
    public Instantiate theInstantiateScript;
    public Reload theReloadScript;
    public ReloadMechanic theReloadMechanicScript;
    public ColorChecking theColorCheckingScript;
    public AnimationHandler theAnimationHandlerScript;
    public Touch theTouchScript;

    [Header("Vector2(s)")]
    private Vector2 mousePosition;

    [Header("Game object(s)")]
    public GameObject theGameManager;
    public GameObject theAnimationObject;


    void Start()
    {
        theRigidbody2DProjectile = GetComponent<Rigidbody2D>();
        theSpringJoint2D = GetComponent<SpringJoint2D>();
        theSpriteRenderer = GetComponent<SpriteRenderer>();

        theGameManager = GameObject.FindGameObjectWithTag("GM");
        theAnimationObject = GameObject.Find("PB");
        theInstantiateScript = theGameManager.GetComponent<Instantiate>();
        theReloadScript = theGameManager.GetComponent<Reload>();
        theReloadMechanicScript = theGameManager.GetComponent<ReloadMechanic>();

        theColorCheckingScript = GetComponent<ColorChecking>();
        theAnimationHandlerScript = theAnimationObject.GetComponent<AnimationHandler>();

        theSpringJoint2D.frequency = 5f;

        /*CheckColor();*/
    }
	
	void Update()
    {
        if (isPressed && !isShot)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePosition, theAnchorScript.theRigidbody2DAnchor.position) > maximumRatio)
            {
                theRigidbody2DProjectile.position = theAnchorScript.theRigidbody2DAnchor.position + (mousePosition - theAnchorScript.theRigidbody2DAnchor.position).normalized * maximumRatio;
            }
            else
            {
                theRigidbody2DProjectile.position = mousePosition;
            }
        }

        CheckForOffScreen();
	}

    void OnMouseDown()
    {
        isPressed = true;
        theRigidbody2DProjectile.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        theRigidbody2DProjectile.isKinematic = false;

        isShot = true;
        StartCoroutine(ReleaseTheProjectile());
    }

    IEnumerator ReleaseTheProjectile()
    {
        yield return new WaitForSeconds(releaseTime);

        isShot = true;
        theSpringJoint2D.enabled = false;
    }

    private void CheckForOffScreen()
    {
        if (theSpriteRenderer.isVisible)
        {
            isRendering = true;
        }
        else if (isRendering && !theSpriteRenderer.isVisible)
        {
            OnDeath();
        }
    }

    IEnumerator WaitForAnimationEnding(float animationTime)
    {
        theAnimationHandlerScript.SetOffDeathAnimation();

        yield return new WaitForSeconds(animationTime);

        this.gameObject.SetActive(false);

        theReloadMechanicScript.ReloadProcess();
    }

    public void OnDeath()
    {
        StartCoroutine(WaitForAnimationEnding(1));
    }

}
