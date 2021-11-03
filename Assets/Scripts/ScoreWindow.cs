using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour {
   
	private Text scoreText;

	private void Awake() {
		scoreText = transform.Find("scoreText").GetComponent<Text>();
		scoreText.gameObject.SetActive(false);
	}

	private void Update() {
		if(Level.GetInstance().GetState() == Level.State.Playing){
			scoreText.gameObject.SetActive(true);
		}

		scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
	}

}
