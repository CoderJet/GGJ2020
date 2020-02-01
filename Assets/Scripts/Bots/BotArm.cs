using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotArm : MonoBehaviour
{
    Animator animator;

    public ArmType armType;

    public void Init()
    {
        animator = GetComponent<Animator>();

        int type = Random.Range(0, 14);
        armType = (ArmType)type;

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