﻿using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotBody : MonoBehaviour
{
    Animator animator;

    public RobotType robotType;

    public bool isBroken = false;

    public void Init()
    {
        animator = GetComponent<Animator>();

        int type = Random.Range(0, 4);
        robotType = (RobotType)type;

        animator.SetInteger("Type", (int)robotType);
    }
}

public enum RobotType
{
    cleaner,
    gardener,
    construction,
    artist,
    kill
}