using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	[SerializeField]
	int damage;

	public virtual void Attack()
	{
			print("Attacks");
	}
}
