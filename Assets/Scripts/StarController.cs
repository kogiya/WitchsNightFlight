/*
 * StarController by Kie Ogiya
 * Program description: Control the action of the star
 * 
 * Code Source: COMP3064 Game Programming Week 2 by Przemyslaw Pawluk
 * Texture Source:(star)http://www.clker.com/cliparts/f/9/8/1/1216181106356570529jean_vector_balin_icon_star.svg.med.png
 * 
 * Last Modified by Kie Ogiya
 * Last Modified Date : October 13, 2017
 * Revision History:
 * Stars disappear when the witch hits them.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {
	//Public variables
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;
	[SerializeField]
	private float bottomY = -298;
	[SerializeField]
	private float topY = 1028;

	//private variables
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset();
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;

		//move with sky to the left
		_currentPos -= new Vector2(speed, 0);

		//check if we need to reset
		if(_currentPos.x < endX){
			//reset
			Reset();
		}

		//apply changes
		_transform.position = _currentPos;
	}

	public void Reset(){
		float y = Random.Range (bottomY, topY);
		float dx = Random.Range (0, 300);// interval between stars
		_currentPos = new Vector2 (startX + dx, y);
		_transform.position = _currentPos;//disappear from screan
	}
}
