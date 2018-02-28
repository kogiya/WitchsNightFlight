/*
 * WitchCollider by Kie Ogiya
 * Program description: Control the action that relates to the player collision (witch)
 * 
 * Code Source: COMP3064 Game Programming Week 2 by Przemyslaw Pawluk
 * Texture Source:(Witch)1.bp.blogspot.com/-dxo-mpRG9ag/UT10KQmp65l/AAAAAAAAOsc/etpq6_i2has/s1600/fantasy_witch.png
 * Audio Source:Score and Time from Unity Asset Store, Sound Pack from Unity Asset Store
 * 
 * Last Modified by Kie Ogiya
 * Last Modified Date : October 13, 2017
 * Revision History:
 * Add action of star and enemy when the witch hits them.
 * Add sound effect when witch hits star and enemy.
 * Add scoring and life management system.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchCollider : MonoBehaviour {
	[SerializeField]
	GameController gameController;

	private AudioSource _starSound;
	private AudioSource _enemySound;

	// Use this for initialization
	void Start () {
		//store 2 audio sources
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		_starSound = audioSources[0];
		_enemySound = audioSources[1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag.Equals("star")){
			//display "Collision star" in Console when which hits star
			Debug.Log ("Collision star\n"); 

			//when the witch hits star, it makes sound
			if (_starSound != null) {
				_starSound.Play ();
			}

			//when the which hits star, it disappears.
			other.gameObject.GetComponent<StarController> ().Reset ();

			//add points
			gameController.Score += 100;

		}else if(other.gameObject.tag.Equals("enemy")){
			//display "Collision star" in Console when which hits ememy
			Debug.Log ("Collision enemy\n");
			if (_enemySound != null) {
				_enemySound.Play ();
			}

			//when the enemy hits witch, it disappears
			other.gameObject.GetComponent<EnemyController> ().Reset ();

			//loose life
			gameController.Life -= 1;
		}
			
	}
}
