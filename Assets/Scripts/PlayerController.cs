using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public Rigidbody2D player;
    public int health = 3;

    bool facingRight = true;
    bool onGround = false;

    Animator animator = ;

    void Update()
    {
    	if (onGround && Input.GetButtonDown ("Vertical")) {
    		player.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
    	}

    	if (health <= 0) {
    		print("player died");
    	}

    	if (onGround && Input.GetButtonDown ("FeedButton")) {
    		Feed();
    	}
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis ("Horizontal");
        player.velocity = new Vector2 (move * speed, player.velocity.y);

        if (move != 0) {

        }

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
            health -= 1;
            print(health);
        }

        if (collision.gameObject.tag == "Ground" && collision.gameObject.transform.position.y <= transform.position.y) {
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            onGround = false;
        }

    }

    void Feed() {
    	Instantiate(Sugar)
    }
}
