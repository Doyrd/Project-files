using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGuyDeath : EnemyDeath {

	Animator anim;
	BlueGuyMovement blueGuyMovement;
	EnemyGeneralControl generalControl;
	ManageHealth manageHealth;
	bool death = false;

	[SerializeField]
	float timer;

	private void Start()
	{
		anim = GetComponent<Animator>();
		blueGuyMovement = GetComponent<BlueGuyMovement>();
		generalControl = GetComponent<EnemyGeneralControl>();
		manageHealth = GetComponent<ManageHealth>();
	}

	public override void Death () {
		if (!death)
		{
			StartCoroutine(Timer());
		}
	}

	IEnumerator Timer()
	{
		anim.SetTrigger("Death");
		blueGuyMovement.enabled = false;
		death = true;
		yield return new WaitForSeconds(timer);
		death = false;
		blueGuyMovement.enabled = true;
		anim.SetTrigger("UnDeath");
		generalControl.SwitchCurrentState("Moving");
		manageHealth.SetHealth(1);
	}
}
