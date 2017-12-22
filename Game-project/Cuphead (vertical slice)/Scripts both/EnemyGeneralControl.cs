using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneralControl : MonoBehaviour {

	enum EnemyState { Idle, Moving, Death, Hurt, Attack, Falling }
	[SerializeField]
	EnemyState currentState = EnemyState.Idle;

	[SerializeField]
	EnemyAttack enemyAttack;
	[SerializeField]
	EnemyMovement enemyMovement;
	[SerializeField]
	EnemyIdle enemyIdle;
	[SerializeField]
	EnemyDeath enemyDeath;

	[SerializeField]
	bool canAttack;
	[SerializeField]
	bool canMove = true;
	[SerializeField]
	bool canIdle;

	void Start()
	{
		if (enemyAttack == null) { canAttack = false; } else { canAttack = true; }
		if (enemyMovement == null) { canMove = false; } else { canMove = true; }
		if (enemyIdle == null) { canIdle = false; } else { canIdle = true; }
		enemyDeath = GetComponent<EnemyDeath>();
	}

	void Update()
	{


		switch (currentState)
		{
			case EnemyState.Idle:
				if (canIdle)
				{
					enemyIdle.Idle();
				}
				else
				{
					SwitchCurrentState("Moving");
				}
				break;
			case EnemyState.Moving:
				if (canMove)
				{
					enemyMovement.UseMovement();
				}
				else
				{
					SwitchCurrentState("Idle");
				}
				break;
			case EnemyState.Death:
				enemyDeath.Death();
				break;
			case EnemyState.Hurt:
				break;
			case EnemyState.Attack:
				if (canAttack)
				{
					enemyAttack.Attack();
				}
				else
				{
					SwitchCurrentState("Moving");
				}
				
				break;
			case EnemyState.Falling:

				break;
			default:
				break;
		}
	}

	public void SwitchCurrentState(string newCurrentState)
	{
		switch (newCurrentState)
		{
			case "Idle":
				if (canIdle)
				{
					currentState = EnemyState.Idle;
				}
				else
				{
					print("Error: This Enemy can't idle");
				}
				break;
			case "Attack":
				if (canAttack)
				{
					currentState = EnemyState.Attack;
				}
				else
				{
					print("Error: This Enemy can't Attack");
				}
				break;
			case "Moving":
				if (canMove)
				{
					currentState = EnemyState.Moving;
				}
				else
				{
					print("Error: " + gameObject.name + " Enemy can't move");
				}
				break;
			case "Hurt":
				currentState = EnemyState.Hurt;
				break;
			case "Death":
				currentState = EnemyState.Death;
				break;
			case "Falling":

				break;
		}


	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//print(gameObject.name + ": Has been hit be " + collision.gameObject.name);
		switch (collision.gameObject.tag)
		{
			case "PlayerBullet":
				gameObject.GetComponent<ManageHealth>().DamageHealth(1);
				break;
		}
	}
}
