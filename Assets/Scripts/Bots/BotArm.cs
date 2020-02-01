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

    public float Score(RobotType type)
    {
        float retScore = 0f;

        switch (armType)
        {
            case ArmType.machinegun:
                retScore += type == RobotType.gardener ? 1 : 0;
                retScore += type == RobotType.kill ? 2 : 0;
                break;
            case ArmType.paintgun:
                retScore += type == RobotType.artist ? 2 : 0;
                retScore += type == RobotType.kill ? 1 : 0;
                break;
            case ArmType.hammer:
                retScore += type == RobotType.artist ? 1 : 0;
                retScore += type == RobotType.construction ? 2 : 0;
                retScore += type == RobotType.kill ? 1 : 0;
                break;
            case ArmType.shears:
                retScore += type == RobotType.gardener ? 2 : 0;
                retScore += type == RobotType.kill ? 1 : 0;
                break;
            case ArmType.mop:
                retScore += type == RobotType.cleaner ? 2 : 0;
                break;
            case ArmType.blade:
                retScore += type == RobotType.artist ? 1 : 0;
                retScore += type == RobotType.construction ? 1 : 0;
                retScore += type == RobotType.gardener ? 1 : 0;
                retScore += type == RobotType.kill ? 2 : 0;
                break;
            case ArmType.roller:
                retScore += type == RobotType.artist ? 2 : 0;
                retScore += type == RobotType.construction ? 2 : 0;
                break;
            case ArmType.cement:
                retScore += type == RobotType.construction ? 2 : 0;
                retScore += type == RobotType.kill ? 1 : 0;
                break;
            case ArmType.chainsaw:
                retScore += type == RobotType.construction ? 1 : 0;
                retScore += type == RobotType.gardener ? 2 : 0;
                retScore += type == RobotType.kill ? 2 : 0;
                break;
            case ArmType.vacuum:
                retScore += type == RobotType.cleaner ? 2 : 0;
                retScore += type == RobotType.construction ? 1 : 0;
                break;
            case ArmType.laser:
                retScore += type == RobotType.cleaner ? 1 : 0;
                retScore += type == RobotType.kill ? 2 : 0;
                break;
            case ArmType.twine:
                retScore += type == RobotType.artist ? 2 : 0;
                retScore += type == RobotType.construction ? 1 : 0;
                retScore += type == RobotType.gardener ? 1 : 0;
                retScore += type == RobotType.kill ? 1 : 0;
                break;
            case ArmType.nailgun:
                retScore += type == RobotType.construction ? 2 : 0;
                retScore += type == RobotType.kill ? 2 : 0;
                break;
            case ArmType.mower:
                retScore += type == RobotType.gardener ? 2 : 0;
                retScore += type == RobotType.kill ? 1 : 0;
                break;
            case ArmType.flamethrower:
                retScore += type == RobotType.artist ? 2 : 0;
                retScore += type == RobotType.cleaner ? 2 : 0;
                retScore += type == RobotType.construction ? 2 : 0;
                retScore += type == RobotType.gardener ? 2 : 0;
                retScore += type == RobotType.kill ? 2 : 0;
                break;
            default:
                break;
        }

        return retScore;
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