/*
 * GameController by Kie Ogiya
 * Program description: Control the UI
 * 
 * Code Source: COMP3064 Game Programming Week 5 by Przemyslaw Pawluk
 * Texture Source:(Witch)1.bp.blogspot.com/-dxo-mpRG9ag/UT10KQmp65l/AAAAAAAAOsc/etpq6_i2has/s1600/fantasy_witch.png
 * 
 * Last Modified by Kie Ogiya
 * Last Modified Date : October 10, 2017
 * Revision History:
 * Add UI control.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	[SerializeField]
	Text lblScore;
	[SerializeField]
	Text lblLife;
	[SerializeField]
	Text lblGameOver;
	[SerializeField]
	Text lblHighScore;
	[SerializeField]
	Button btnReset;

	private int _score = 0;
	private int _life = 5;

	public int Score{
		get{ return _score; }
		set{
			_score = value;
			//update UI
			lblScore.text = "Score: " + _score;
		}
	}

	public int Life {
		get{ return _life; }
		set {
			_life = value; 
			if (_life <= 0) {
				//set Game over
				gameOver();
			}else{
				//update UI
				lblLife.text = "Life: " + _life;
			}
		}
	}
		
	private void initialize(){
		//set initial value
		Score = 0;
		Life = 5;

		//disappear lblGameOver, lblHighScore, btnReset from the screen
		lblGameOver.gameObject.SetActive (false);
		lblHighScore.gameObject.SetActive (false);
		btnReset.gameObject.SetActive (false);

		//show lblScore, lblLife to the screen
		lblScore.gameObject.SetActive(true);
		lblLife.gameObject.SetActive (true);
	}

	private void gameOver(){
		//final score
		lblHighScore.text = "Your score: " + _score;
			
		//show lblGameOver, lblHighScore, btnReset to the screen
		lblGameOver.gameObject.SetActive (true);
		lblHighScore.gameObject.SetActive (true);
		btnReset.gameObject.SetActive (true);

		//disappear lblScore, lblLife to the screen
		lblScore.gameObject.SetActive(false);
		lblLife.gameObject.SetActive (false);
	
	}

	// Use this for initialization
	void Start () {
		initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//reset button
	public void btnResetClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}
