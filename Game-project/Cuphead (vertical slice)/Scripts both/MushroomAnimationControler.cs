using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAnimationControler : MonoBehaviour {

	[SerializeField]
	Animator animator;
	EnemyGeneralControl generalControl;

	private void Start()
	{
		generalControl = GetComponent<EnemyGeneralControl>();
	}



	public IEnumerator PlayIdle ()
	{
		animator.SetTrigger("SpringUp");
		yield return null;
	}

	public IEnumerator PlayAttack ()
	{
		animator.SetTrigger("Attack");
		yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
		print("Attack has ended");
		StartCoroutine(PlayIdle());
		generalControl.SwitchCurrentState("Idle");
		
	}

}
