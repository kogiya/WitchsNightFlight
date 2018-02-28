/*
 * SkyController by Kie Ogiya
 * Program description: Control the movement of the background (sky)
 * 
 * Code Source: COMP3064 Game Programming Week 2 by Przemyslaw Pawluk
 * Texture Source:(sky)Free 2D Adventure Beach Background from Unity Asset Stroe
 * 
 * Last Modified by Kie Ogiya
 * Last Modified Date : October 10, 2017
 * Revision History:
 * Sky moves from left to right.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour {
	//public variables
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;

	//private variables
	private Transform _transform; //translation(position), rotation(orientation), scale(size)
	private Vector2 _currentPos; //current position X and Y

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;

		//move sky to the left
		_currentPos -= new Vector2 (speed, 0);

		//check if we need to reset
		if (_currentPos.x < endX) {
			//reset
			Reset ();
		}

		//apply changes
		_transform.position = _currentPos;
	}


	private void Reset (){
		_currentPos = new Vector2 (startX, 0);
		
	}
}
