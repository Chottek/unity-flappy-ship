using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour {

    private bool isClicked;

    void Update(){
       // Debug.Log(gameObject.name + ": " + isClicked);
    }

    private void OnMouseDown() {
        if(Input.GetMouseButtonDown(0)) {
            isClicked = true;
        }
    }

    private void OnMouseUp() {
        
    }
    
}
