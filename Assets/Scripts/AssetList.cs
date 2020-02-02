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
