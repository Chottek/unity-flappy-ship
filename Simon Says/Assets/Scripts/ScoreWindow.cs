using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour {

	private Text scoreText;

    private void Awake() {
		scoreText = transform.Find("ScoreText").GetComponent<Text>();
		scoreText.gameObject.SetActive(false);
	}

	private void Update(){
		if(GameBoard.GetInstance().GetGameMode() == GameMode.Arcade){
			scoreText.gameObject.SetActive(true);
			scoreText.text = GameBoard.GetInstance().GetScore().ToString();
		}
	}
}
