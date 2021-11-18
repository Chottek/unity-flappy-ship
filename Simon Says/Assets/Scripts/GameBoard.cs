using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    private const string GRID_NAME = "ButtonGrid";
    private const int GRID_SIZE = 9;

    [SerializeField]
    public int startSequenceLength = 1;

    [SerializeField]
    public float sequenceDelay = 0.5f;

    private int[] currentSequence;
    private int currentSequenceLength;
    private int playerClicks;
    private int nextIndexToCheck;

    public float buttonSequenceActiveDuration = 0.3f;
    public float buttonSequenceCooldownDuration = 0.1f;

    [SerializeField]
    private GameButton[] buttons;

    [SerializeField]
    private GameLight[] lights;
    private int lightsOn;

    private GameButton nextButton;

    private PlayerHandler playerHandler;

    private Difficulty difficulty;

    void Awake(){
        difficulty = Difficulty.Hard;
        CheckDifficulty();
        playerHandler = GetComponent<PlayerHandler>();

        playerHandler.SetCanClick(true); //change to false later! <- state before pressing start 
        playerHandler.SetCanType(false); //change to true later!

        buttons = GetComponentsInChildren<GameButton>();
        lights = GetComponentsInChildren<GameLight>();
    }

    private void CheckDifficulty(){
        switch(difficulty){
            case Difficulty.Easy:{
                buttonSequenceActiveDuration = 0.4f;
                buttonSequenceCooldownDuration = 0.2f;
                break;
            }
            case Difficulty.Medium:{
                buttonSequenceActiveDuration = 0.3f;
                buttonSequenceCooldownDuration = 0.1f;
                break;
            }
            case Difficulty.Hard:{
                buttonSequenceActiveDuration = 0.2f;
                buttonSequenceCooldownDuration = 0.05f;
                break;
            }
        }
    }

    private void Start() {
        StartGame();
    }

    private void GenerateSequence(){
        currentSequence = new int[currentSequenceLength];
        for (int i = 0; i < currentSequenceLength; i++){
           currentSequence[i] = Random.Range(0, buttons.Length);
        }
    }

    private void StartGame(){
        currentSequenceLength = startSequenceLength;
        lightsOn = 0;
        StartCoroutine(SequenceRoutine());
    }

    private IEnumerator SequenceRoutine(){
        yield return new WaitForSeconds(sequenceDelay);
        playerHandler.SetCanClick(false);
        GenerateSequence();

        for (int i = 0; i < currentSequenceLength; i++){
            nextButton = buttons[currentSequence[i]];
            yield return StartCoroutine(nextButton.PlayBlinkRoutine(buttonSequenceActiveDuration, buttonSequenceCooldownDuration));
        }

        StartCoroutine(PlayerResponseRoutine());
    }

    private IEnumerator PlayerResponseRoutine(){
        nextIndexToCheck = 0;
        playerClicks = 0;
        playerHandler.SetCanClick(true);

        while (playerClicks < currentSequenceLength){  yield return null; }

        ActivateNextLight();
        playerHandler.SetCanClick(false);
        IncrementSequenceLength();
        StartCoroutine(SequenceRoutine());
    }

    public void HandleClick(int buttonIndex){
        playerClicks++;

        if (currentSequence[nextIndexToCheck] == buttonIndex){
            nextIndexToCheck++;
        } else {
            StopAllCoroutines();
            playerHandler.SetCanType(true);
            playerHandler.SetCanClick(false);
        }
    }

    private void ActivateNextLight(){
        lights[lightsOn].SetActive();
        lightsOn++;
    }

    private void DeactivateLights(){
        foreach(GameLight g in lights){
            g.SetInactive();
        }
        lightsOn = 0;
    }

    private void IncrementSequenceLength(){
        currentSequenceLength++;
    }

}
