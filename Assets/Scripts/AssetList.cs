using System.Collections.Generic;
using UnityEngine;

public class AssetList : MonoBehaviour
{
    [SerializeField] GameObject assetItemPrefab;

    public void Clear()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void BuildHeadList(Dictionary<HeadType, int> heads)
    {
        BotHead botHead = new BotHead();

        foreach (KeyValuePair<HeadType, int> head in heads)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.Setup(botHead.GetSpriteForType(head.Key), head.Value, head.Key.ToString());
        }
    }

    public void BuildBodyList(Dictionary<RobotType, int> bodies)
    {
        BotBody botBody = new BotBody();

        foreach (KeyValuePair<RobotType, int> body in bodies)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.Setup(botBody.GetSpriteForType(body.Key), body.Value, body.Key.ToString());
        }
    }

    public void BuildArmsList(Dictionary<ArmType, int> arms)
    {
        BotArm botArm = new BotArm();

        foreach (KeyValuePair<ArmType, int> arm in arms)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.Setup(botArm.GetSpriteForType(arm.Key), arm.Value, arm.Key.ToString());
        }
    }

    public void BuildLegsList(Dictionary<LegType, int> legs)
    {
        BotLeg botLeg = new BotLeg();

        foreach (KeyValuePair<LegType, int> leg in legs)
        {
            GameObject assetItemInstance = Instantiate(assetItemPrefab, transform);
            MenuAsset menuAsset = assetItemInstance.GetComponent<MenuAsset>();

            menuAsset.Setup(botLeg.GetSpriteForType(leg.Key), leg.Value, leg.Key.ToString());
        }
    }
}
