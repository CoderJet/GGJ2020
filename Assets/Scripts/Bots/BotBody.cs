using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotBody : MonoBehaviour
{
    Animator animator;
    public Sprite BrokenBody;
    public Sprite CleanerBody;
    public Sprite GardenerBody;
    public Sprite ConstructionBody;
    public Sprite ArtistBody;
    public Sprite KillBody;

    public RobotType robotType;

    public bool isBroken = false;

    public void Init()
    {
        animator = GetComponent<Animator>();

        int type = Random.Range(0, 5);
        robotType = (RobotType)type;

        if (animator)
            animator.SetInteger("Type", (int)robotType);
    }

    public void Copy(BotBody body)
    {

    }

    public Sprite GetSprite()
    {
        return GetSpriteForType(robotType);
    }

    private Sprite GetSpriteForType(RobotType type)
    {
        if (isBroken)
            return BrokenBody;

        switch (type)
        {
            case RobotType.cleaner:
                return CleanerBody;
            case RobotType.gardener:
                return GardenerBody;
            case RobotType.construction:
                return ConstructionBody;
            case RobotType.artist:
                return ArtistBody;
            case RobotType.kill:
                return KillBody;
        }
        return null;
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