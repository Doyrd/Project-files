using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageHealth : MonoBehaviour {

	EnemyGeneralControl generalControl;

	[SerializeField]
	int health;

	[SerializeField]
	float invincibilityframetimer;



	bool invincible = false;

	private void Start ()
	{
		generalControl = GetComponent<EnemyGeneralControl>();
	}

	private void Update ()
	{
		if (health <= 0)
		{
			generalControl.SwitchCurrentState("Death");
		}
	}

	public void DamageHealth (int damage)
	{
		health -= damage;
		StartCoroutine(Timer());
	}

	public float GetHealth ()
	{
		return health;
	}

	public void SetHealth(int points) {
		health = points;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "bullet")
		{
			if (!invincible) {
				DamageHealth(1);
			}
			
		}
	}


	IEnumerator Timer()
	{
		invincible = true;
		yield return new WaitForSeconds(invincibilityframetimer);
		invincible = false;
	}
}
