using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotArm : MonoBehaviour
{
    Animator animator;

    public ArmType armType;

    public bool isBroken = false;

    public void Init()
    {
        animator = GetComponent<Animator>();

        int type = Random.Range(0, 15);
        armType = (ArmType)type;

        if (animator)
            animator.SetInteger("Type", type);
    }
}

public enum ArmType
{
    machinegun,
    paintgun,
    hammer,
    shears,
    mop,
    blade,
    roller,
    cement,
    chainsaw,
    vacuum,
    laser,
    twine,
    nailgun,
    mower,
    flamethrower
}