using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	[SerializeField]
	GameObject _Explosion;

	// Update is called once per frame
	public virtual void Death () {
		Instantiate(_Explosion,transform);
		GameObject.Destroy(gameObject);
	}
}
