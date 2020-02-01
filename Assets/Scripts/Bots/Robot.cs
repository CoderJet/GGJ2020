using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Robot : MonoBehaviour
{
    Animator animator;

    public int value;

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

    BotHead head;
    BotBody body;
    BotArm lArm;
    BotArm rArm;
    BotLeg lLeg;
    BotLeg rLeg;

    void Start()
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
    }
}
