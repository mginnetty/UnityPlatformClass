using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreScript : MonoBehaviour {

 [SerializeField] TMP_Text coinTextScore;
 private AudioSource audioManager;
 private int scoreCount;

 void Awake() {
  audioManager = GetComponent<AudioSource> ();
 }

 void Start () {
 
  
 }

 public void BonusBlock() {
  scoreCount = scoreCount + 10;
  coinTextScore.text = "x" + scoreCount;
 }
 
 
 void OnTriggerEnter2D(Collider2D target) {
  if (target.tag == MyTags.COIN_TAG) {
			
   target.gameObject.SetActive (false);
   scoreCount++;

   coinTextScore.text = "x" + scoreCount;

   audioManager.Play ();
  }
 }

} // class

