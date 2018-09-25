using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public Rigidbody2D player;
    bool facingRight = true;

    // I took this from a Youtube tutorial because I couldn't figure out the exit/enter colliders :}
    bool onGround = false;

    void Update()
    {
    	if (onGround && Input.GetButtonDown ("Vertical")) {
    		player.AddForce(new Vector2(0, jumpPower));
    	}
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis ("Horizontal");
        player.velocity = new Vector2 (move * speed, player.velocity.y);


        if( move > 0 && !facingRight ) {
        	Flip();
        }
        else if( move < 0 && facingRight ) {
        	Flip();
        }
    }

    void Flip() {
    	facingRight = !facingRight;
    	Vector3 theScale = transform.localScale;
    	theScale.x *= -1;
    	transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.SendMessage("ApplyDamage", 10);
        }

        if (collision.gameObject.tag == "Ground" && collision.gameObject.transform.position.y <= transform.position.y) {
            onGround = true;
        }

    }

    // I have to eventually add the E-press control to "feed" enemies...
}
