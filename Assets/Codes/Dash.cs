﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction == 0)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {

                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {

                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {

                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {

                direction = 4;
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    if (direction == 1)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse1))
                        {
                            rb.velocity = Vector2.left * dashSpeed;
                        }
                    }
                    else if (direction == 2)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse1))
                        {
                            rb.velocity = Vector2.right * dashSpeed;
                        }
                    }
                    else if (direction == 3)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse1))
                        {
                            rb.velocity = Vector2.up * dashSpeed;
                        }
                    }
                    else if (direction == 4)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse1))
                        {
                            rb.velocity = Vector2.down * dashSpeed;
                        }
                    }
                }
            }
        }
    }
}
