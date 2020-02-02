using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private Animator[] animators;
    private bool inTrigger = false;

    private void Awake()
    {
        animators = GetComponentsInChildren<Animator>();
    }

    public void AnimateConveyor(bool start)
    {
        foreach(Animator a in animators)
        {
            a.SetTrigger(start ? "Start" : "Stop");
        }
    }

    public bool InTriggerArea()
    {
        return inTrigger;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
