using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour {

    //[SerializeField] private Camera mainCamera;

    private bool canClick;
    private bool isMouseDown;

    void Update() {

        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButtonDown(0)) {
            // Debug.Log("Mouse Btn Down!");
            //Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if(hit.collider != null){
                Debug.Log(hit.collider.gameObject.name);
            }
        }
        
    }
}
