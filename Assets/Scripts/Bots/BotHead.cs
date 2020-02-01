using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotHead : MonoBehaviour
{
    Animator animator;

    public HeadType headType;

    public bool isBroken = false;

    public void Init()
    {
        animator = GetComponent<Animator>();

        int type = Random.Range(0, 5);
        headType = (HeadType)type;

        animator.SetInteger("Type", type);
    }
}

public enum HeadType
{
    cleaner,
    gardener,
    construction,
    artist,
    kill
}