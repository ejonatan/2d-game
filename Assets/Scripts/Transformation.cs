using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour {

	public Transform enemySelf;
	public Transform transformedVersion;

	void OnCollisionEnter2D(Collision2D collision) {
        if ( collision.gameObject.tag == "Sugar" ) {
        	Vector2 pos = enemySelf.position;
            Destroy( this.gameObject );
            Transform newSelf = Instantiate<Transform>( transformedVersion );
            newSelf.position = pos;
        }
    }

}
