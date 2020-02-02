using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotArm : MonoBehaviour
{
    Animator animator;
    SpriteRenderer renderer;

    public ArmType armType;

    public bool isBroken = false;

    public Sprite BrokenArm;
    public Sprite MachineGunArm;
    public Sprite PaintGunArm;
    public Sprite HammerArm;
    public Sprite ShearsArm;
    public Sprite MopArm;
    public Sprite BladeArm;
    public Sprite RollerArm;
    public Sprite CementArm;
    public Sprite ChainsawArm;
    public Sprite VacuumArm;
    public Sprite LaserArm;
    public Sprite TwineArm;
    public Sprite NailgunArm;
    public Sprite FlamethrowerArm;
    public Sprite PaintbrushArm;

    public void Init()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();

        int type = Random.Range(0, 15);
        armType = (ArmType)type;

        if (animator)
            animator.SetInteger("Type", type);
        if (renderer)
            renderer.sprite = GetSprite();
    }

    public void Copy(BotArm arm)
    {
        if (renderer == null)
            renderer = GetComponent<SpriteRenderer>();

        this.armType = arm.armType;
        if (this.animator)
            this.animator.SetInteger("Type", (int)this.armType);
        this.isBroken = arm.isBroken;
        this.renderer.sprite = GetSprite();
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
            case ArmType.paintbrush:
                retScore += type == RobotType.artist ? 2 : 0;
                retScore += type == RobotType.construction ? 1 : 0;
                retScore += type == RobotType.cleaner ? 1 : 0;
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

    public Sprite GetSprite()
    {
        return GetSpriteForType(armType);
    }

    public Sprite GetSpriteForType(ArmType type)
    {
        if (isBroken)
            return BrokenArm;

        switch (type)
        {
            case ArmType.machinegun:
                return MachineGunArm;
            case ArmType.paintgun:
                return PaintGunArm;
            case ArmType.hammer:
                return HammerArm;
            case ArmType.shears:
                return ShearsArm;
            case ArmType.mop:
                return MopArm;
            case ArmType.blade:
                return BladeArm;
            case ArmType.roller:
                return RollerArm;
            case ArmType.cement:
                return CementArm;
            case ArmType.chainsaw:
                return ChainsawArm;
            case ArmType.vacuum:
                return VacuumArm;
            case ArmType.laser:
                return LaserArm;
            case ArmType.twine:
                return TwineArm;
            case ArmType.nailgun:
                return NailgunArm;
            case ArmType.flamethrower:
                return FlamethrowerArm;
            case ArmType.paintbrush:
                return PaintbrushArm;
        }
        return null;
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
    flamethrower,
    paintbrush
}
