using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour {

    [SerializeField]
    public int index;

    //seconds
    public float activeDuration = 1f;
    public float cooldownDuration = 0.2f;

    private void Awake(){
        extractIndexFromName();
    }

    public void OnMouseDown(){
        Debug.Log("Clicked!");
    }

    void Update(){
       
    }

    public int GetIndex(){
        return index;
    }

    private void extractIndexFromName(){
        index = int.Parse(gameObject.name.Split('_')[1]);
    }

    private void setActive(){
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(124, 252, 0, 255);
    }

    private void setInactive(){
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 250, 250, 255);
    }

   
    
}
