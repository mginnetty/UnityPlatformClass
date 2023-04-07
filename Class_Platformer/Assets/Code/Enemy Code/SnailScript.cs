using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;

    private bool moveLeft;

    public Transform down_Collision;


    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    
    void Start() {
        moveLeft = true;
    }

    
    void Update() {
        if (moveLeft) {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        } else {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }
        
        CheckCollision();
        
    } // Update

    void CheckCollision() {
        if (!Physics2D.Raycast(down_Collision.position, Vector2.down, 0.1f)) {
            ChangeDirection();
        }
    }//CheckCollision

    void ChangeDirection() {
        moveLeft = !moveLeft;
        Vector3 tempscale = transform.localScale;
        if (moveLeft) {
            tempscale.x = Mathf.Abs(tempscale.x);
        } else {
            tempscale.x = -Math.Abs(tempscale.x);
        }

        transform.localScale = tempscale;
    }//ChangeDirection



 
} //  SnailScript

