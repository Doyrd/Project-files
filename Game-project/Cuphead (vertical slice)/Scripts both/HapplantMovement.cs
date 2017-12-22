using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapplantMovement : EnemyMovement {
	[SerializeField]
	float pointA;
	[SerializeField]
	float pointB;

	float pointAcurrent;
	float pointBcurrent;
	Vector3 raystart;

	enum Direction {Up, down}
	Direction currentdirection = Direction.down;

	// Use this for initialization
	void Start () {
		pointAcurrent = transform.position.y - pointA;
		pointBcurrent = transform.position.y + pointB;
		raystart = transform.position;
	}
	
	// Update is called once per frame
	public override void UseMovement () {
		Debug.DrawRay(raystart, Vector3.up * pointB);
		
		DesideDirection();
		switch (currentdirection)
		{
			case Direction.Up:
				transform.position += Vector3.up / 100 * GetWalkingSpeed();
				break;
			case Direction.down:
				transform.position += Vector3.down / 100 * GetWalkingSpeed();
				break;
			default:
				break;
		}
	}

	void DesideDirection()
	{
		if (transform.position.y <= pointAcurrent)
		{
			currentdirection = Direction.Up;
		}
		else if (transform.position.y >= pointBcurrent)
		{
			currentdirection = Direction.down;
		}
	}

	public float GetPoint(string point)
	{
		switch (point) {
			case "A":
				return pointAcurrent;
			case "B":
				return pointBcurrent;
			default:
				print("Error: Unkown point");
				return 0;
		}
	}
}
