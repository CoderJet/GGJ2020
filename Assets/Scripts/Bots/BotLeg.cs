using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotLeg : MonoBehaviour
{
    Animator animator;
    SpriteRenderer renderer;

    public LegType legType;

    public bool isBroken = false;

    public Sprite BrokenLeg;
    public Sprite SpeedLeg;
    public Sprite ATVLeg;
    public Sprite HoverLeg;
    public Sprite UnicycleLeg;

    public void Init()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();

        int type = Random.Range(0, 4);
        legType = (LegType)type;

        animator.SetInteger("Type", type);
    }

    public float Score(RobotType type)
    {
        float retScore = 0f;

        switch (type)
        {
            case RobotType.cleaner:
                retScore += legType == LegType.hover ? 2f : 0;
                retScore += legType == LegType.speed ? 1f : 0;
                break;
            case RobotType.gardener:
                retScore += legType == LegType.atv ? 2f : 0;
                retScore += legType == LegType.speed ? 1f : 0;
                break;
            case RobotType.construction:
                retScore += legType == LegType.hover ? 1f : 0;
                retScore += legType == LegType.atv ? 2f : 0;
                break;
            case RobotType.artist:
                retScore += legType == LegType.speed ? 1f : 0;
                retScore += legType == LegType.hover ? 2f : 0;
                retScore += legType == LegType.unicycle ? 1f : 0;
                break;
            case RobotType.kill:
                retScore += legType == LegType.speed ? 2f : 0;
                retScore += legType == LegType.unicycle ? 1f : 0;
                break;
            default:
                break;
        }

        return retScore;
    }

    public void Copy(BotLeg leg)
    {
        if (renderer == null)
            renderer = GetComponent<SpriteRenderer>();

        this.legType = leg.legType;
        if (this.animator)
            this.animator.SetInteger("Type", (int)this.legType);
        this.isBroken = leg.isBroken;
        this.renderer.sprite = GetSprite();
    }

    public Sprite GetSprite()
    {
        return GetSpriteForType(legType);
    }

    public Sprite GetSpriteForType(LegType type)
    {
        if (isBroken)
            return BrokenLeg;

        switch (type)
        {
            case LegType.speed:
                return SpeedLeg;
            case LegType.atv:
                return ATVLeg;
            case LegType.hover:
                return HoverLeg;
            case LegType.unicycle:
                return UnicycleLeg;
        }

        return null;
    }
}

public enum LegType
{
    speed,
    atv,
    hover,
    unicycle
}