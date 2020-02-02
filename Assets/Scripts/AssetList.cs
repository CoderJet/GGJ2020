using System.Collections.Generic;
using UnityEngine;

public class AssetList : MonoBehaviour
{
    [SerializeField] GameObject assetItemPrefab;

    public GameObject botHeadPrefab;
    public GameObject botBodyPrefab;
    public GameObject armPrefab;
    public GameObject legPrefab;

    private bool open = false;
    public void InTrigger(bool inTrigger)
    {
        open = inTrigger;
    }

    public bool Valid()
    {
        return open;
    }

    public void Clear()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void Menu()
    {
        Inventory inventory = FindObjectOfType<Inventory>();

        BotHead botHead = botHeadPrefab.GetComponent<BotHead>();
        BotBody botBody = botBodyPrefab.GetComponent<BotBody>();
        BotArm botArm = armPrefab.GetComponent<BotArm>();
        BotLeg botLeg = legPrefab.GetComponent<BotLeg>();

        Clear();

        foreach (KeyValuePair<HeadType, int> head in inventory.heads)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.SetupCatalog(botHead.GetSpriteForType(head.Key), 1, head.Key.ToString());// TODO
        }

        foreach (KeyValuePair<RobotType, int> body in inventory.bodies)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.SetupCatalog(botBody.GetSpriteForType(body.Key), 1, body.Key.ToString());// TODO
        }

        foreach (KeyValuePair<ArmType, int> arm in inventory.arms)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.SetupCatalog(botArm.GetSpriteForType(arm.Key), 1, arm.Key.ToString());// TODO
        }

        foreach (KeyValuePair<LegType, int> leg in inventory.legs)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.SetupCatalog(botLeg.GetSpriteForType(leg.Key), 1, leg.Key.ToString());// TODO
        }
    }

    public void BuildHeadList(Dictionary<HeadType, int> heads)
    {
        Clear();
        BotHead botHead = botHeadPrefab.GetComponent<BotHead>();

        foreach (KeyValuePair<HeadType, int> head in heads)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.Setup(botHead.GetSpriteForType(head.Key), head.Value, head.Key.ToString());
        }
    }

    public void BuildBodyList(Dictionary<RobotType, int> bodies)
    {
        Clear();
        BotBody botBody = botBodyPrefab.GetComponent<BotBody>();

        foreach (KeyValuePair<RobotType, int> body in bodies)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.Setup(botBody.GetSpriteForType(body.Key), body.Value, body.Key.ToString());
        }
    }

    public void BuildArmsList(Dictionary<ArmType, int> arms)
    {
        Clear();
        BotArm botArm = armPrefab.GetComponent<BotArm>();

        foreach (KeyValuePair<ArmType, int> arm in arms)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.Setup(botArm.GetSpriteForType(arm.Key), arm.Value, arm.Key.ToString());
        }
    }

    public void BuildLegsList(Dictionary<LegType, int> legs)
    {
        Clear();
        BotLeg botLeg = legPrefab.GetComponent<BotLeg>();

        foreach (KeyValuePair<LegType, int> leg in legs)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.Setup(botLeg.GetSpriteForType(leg.Key), leg.Value, leg.Key.ToString());
        }
    }
}
