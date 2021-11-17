using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {

    private bool canClick;
    private bool canType;
    private bool isMouseDown;

    void Update() {
        if (canClick && Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if(hit.collider != null){
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color32(124, 252, 0, 255);
            }
        }
    }

    public void SetCanClick(bool can){
        this.canClick = can;
    }

    public void SetCanType(bool can){
        this.canType = can;
    }
}
