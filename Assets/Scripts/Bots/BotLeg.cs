using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotLeg : MonoBehaviour
{
    Animator animator;

    public LegType legType;

    public void Init()
    {
        animator = GetComponent<Animator>();

        int type = Random.Range(0, 6);
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