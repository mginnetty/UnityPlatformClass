using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    private Animator anim;
    private int health = 1;

    private bool canDamage;

    void Awake() {
        anim = GetComponent<Animator>();
        canDamage = true;
        
    }

    IEnumerator WaitForDamage() {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    void OnTriggerEnter2D(Collider2D target) {
        print("Ouch");
        if (canDamage) {
            if (target.tag == MyTags.BULLET_TAG) {
                 health--;
                  canDamage = false;
                  if (health == 0) {
                      GetComponent<BossScript>().DeactivateBossScript();
                      anim.Play("BossDead");
                                            
                  }

                  StartCoroutine(WaitForDamage());
            } 
        }
       
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
} // BossHealth
