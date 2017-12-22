using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour {

	GameObject _Target;
	[SerializeField]
	float speed;
	float Xpos;
	float Ypos;
	float rotationangle;

	// Use this for initialization
	void Awake () {
		_Target = GameObject.FindGameObjectWithTag("Player");
		Quaternion rotation = Quaternion.LookRotation(_Target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
		rotationangle = transform.rotation.z;
		StartCoroutine(Kill());
	}
	
	// Update is called once per frame
	void Update () {
		

		if (rotationangle >= 0 && rotationangle < 0.225)
		{
			Xpos = speed;
			Ypos = 0;
		}

		if (rotationangle >= 0.225 && rotationangle < 0.45)
		{
			
			Xpos = speed / 4 * 3;
			Ypos = speed / 4 * 2;
		}

		if (rotationangle >= 0.45 && rotationangle < 0.675)
		{
			Xpos = speed / 4 * 2;
			Ypos = speed / 4 * 3;
		}

		if (rotationangle >= 0.675 && rotationangle < 0.90)
		{
			Xpos = 0;
			Ypos = speed;
		}




		if (rotationangle >= -0.90 && rotationangle < -0.675)
		{
			Xpos = 0;
			Ypos = speed;
		}

		if (rotationangle >= -0.675 && rotationangle < -0.45)
		{
			Xpos = -speed / 4 * 2;
			Ypos = speed / 4 * 3;
		}

		if (rotationangle >= -0.45 && rotationangle < -0.225)
		{
			Xpos = -speed / 4 * 3;
			Ypos = speed / 4 * 2;
		}

		if (rotationangle >= -0.225 && rotationangle < -0.000000001)
		{
			Xpos = -speed;
			Ypos = 0;
		}

		transform.position = new Vector3(transform.position.x + Xpos, transform.position.y + Ypos);
	}

	IEnumerator Kill()
	{
		yield return new WaitForSeconds(6);
		GameObject.Destroy(gameObject);
	}
}
