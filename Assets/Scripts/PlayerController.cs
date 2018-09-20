using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public Rigidbody2D player;

    // I took this from a Youtube tutorial because I couldn't figure out the exit/enter colliders :}
    bool onGround = false;
    public Transform checkGround;
    float groundRadius = 0.2f;
    public LayerMask itemsThatAreGround;

    void Update()
    {
    	if (onGround && Input.GetButtonDown ("Vertical")) {
    		player.AddForce(new Vector2(0, jumpPower));
    	}
    }

    void FixedUpdate()
    {

    	onGround = Physics2D.OverlapCircle(checkGround.position, groundRadius, itemsThatAreGround);


        float move = Input.GetAxis ("Horizontal");
        player.velocity = new Vector2 (move * speed, player.velocity.y);

    }

    // I have to eventually add the E-press control to "feed" enemies...
}
