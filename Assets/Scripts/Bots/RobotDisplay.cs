using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotDisplay : MonoBehaviour
{
    public Image HeadImage;
    public Image BodyImage;
    public Image LeftArmImage;
    public Image RightArmImage;
    public Image LeftLegImage;
    public Image RightLegImage;

    public GameObject Panel;

    public void Show()
    {
        Panel.SetActive(true);
    }

    public void Hide()
    {
        Panel.SetActive(false);
    }

    // Start is called before the first frame update
    public void UpdateRobot(Robot rob)
    {
        HeadImage.sprite = rob.head.GetComponent<BotHead>().GetSprite();
        BodyImage.sprite = rob.body.GetComponent<BotBody>().GetSprite();
        LeftArmImage.sprite = rob.lArm.GetComponent<BotArm>().GetSprite();
        RightArmImage.sprite = rob.rArm.GetComponent<BotArm>().GetSprite();
        LeftLegImage.sprite = rob.lLeg.GetComponent<BotLeg>().GetSprite();
        RightLegImage.sprite = rob.rLeg.GetComponent<BotLeg>().GetSprite();
    }
}
