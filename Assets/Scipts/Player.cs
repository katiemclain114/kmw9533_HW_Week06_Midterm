using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    private Rigidbody2D rb;
    public float forceAmt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * forceAmt);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector2.down * forceAmt);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector2.left * forceAmt);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(Vector2.right * forceAmt);
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Inventory.instance.CarrotSeedsInv);
        }
    }
}
