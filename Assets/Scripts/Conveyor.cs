using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private Animator[] animators;

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
}
