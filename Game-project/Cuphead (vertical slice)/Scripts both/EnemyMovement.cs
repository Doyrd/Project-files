using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	[SerializeField]
	float gravity;
	[SerializeField]
	float walkingspeed;
	//[SerializeField]



	public virtual void UseMovement()
	{


	}

	void UseGravity()
	{
		GetComponent<Rigidbody2D>().gravityScale = gravity;
	}

	public float GetWalkingSpeed()
	{
		return walkingspeed;
	}



}
