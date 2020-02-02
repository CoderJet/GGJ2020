using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Slot { head, body, leftArm, rightArm, leftLeg, rightLeg }

public class RobotDisplay : MonoBehaviour
{
    public Image HeadImage;
    public Image BodyImage;
    public Image LeftArmImage;
    public Image RightArmImage;
    public Image LeftLegImage;
    public Image RightLegImage;

    public GameObject Panel;

    public Color clear;
    public Color showed;

    public PlayerController player;

    private GameObject robot;
    private Dictionary<Slot, bool> filledSlots = new Dictionary<Slot, bool>();

    public void Awake()
    {
        filledSlots[Slot.head] = true;
        filledSlots[Slot.leftArm] = true;
        filledSlots[Slot.rightArm] = true;
        filledSlots[Slot.body] = true;
        filledSlots[Slot.leftLeg] = true;
        filledSlots[Slot.rightLeg] = true;
    }

    public void Show()
    {
        Panel.SetActive(true);
    }

    public void Hide()
    {
        Panel.SetActive(false);
    }

    public void HandlePress(int part)
    {
        var slot = (Slot)part;
        if (filledSlots[slot])
        {
            GetPart(part);
            Hide();
        }
        else
        {
            GameObject go = player.GivePart();
            if (go != null)
            {
                // He was holding a part!
                robot.GetComponent<Robot>().FixPart(go, (slot == Slot.leftArm || slot == Slot.leftLeg));
                UpdateRobot(robot.GetComponent<Robot>());
                Hide();
            }
        }
    }

    // Start is called before the first frame update
    public void UpdateRobot(Robot rob)
    {
        HeadImage.sprite = rob.GetSprite(Slot.head);
        filledSlots[Slot.head] = (HeadImage.sprite != null);
        HeadImage.color = !filledSlots[Slot.head] ? clear : showed;

        BodyImage.sprite = rob.GetSprite(Slot.body);
        filledSlots[Slot.body] = (BodyImage.sprite != null);
        BodyImage.color = !filledSlots[Slot.body] ? clear : showed;

        LeftArmImage.sprite = rob.GetSprite(Slot.leftArm);
        filledSlots[Slot.leftArm] = (LeftArmImage.sprite != null);
        LeftArmImage.color = !filledSlots[Slot.leftArm] ? clear : showed;

        RightArmImage.sprite = rob.GetSprite(Slot.rightArm);
        filledSlots[Slot.rightArm] = (RightArmImage.sprite != null);
        RightArmImage.color = !filledSlots[Slot.rightArm] ? clear : showed;

        LeftLegImage.sprite = rob.GetSprite(Slot.leftLeg);
        filledSlots[Slot.leftLeg] = (LeftLegImage.sprite != null);
        LeftLegImage.color = !filledSlots[Slot.leftLeg] ? clear : showed;

        RightLegImage.sprite = rob.GetSprite(Slot.rightLeg);
        filledSlots[Slot.rightLeg] = (RightLegImage.sprite != null);
        RightLegImage.color = !filledSlots[Slot.rightLeg] ? clear : showed;

        robot = rob.gameObject;
    }

    public void GetPart(int part)
    {
        var slot = (Slot)part;
        // Instantiate a head object, set its values from the robot, and then remove the head image.
        switch (slot)
        {
            case Slot.head:
                HeadImage.sprite = null;
                HeadImage.color = clear;
                player.TakePart(robot.GetComponent<Robot>().TakeHead());
                break;
            case Slot.body:
                BodyImage.sprite = null;
                BodyImage.color = clear;
                player.TakePart(robot.GetComponent<Robot>().TakeBody());
                break;
            case Slot.leftArm:
                LeftArmImage.sprite = null;
                LeftArmImage.color = clear;
                player.TakePart(robot.GetComponent<Robot>().TakeArm(true));
                break;
            case Slot.rightArm:
                RightArmImage.sprite = null;
                RightArmImage.color = clear;
                player.TakePart(robot.GetComponent<Robot>().TakeArm(false));
                break;
            case Slot.leftLeg:
                LeftLegImage.sprite = null;
                LeftLegImage.color = clear;
                player.TakePart(robot.GetComponent<Robot>().TakeLeg(true));
                break;
            case Slot.rightLeg:
                RightLegImage.sprite = null;
                RightLegImage.color = clear;
                player.TakePart(robot.GetComponent<Robot>().TakeLeg(false));
                break;
            default:
                break;
        };
        filledSlots[slot] = false;
    }
}
