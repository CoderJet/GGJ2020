using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool triggerArea = false;
    public bool InTriggerArea()
    {
        return triggerArea;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerArea = false;
    }
}
