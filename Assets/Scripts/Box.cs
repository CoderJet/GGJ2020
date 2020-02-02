using UnityEngine;
using TMPro;

public class Box : MonoBehaviour
{
    [SerializeField] Sprite headBox;
    [SerializeField] Sprite bodyBox;
    [SerializeField] Sprite armBox;
    [SerializeField] Sprite legBox;
    [SerializeField] Sprite recycleBox;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject tag;
    [SerializeField] BoxType boxType;
    [SerializeField] LayerMask playerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tag.SetActive(false);
    }

    private int Scrap = 0;

    private string GetTypeString()
    {
        string ret = "";

        switch (boxType)
        {
            case BoxType.head:
                ret = "Head";
                break;
            case BoxType.body:
                ret = "Body";
                break;
            case BoxType.arms:
                ret = "Arms";
                break;
            case BoxType.legs:
                ret = "Legs";
                break;
            case BoxType.recycle:
                ret = "Recycle Bin";
                break;
            default:
                break;
        }

        return ret;
    }

    private void Awake()
    {
        switch (boxType)
        {
            case BoxType.head:
                spriteRenderer.sprite = headBox;
                break;
            case BoxType.body:
                spriteRenderer.sprite = bodyBox;
                break;
            case BoxType.arms:
                spriteRenderer.sprite = armBox;
                break;
            case BoxType.legs:
                spriteRenderer.sprite = legBox;
                break;
            case BoxType.recycle:
                spriteRenderer.sprite = recycleBox;
                break;
            default:
                break;
        }

        var comp = tag.GetComponentInChildren<TextMeshProUGUI>();
        if (comp)
        {
            comp.text = GetTypeString();
        }
    }

    void Interact()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();

        ContactFilter2D contactFilter2D = new ContactFilter2D();
        contactFilter2D.layerMask = playerMask;

        Collider2D[] colliders = new Collider2D[1];

        int collisionCount = boxCollider2D.OverlapCollider(contactFilter2D, colliders);

        if(collisionCount > 0)
        {
            Collider2D collider = colliders[0];
            GameObject playerObj = collider.gameObject;

            PlayerController playerController = playerObj.GetComponent<PlayerController>();
            Inventory inventory = playerObj.GetComponent<Inventory>();

            switch (boxType)
            {
                case BoxType.head:
                    // TODO - inventory.heads;
                    break;
                case BoxType.body:
                    // TODO - inventory.bodies;
                    break;
                case BoxType.arms:
                    // TODO - inventory.arms;
                    break;
                case BoxType.legs:
                    // TODO - inventory.legs;
                    break;
                case BoxType.recycle:
                    // TODO
                    if(playerController.isHoldingPart)
                    {
                        //inventory.binItems.Add(playerController.currentHeldObject);
                        Scrap++;
                        playerController.GivePart();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

enum BoxType
{
    head,
    body,
    arms,
    legs,
    recycle
}