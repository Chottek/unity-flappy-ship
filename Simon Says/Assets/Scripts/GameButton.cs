using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour {

    [SerializeField]
    public int index;

    [SerializeField]
    public GameBoard gameBoard;

    private Color32 activeColor = new Color32(124, 252, 0, 255);
    private Color32 inactiveColor = new Color32(41, 41, 41, 255);
    private Color32 errorColor = new Color32(255, 0, 0, 255);

    private void Awake(){
        ExtractIndexFromName();

        gameBoard = GetComponentInParent<GameBoard>();
    }

    void Update(){
       
    }

    public IEnumerator PlayBlinkRoutine(float active, float cooldown){
        SetActive();
        yield return new WaitForSeconds(active);
        SetInactive();
        yield return new WaitForSeconds(cooldown);
    }

    public IEnumerator PlayErrorRoutine(){
        SetWronglyActive();
        yield return new WaitForSeconds(0.3f);
        SetInactive();
        yield return new WaitForSeconds(0.3f);
    }

    public void PlayerClick(){
        StartCoroutine(PlayBlinkRoutine(0.1f, 0.1f));
        gameBoard.HandleClick(index);
    }

    public int GetIndex(){
        return index;
    }

    private void ExtractIndexFromName(){
        index = int.Parse(gameObject.name.Split('_')[1]);
    }

    private void SetActive(){
        gameObject.GetComponent<SpriteRenderer>().color = activeColor;
    }

    private void SetWronglyActive(){
        gameObject.GetComponent<SpriteRenderer>().color = errorColor;
    }

    private void SetInactive(){
        gameObject.GetComponent<SpriteRenderer>().color = inactiveColor;
    }

   
    
}
