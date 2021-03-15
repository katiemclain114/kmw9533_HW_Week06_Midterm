using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterStore : MonoBehaviour
{
    private bool onDoor = false;

    private void Update()
    {
        //open door when on and door and e pressed
        if (onDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        onDoor = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onDoor = false;
    }
}
