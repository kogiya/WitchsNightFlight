/*
 * WitchController by Kie Ogiya
 * Program description: Control the movement of the player (witch)
 * 
 * Code Source: COMP3064 Game Programming Week 2 by Przemyslaw Pawluk
 * Texture Source:(Witch)http://1.bp.blogspot.com/-dxo-mpRG9ag/UT10KQmp65l/AAAAAAAAOsc/etpq6_i2has/s1600/fantasy_witch.png
 * 
 * Last Modified by Kie Ogiya
 * Last Modified Date : October 14, 2017
 * Revision History:
 * Add movement of witch.
 * Enabled standard key (WASD) for player movement 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchController : MonoBehaviour {
	[SerializeField]
	private float speed = 7f;
	[SerializeField]
	private float topY;
	[SerializeField]
	private float bottomY;

	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//get current position
		_currentPos = _transform.position;

		float userInput = Input.GetAxis ("Vertical");//enable to use standard key(WASD) for player movement 

		//if UpArrow is pressed move up
		//if(Input.GetKey(KeyCode.UpArrow)){
		if(userInput>0){
			_currentPos += new Vector2 (0, speed);
		}
		//if DownArrow is pressed move down
		//if(Input.GetKey(KeyCode.DownArrow)){4
		if(userInput<0){
			_currentPos -= new Vector2 (0, speed);
		}

		CheckBounds ();

		_transform.position = _currentPos;
	}

	//check boundary of witch
	private void CheckBounds(){
		if (_currentPos.y > topY) {
			_currentPos.y = topY;
		}
		if (_currentPos.y < bottomY) {
			_currentPos.y = bottomY;
		}
	}
}
