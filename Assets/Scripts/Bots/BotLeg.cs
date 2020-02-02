using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotLeg : MonoBehaviour
{
    Animator animator;

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

        int type = Random.Range(0, 7);
        legType = (LegType)type;

        animator.SetInteger("Type", type);
    }

    public Sprite GetSprite()
    {
        return GetSpriteForType(legType);
    }

    private Sprite GetSpriteForType(LegType type)
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