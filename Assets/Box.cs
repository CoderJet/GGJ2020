using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered boxes radius!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited boxes radius!");
    }
}
