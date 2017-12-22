using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGuyMovement : EnemyMovement {
	[SerializeField]
	float pointA;
	[SerializeField]
	float pointB;

	float pointAcurrent;
	float pointBcurrent;

	Vector3 raystart;

	enum Direction {Left, Right};
	Direction currentdirection = Direction.Right;

	void Start()
	{
		pointAcurrent = transform.position.x - pointA;
		pointBcurrent = transform.position.x + pointB;
		raystart = new Vector3(pointAcurrent, transform.position.y);
	}

	public override void UseMovement()
	{
		raystart.y = transform.position.y;
		Debug.DrawRay(raystart, Vector3.right * (pointB + pointA));
		DesideDirection();
			switch (currentdirection)
			{
				case Direction.Left:
					transform.position += Vector3.left / 100 * GetWalkingSpeed();
					break;
				case Direction.Right:
					transform.position += Vector3.right / 100 * GetWalkingSpeed();
					break;
				default:
					break;
			}
		
	}

	void DesideDirection()
	{
		if (transform.position.x <= pointAcurrent)
		{
			currentdirection = Direction.Right;
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Collider2D>().offset = new Vector2(-0.3243543f, -0.6828508f);
		}
		else if (transform.position.x >= pointBcurrent)
		{
			currentdirection = Direction.Left;
			GetComponent<SpriteRenderer>().flipX = true;
			GetComponent<Collider2D>().offset = new Vector2(0.290211f, -0.6828508f);
		}
	}
}
