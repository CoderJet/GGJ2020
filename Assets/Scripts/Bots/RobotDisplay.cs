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

    public PlayerController player;

    private Robot robot;

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
        HeadImage.sprite = rob.BotHeadInstance.GetComponent<BotHead>().GetSprite();
        BodyImage.sprite = rob.BotBodyInstance.GetComponent<BotBody>().GetSprite();
        LeftArmImage.sprite = rob.BotLeftArmInstance.GetComponent<BotArm>().GetSprite();
        RightArmImage.sprite = rob.BotRightArmInstance.GetComponent<BotArm>().GetSprite();
        LeftLegImage.sprite = rob.BotLeftLegInstance.GetComponent<BotLeg>().GetSprite();
        RightLegImage.sprite = rob.BotRightLegInstance.GetComponent<BotLeg>().GetSprite();

        robot = rob;
    }

    public enum Slot { head, body, leftArm, rightArm, leftLeg, rightLeg }
    public void GetPart(int part)
    {
        var slot = (Slot)part;
        // Instantiate a head object, set its values from the robot, and then remove the head image.
        switch (slot)
        {
            case Slot.head:
                break;
            case Slot.body:
                break;
            case Slot.leftArm:
                LeftArmImage.sprite = null;
                GameObject lArm = robot.TakeArm(true);
                Debug.Log(lArm);
                player.TakePart(lArm);
                break;
            case Slot.rightArm:
                RightArmImage.sprite = null;
                player.TakePart(robot.TakeArm(false));
                break;
            case Slot.leftLeg:
                break;
            case Slot.rightLeg:
                break;
            default:
                break;
        };
    }
}
