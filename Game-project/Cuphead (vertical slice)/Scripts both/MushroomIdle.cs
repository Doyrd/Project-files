using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomIdle : EnemyIdle {

	bool playerHasBeenSeen = false;
	GameObject _Player;
	[SerializeField]
	MushroomAnimationControler mushroomAnimationControler;
	EnemyGeneralControl enemyGeneral;
	Animator anim;


	[SerializeField]
	float range;
	[SerializeField]
	float timer = 1;
	float waittimer = 0;
	bool wait = false;

	// Use this for initialization
	void Start () {
		_Player = GameObject.FindGameObjectWithTag("Player");
		enemyGeneral = GetComponent<EnemyGeneralControl>();
		mushroomAnimationControler = GetComponent<MushroomAnimationControler>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	public override void Idle()
	{
		if (_Player.transform.position.x <= transform.position.x + 10 && _Player.transform.position.x >= transform.position.x - 10)
		{

			if (!playerHasBeenSeen)
			{
				StartCoroutine(mushroomAnimationControler.PlayIdle());
				playerHasBeenSeen = true;
				StartCoroutine(Wait());
			}
		}

		if (_Player.transform.position.x <= transform.position.x + range && _Player.transform.position.x >= transform.position.x - range)
		{
			if (_Player.transform.position.x >= transform.position.x)
			{
				GetComponent<SpriteRenderer>().flipX = true;
			}
			else
			{
				GetComponent<SpriteRenderer>().flipX = false;
			}

			if (!wait && playerHasBeenSeen)
			{
				StartCoroutine(Wait());
				enemyGeneral.SwitchCurrentState("Attack");
				
			}
		}

	}

	void HadBeenSeen(bool hasbeenseen)
	{
		playerHasBeenSeen = hasbeenseen;
	}


	IEnumerator Wait()
	{
		wait = true;
		yield return new WaitForSeconds(timer);
		wait = false;
	}
}
