using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    private const float JUMP_AMOUNT = 100f;
    private Rigidbody2D shipRigidbody2D;

    private void Awake() {
         shipRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
            Jump();
        }
    }

    private void Jump() {
        shipRigidbody2D.velocity = Vector2.up * JUMP_AMOUNT;
    }
}
