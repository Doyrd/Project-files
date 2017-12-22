using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAttack : EnemyAttack {

	Animator anim;

	EnemyGeneralControl enemyGeneral;
	MushroomAnimationControler animationControler;

	[SerializeField]
	GameObject projectile;
	GameObject player;

	float offset;

	bool shootoffsettimer = false;

	void Start()
	{
		enemyGeneral = GetComponent<EnemyGeneralControl>();
		animationControler = GetComponent<MushroomAnimationControler>();
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public override void Attack()
	{
		if (transform.position.x >= player.transform.position.x)
		{
			offset = -0.07f;
		}
		else
		{
			offset = 0.07f;
		}

		if (!shootoffsettimer)
		{
			StartCoroutine(Shoot());
		}
	}


	IEnumerator Shoot()
	{
		shootoffsettimer = true;
		StartCoroutine(animationControler.PlayAttack());
		yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length - 0.2f);
		Instantiate(projectile,new Vector3(transform.position.x + offset,transform.position.y + 0.4f),transform.rotation);
		yield return new WaitForSeconds(0.35f);
		shootoffsettimer = false;
	}
}
