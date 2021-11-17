using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    private const string GRID_NAME = "ButtonGrid";
    private const int GRID_SIZE = 9;

    [SerializeField]
    public int startSequenceLength = 1;

    [SerializeField]
    public float sequenceDelay = 1f;

    private int[] currentSequence;
    private int currentSequenceLength;

    [SerializeField]
    private List<GameButton> buttons;

    private PlayerHandler playerHandler;

    void Awake(){
        playerHandler = GetComponent<PlayerHandler>();

        playerHandler.SetCanClick(true); //change to false later! <- state before pressing start 
        playerHandler.SetCanType(false); //change to true later!

       
        Debug.Log("Buttons size: " + buttons.Count);
    }

}
