using System.Text;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Robot : MonoBehaviour
{
    Animator animator;

    public float totalValue;
    public float value;
    
    public GameObject botHead;
    public GameObject botBody;
    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject leftLeg;
    public GameObject rightLeg;

    public Transform headSocket;
    public Transform bodySocket;
    public Transform leftArmSocket;
    public Transform rightArmSocket;
    public Transform leftLegSocket;
    public Transform rightLegSocket;

    public BotHead head;
    public BotBody body;
    public BotArm lArm;
    public BotArm rArm;
    public BotLeg lLeg;
    public BotLeg rLeg;

    void Awake()
    {
        animator = GetComponent<Animator>();

        GameObject botHeadInstance = Instantiate(botHead, headSocket);
        GameObject botBodyInstance = Instantiate(botBody, bodySocket);
        GameObject leftArmInstance = Instantiate(leftArm, leftArmSocket);
        GameObject rightArmInstance = Instantiate(rightArm, rightArmSocket);
        GameObject leftLegInstance = Instantiate(leftLeg, leftLegSocket);
        GameObject rightLegInstance = Instantiate(rightLeg, rightLegSocket);

        head = botHeadInstance.GetComponent<BotHead>();
        body = botBodyInstance.GetComponent<BotBody>();
        lArm = leftArmInstance.GetComponent<BotArm>();
        rArm = rightArmInstance.GetComponent<BotArm>();
        lLeg = leftLegInstance.GetComponent<BotLeg>();
        rLeg = rightLegInstance.GetComponent<BotLeg>();

        head.Init();
        body.Init();
        lArm.Init();
        rArm.Init();
        lLeg.Init();
        rLeg.Init();

        GenerateFaults();
    }

    void GenerateFaults()
    {
        bool hasNotGeneratedFault = true;

        do
        {
            head.isBroken = Random.Range(0, 2) == 1;
            body.isBroken = Random.Range(0, 2) == 1;
            lArm.isBroken = Random.Range(0, 2) == 1;
            rArm.isBroken = Random.Range(0, 2) == 1;
            lLeg.isBroken = Random.Range(0, 2) == 1;
            rLeg.isBroken = Random.Range(0, 2) == 1;

            if (head.isBroken || body.isBroken || lArm.isBroken || rArm.isBroken || lLeg.isBroken || rLeg.isBroken)
                hasNotGeneratedFault = false;
        } while (hasNotGeneratedFault);

        CalculateScore();
    }

    private void CalculateScore()
    {
        // Calculate the max total value we can get from the amount of broken elements.
        if (head.isBroken)
            totalValue += 2;
        if (body.isBroken)
            totalValue += 2;
        if (lArm.isBroken)
            totalValue += 2;
        if (rArm.isBroken)
            totalValue += 2;
        if (lLeg.isBroken)
            totalValue += 2;
        if (rLeg.isBroken)
            totalValue += 2;
    }

    public void FixArm(BotArm arm, bool left = false)
    {
        if (left)
        {
            lArm = arm;
            lArm.isBroken = false;
        }
        else
        {
            rArm = arm;
            rArm.isBroken = false;
        }
    }

    public void FixLeg(BotLeg leg, bool left = false)
    {
        if (left)
        {
            lLeg = leg;
            lLeg.isBroken = false;
        }
        else
        {
            rLeg = leg;
            rLeg.isBroken = false;
        }
    }

    public void FixHead(BotHead head)
    {
        this.head = head;
        this.head.isBroken = false;
    }

    public void FixBody(BotBody body)
    {
        this.body = body;
        this.body.isBroken = false;
    }

    public string GetTypeFriendly()
    {
        string ret = "N/A";
        if (body != null)
        {
            switch (body.robotType)
            {
                case RobotType.cleaner:
                    ret = "Cleaner";
                    break;
                case RobotType.gardener:
                    ret = "Gardener";
                    break;
                case RobotType.construction:
                    ret = "Construction";
                    break;
                case RobotType.artist:
                    ret = "Artist";
                    break;
                case RobotType.kill:
                    ret = "Killer";
                    break;
                default:
                    break;
            }
        }
        return ret;
    }

    public string GetFaults()
    {
        Debug.Log(head == null);

        StringBuilder ret = new StringBuilder();

        if (head.isBroken)
            ret.Append("One Broken Head").AppendLine();
        if (body.isBroken)
            ret.Append("One Broken Body").AppendLine();

        if (lArm.isBroken || rArm.isBroken)
        {
            if (lArm.isBroken && rArm.isBroken)
                ret.Append("Two Broken Arms").AppendLine();
            else
                ret.Append("One Broken Arm").AppendLine();
        }

        if (lLeg.isBroken || rLeg.isBroken)
        {
            if (lLeg.isBroken && rLeg.isBroken)
                ret.Append("Two Broken Legs").AppendLine();
            else
                ret.Append("One Broken Leg").AppendLine();
        }

        return ret.ToString();
    }

    public bool IsFixed()
    {
        return (!lLeg.isBroken && !rLeg.isBroken && !lArm.isBroken && !rArm.isBroken && !body.isBroken && !head.isBroken);
    }

    public string Remarks()
    {
        string ret = "No Remarks";

        return ret;
    }
}
