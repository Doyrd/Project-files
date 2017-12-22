using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDuration : MonoBehaviour {

	[SerializeField]
	Animator anim;

	[SerializeField]
	float timer;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Awake () {
		StartCoroutine(Timer());
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length - timer);
		GameObject.Destroy(gameObject);
	}
}
