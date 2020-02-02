﻿using System.Text;
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
        body.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        lArm.Init();
        lArm.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        rArm.Init();
        rArm.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        lLeg.Init();
        lLeg.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        rLeg.Init();
        rLeg.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

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

    public Sprite GetSprite(Slot slot)
    {
        switch (slot)
        {
            case Slot.head:
                if (head != null)
                    return head.GetSprite();
                break;
            case Slot.body:
                break;
            case Slot.leftArm:
                if (lArm != null)
                    return lArm.GetSprite();
                break;
            case Slot.rightArm:
                if (rArm != null)
                    return rArm.GetSprite();
                break;
            case Slot.leftLeg:
                if (lLeg != null)
                    return lLeg.GetSprite();
                break;
            case Slot.rightLeg:
                if (rLeg != null)
                    return rLeg.GetSprite();
                break;
        }

        return null;
    }

    public GameObject TakeArm(bool left = false)
    {
        GameObject go = Instantiate(armPrefab);
        go.GetComponent<BotArm>().Copy(left ? lArm : rArm);
        if (left) lArm = null; else rArm = null;
        return go;
    }

    public GameObject TakeLeg(bool left = false)
    {
        GameObject go = Instantiate(legPrefab);
        go.GetComponent<BotLeg>().Copy(left ? lLeg : rLeg);
        if (left) lLeg = null; else rLeg = null;
        return go;
    }

    public GameObject TakeHead()
    {
        GameObject go = Instantiate(botHeadPrefab);
        go.GetComponent<BotHead>().Copy(head);
        head = null;
        return go;
    }

    public GameObject TakeBody()
    {
        GameObject go = Instantiate(botBodyPrefab);
        //go.GetComponent<BotBody>().Copy(body);
        body = null;
        return go;
    }

    public void FixPart(GameObject part, bool left = false)
    {
        if (part.GetComponent<BotHead>() != null)
        {
            FixHead(part.GetComponent<BotHead>());
        }
        else if (part.GetComponent<BotBody>() != null)
        {
            FixBody(part.GetComponent<BotBody>());
        }
        else if (part.GetComponent<BotArm>() != null)
        {
            FixArm(part.GetComponent<BotArm>(), left);
        }
        else if (part.GetComponent<BotLeg>() != null)
        {
            FixLeg(part.GetComponent<BotLeg>(), left);
        }

        // Destroy it afterwards.
    }

    public void FixArm(BotArm arm, bool left = false)
    {
        if (left)
        {
            lArm = arm;
            lArm.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        else
        {
            rArm = arm;
            rArm.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }

    public void FixLeg(BotLeg leg, bool left = false)
    {
        if (left)
        {
            lLeg = leg;
            lLeg.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        else
        {
            rLeg = leg;
            rLeg.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }

    public void FixHead(BotHead head)
    {
        this.head = head;
        head.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    public void FixBody(BotBody body)
    {
        this.body = body;
        body.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
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
