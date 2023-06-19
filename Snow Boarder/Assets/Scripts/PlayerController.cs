using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeeed = 20;
    Rigidbody2D r2bd;
    SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        r2bd = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else {
            surfaceEffector2D.speed = baseSpeeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            r2bd.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            r2bd.AddTorque(-torqueAmount);
        }
    }
}
