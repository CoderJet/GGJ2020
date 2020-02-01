using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotLeg : MonoBehaviour
{
    Animator animator;

    public LegType legType;

    public bool isBroken = false;

    public void Init()
    {
        animator = GetComponent<Animator>();

        int type = Random.Range(0, 7);
        legType = (LegType)type;

        animator.SetInteger("Type", type);
    }
}

public enum LegType
{
    eisel,
    speed,
    atv,
    grapple,
    octo,
    hover,
    unicycle
}