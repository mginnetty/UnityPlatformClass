using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour {
    private Animator anim;
    private bool animation_Started, animation_Finished;
    private bool jumpLeft = true;
    private int timesJumped;
    private string coroutine_Name = "FrogJump";
    private GameObject player;

    public LayerMask playerLayer;
    


    void Awake() {
        anim = GetComponent<Animator>();
        
        
    }

    void Start() {
        StartCoroutine(coroutine_Name);
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
    }

    void Update() {
        if (Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer)) {
            player.GetComponent<PlayerDamage>().DealDamage();
        }
    }    

    
    void LateUpdate() {
        if (animation_Finished && animation_Started) {
            animation_Started = false;
            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }


    IEnumerator FrogJump() {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        animation_Started = true;
        animation_Finished = false;

        timesJumped++;
        
        if (jumpLeft) {
            anim.Play("FrogJumpLeft");
        } else {
            anim.Play("FrogJumpRight");   
        }

        StartCoroutine(coroutine_Name);
        
    }

    void AnimationFinished() {
        animation_Finished = true;

        if (jumpLeft) {
            anim.Play("FrogIdleLeft");
        } else {
            anim.Play("FrogIdleRight");
        }
        

        if (timesJumped == 3) {
            timesJumped = 0;
            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1;
            transform.localScale = tempScale;
            jumpLeft = !jumpLeft;

        }
        
    }
    
}  // FrogScript
