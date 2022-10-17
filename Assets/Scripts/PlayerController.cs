using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float torqueAmmount = 10f;
    [SerializeField] float normalSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surface;
    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surface = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove) {
            RespondToBoost();
            RotatePlayer();
        }
    }

    public void DisableControls() {
        canMove = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            surface.speed = boostSpeed;
        } else {
            surface.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            rb2d.AddTorque(torqueAmmount);
        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            rb2d.AddTorque(-torqueAmmount);
        }
    }
}
