using System.Text;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Robot : MonoBehaviour
{
    Animator animator;

    public float totalValue;
    public float value;
    
    public GameObject botHeadPrefab;
    public GameObject botBodyPrefab;
    public GameObject armPrefab;
    public GameObject legPrefab;

    public Transform headSocket;
    public Transform bodySocket;
    public Transform leftArmSocket;
    public Transform rightArmSocket;
    public Transform leftLegSocket;
    public Transform rightLegSocket;

    public GameObject BotHeadInstance;
    public GameObject BotBodyInstance;
    public GameObject BotRightArmInstance;
    public GameObject BotLeftArmInstance;
    public GameObject BotLeftLegInstance;
    public GameObject BotRightLegInstance;

    BotHead head;
    BotBody body;
    BotArm lArm;
    BotArm rArm;
    BotLeg lLeg;
    BotLeg rLeg;

    void Awake()
    {
        animator = GetComponent<Animator>();

        BotHeadInstance = Instantiate(botHeadPrefab, headSocket);
        BotBodyInstance = Instantiate(botBodyPrefab, bodySocket);
        BotLeftArmInstance = Instantiate(armPrefab, leftArmSocket);
        BotRightArmInstance = Instantiate(armPrefab, rightArmSocket);
        BotLeftLegInstance = Instantiate(legPrefab, leftLegSocket);
        BotRightLegInstance = Instantiate(legPrefab, rightLegSocket);

        head = BotHeadInstance.GetComponent<BotHead>();
        body = BotBodyInstance.GetComponent<BotBody>();
        lArm = BotLeftArmInstance.GetComponent<BotArm>();
        rArm = BotRightArmInstance.GetComponent<BotArm>();
        lLeg = BotLeftLegInstance.GetComponent<BotLeg>();
        rLeg = BotRightLegInstance.GetComponent<BotLeg>();

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

    public GameObject TakeArm(bool left = false)
    {
        GameObject go = Instantiate(armPrefab);
        go.GetComponent<BotArm>().Copy(left ? lArm : rArm);
        if (left) lArm = null; else rArm = null;
        return go;
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
