using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour {

	public DeathTimer sugar;
	public float sugarSpawnDist;

	public int maxSugars;

	public List<DeathTimer> sugars = new List<DeathTimer>();
	
	void Update () {
		if( Input.GetButtonDown("FeedButton") ) {
			if( sugars.Count > maxSugars ) return;
			
			DeathTimer newSugar = Instantiate<DeathTimer>( sugar );
			newSugar.transform.position = transform.position + transform.right * sugarSpawnDist;
			sugars.Add( newSugar );
			newSugar.owner = this;
		}
	}

	public void SugarDestroyed( DeathTimer dyingSugar ) {
		sugars.Remove( dyingSugar );
	}
}
