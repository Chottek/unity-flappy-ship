using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
 
    private const float JUMP_AMOUNT = 100f;

    private static Ship instance;

    public static Ship GetInstance() {
        return instance;
    }

    public event EventHandler OnDeath;

    private Rigidbody2D shipRigidbody2D;

    private void Awake() {
        instance = this;
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

    private void OnTriggerEnter2D(Collider2D collider) {
        shipRigidbody2D.bodyType = RigidbodyType2D.Static;
        if (OnDeath != null) {
            OnDeath(this, EventArgs.Empty);
        }
    }
}
