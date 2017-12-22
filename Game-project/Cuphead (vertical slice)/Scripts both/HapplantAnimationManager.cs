using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapplantAnimationManager : MonoBehaviour {

	HapplantMovement happlantMovement;

	[SerializeField]
	Animator anim;
	[SerializeField]
	Animation test;


	[SerializeField]
	float animwaitingtime;

	[SerializeField]
	float animationstartlocation;

	bool animationbool;

	bool wait = false;

	// Use this for initialization
	void Start()
	{
		happlantMovement = GetComponent<HapplantMovement>();
	}

	// Update is called once per frame
	void Update()
	{
		if (animationbool && !wait)
		{
			StartCoroutine(StartAnimation());
		}

		if (transform.position.y >= happlantMovement.GetPoint("B") - animationstartlocation) {
			animationbool = true;
		}
		else if (transform.position.y <= happlantMovement.GetPoint("A"))
		{
			animationbool = false;
		}


	}


	IEnumerator StartAnimation() {;
		anim.SetTrigger("Hap");
		wait = true;
		yield return new WaitForSeconds(5f);
		wait = false;
	}
}
