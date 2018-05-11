using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    /// <summary> This script is meant for handeling the animations. </summary>

    private  Animator theAnimator;

    void Start()
    {

        theAnimator = GetComponent<Animator>();

        theAnimator.enabled = false;
    }

    void Update()
    {
        TestAnimation();
    }

    public void SetOffDeathAnimation()
    {
        theAnimator.enabled = true;
        
        /*theAnimator.SetTrigger("onDeath");*/
    }

    private void TestAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SetOffDeathAnimation();
        }
    }
   
    // Stopping animation by disabeling loop.

}
