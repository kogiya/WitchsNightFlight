/*
 * EnemmyController by Kie Ogiya
 * Program description: Control the movement of the enemy (tornado and bat)
 * 
 * Code Source: COMP3064 Game Programming Week 5 by Przemyslaw Pawluk
 * Texture Source:(Tornado)http://www.clipartlord.com/wp-content/uploads/2015/11/tornado4.png
 * Texture Source:(bat)http://frame-illust.com/fi/wp-content/uploads/2015/08/cd5c57c0948affe55c78c0e710b87006.png
 * 
 * Last Modified by Kie Ogiya
 * Last Modified Date : October 10, 2017
 * Revision History:
 * Add movement of enemy.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	[SerializeField]
	float minXSpeed = 5f;
	[SerializeField]
	float maxXSpeed = 10f;
	[SerializeField]
	float minYSpeed = -2f;
	[SerializeField]
	float maxYSpeed = 2f;
	[SerializeField]
	float bottomYRange = -136; //this value for tornado
	[SerializeField]
	float topYRange = 874; //this value for tornado
	[SerializeField]
	float frequency = -1344;//less frequency should be smaller than -1344
							//cannot be more than -1344

	private Transform _transform;
	private Vector2 _currentSpeed;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset();
	}

	public void Reset(){
		float ySpeed = Random.Range (minYSpeed, maxYSpeed);
		float xSpeed = Random.Range (minXSpeed, maxXSpeed);

		_currentSpeed = new Vector2 (xSpeed, ySpeed);

		float y = Random.Range (bottomYRange, topYRange);//change value depend on the enemy object
		_transform.position = new Vector2 (1356 + Random.Range (0, 100), y);

	}

	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= _currentSpeed;
		_transform.position = _currentPos;

		if (_currentPos.x <= frequency) {//frequency is value of end of left side
			Reset ();
		}
	}
}
