using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour {

	public float lifetime;
	float currentLife;

	public Feed owner;

	void Update () {
		currentLife += Time.deltaTime;

		if( currentLife > lifetime ) {
			Destroy( this.gameObject );
			owner.SugarDestroyed( this );
		}
	}
}
