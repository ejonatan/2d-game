using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public Rigidbody2D player;
    public int health = 3;

    bool onGround = false;

    public SpriteRenderer image;
    public Animator animator;

    void Update() {
    	if ( onGround && Input.GetButtonDown ("Vertical") ) {
    		player.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
    	}

    	if ( health <= 0 ) {
    		print("player died");
    	}

    	if ( onGround && Input.GetButtonDown ("FeedButton") ) {
    		Feed();
    	}
    }

    void FixedUpdate() {
        float move = Input.GetAxis ("Horizontal");
        player.velocity = new Vector2 (move * speed, player.velocity.y);

        if ( move != 0 ) {
        	animator.SetBool( "Run", true );
        }
        else {
        	animator.SetBool( "Run", false );
        }

        if ( move > 0 ) {
			image.transform.localRotation = Quaternion.identity;
		}
		else if ( move < 0 ) {
			image.transform.localRotation = Quaternion.Euler( 0f, 180f, 0f );
		}
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if ( collision.gameObject.tag == "Enemy" ) {
            health -= 1;
            print(health);
        }

        if ( collision.gameObject.tag == "Ground" && collision.gameObject.transform.position.y <= transform.position.y ) {
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            onGround = false;
        }

    }

    void Feed() {
    }
}
