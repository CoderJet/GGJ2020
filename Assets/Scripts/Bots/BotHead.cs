using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotHead : MonoBehaviour
{
    Animator animator;
    SpriteRenderer renderer;

    public HeadType headType;

    public Sprite CleanerHead;
    public Sprite GardenerHead;
    public Sprite ConstructionHead;
    public Sprite ArtistHead;
    public Sprite KillHead;

    public bool isBroken = false;

    public void Init()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();

        int type = Random.Range(0, 5);
        headType = (HeadType)type;

        if (animator)
            animator.SetInteger("Type", type);
        renderer.sprite = GetSprite();
    }

    public void Copy(BotHead head)
    {
        renderer = GetComponent<SpriteRenderer>();

        headType = head.headType;
        if (this.animator)
            this.animator.SetInteger("Type", (int)this.headType);
        isBroken = head.isBroken;
        renderer.sprite = GetSprite();
    }

    public Sprite GetSprite()
    {
        return GetSpriteForType(headType);
    }

    private Sprite GetSpriteForType(HeadType type)
    {
        switch (type)
        {
            case HeadType.cleaner:
                return CleanerHead;
            case HeadType.gardener:
                return GardenerHead;
            case HeadType.construction:
                return ConstructionHead;
            case HeadType.artist:
                return ArtistHead;
            case HeadType.kill:
                return KillHead;
        }
        return null;
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