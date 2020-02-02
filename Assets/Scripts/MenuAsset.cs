using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class MenuAsset : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemCount;
    int cost = 0;

    public Inventory inventory;
    public AssetList list;
    public PlayerController controller;
    private Slot slot;
    private int count;

    public void SetupCatalog(Sprite icon, int price, string name, Slot slot)
    {
        image.sprite = icon;
        itemCount.text = $"${price}";
        itemName.text = name;
        cost = price;
        this.slot = slot;
    }

    public void Setup(Sprite icon, int count, string name, Slot slot)
    {
        image.sprite = icon;
        itemCount.text = $"x{count}";
        itemName.text = name;
        this.count = count;
        this.slot = slot;
        if (GetComponent<UnityEngine.UI.Button>() != null)
        {
            UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
            button.onClick.AddListener(OnClick);
        }
    }

    public void OnClick()
    {
        if (this.count == 0)
            return;
        if (controller.isHoldingPart)
            return;

        if (slot == Slot.body)
        {
            RobotType type;
            if (Enum.TryParse<RobotType>(itemName.text, out type))
            {
                inventory.bodies[type]--;
                GameObject body = Instantiate(list.botBodyPrefab);
                body.GetComponent<BotBody>().robotType = type;
                body.GetComponent<BotBody>().isBroken = false;
                body.GetComponent<SpriteRenderer>().sprite = body.GetComponent<BotBody>().GetSprite();
                list.BuildBodyList(inventory.bodies);
                controller.TakePart(body);
                list.InTrigger(false);
            }
        }
        else if (slot == Slot.head)
        {
            HeadType type;
            if (Enum.TryParse<HeadType>(itemName.text, out type))
            {
                inventory.heads[type]--;
                GameObject head = Instantiate(list.botHeadPrefab);
                head.GetComponent<BotHead>().headType = type;
                head.GetComponent<BotHead>().isBroken = false;
                head.GetComponent<SpriteRenderer>().sprite = head.GetComponent<BotHead>().GetSprite();
                list.BuildHeadList(inventory.heads);
                controller.TakePart(head);
                list.InTrigger(false);
            }
        }
        else if (slot == Slot.leftArm || slot == Slot.rightArm)
        {
            ArmType type;
            if (Enum.TryParse<ArmType>(itemName.text, out type))
            {
                inventory.arms[type]--;
                GameObject arm = Instantiate(list.armPrefab);
                arm.GetComponent<BotArm>().armType = type;
                arm.GetComponent<BotArm>().isBroken = false;
                arm.GetComponent<SpriteRenderer>().sprite = arm.GetComponent<BotArm>().GetSprite();
                list.BuildArmsList(inventory.arms);
                controller.TakePart(arm);
                list.InTrigger(false);
            }
        }
        else if (slot == Slot.leftLeg || slot == Slot.rightLeg)
        {
            LegType type;
            if (Enum.TryParse<LegType>(itemName.text, out type))
            {
                inventory.legs[type]--;
                GameObject leg = Instantiate(list.legPrefab);
                leg.GetComponent<BotLeg>().legType = type;
                leg.GetComponent<BotLeg>().isBroken = false;
                leg.GetComponent<SpriteRenderer>().sprite = leg.GetComponent<BotLeg>().GetSprite();
                list.BuildLegsList(inventory.legs);
                controller.TakePart(leg);
                list.InTrigger(false);
            }
        }
    }
}
