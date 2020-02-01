using UnityEngine;

public class Robot : MonoBehaviour
{
    public int value;

    public GameObject botHead;

    public GameObject botBody;

    public GameObject leftArm;
    public GameObject rightArm;

    public GameObject leftLeg;
    public GameObject rightLeg;

    public RobotType robotType;

    public Transform headSocket;
    public Transform bodySocket;
    public Transform leftArmSocket;
    public Transform rightArmSocket;
    public Transform leftLegSocket;
    public Transform rightLegSocket;

    void Start()
    {
        GameObject botHeadInstance = Instantiate(botHead, headSocket);
        GameObject botBodyInstance = Instantiate(botBody, bodySocket);
        GameObject leftArmInstance = Instantiate(leftArm, leftArmSocket);
        GameObject rightArmInstance = Instantiate(rightArm, rightArmSocket);
        GameObject leftLegInstance = Instantiate(leftLeg, leftLegSocket);
        GameObject rightLegInstance = Instantiate(rightLeg, rightLegSocket);

        BotHead head = botHeadInstance.GetComponent<BotHead>();
        BotBody body = botBodyInstance.GetComponent<BotBody>();
        BotArm lArm = leftArmInstance.GetComponent<BotArm>();
        BotArm rArm = rightArmInstance.GetComponent<BotArm>();
        BotLeg lLeg = leftLegInstance.GetComponent<BotLeg>();
        BotLeg rLeg = rightLegInstance.GetComponent<BotLeg>();

        head.Init();

        int type = Random.Range(0, 4);
        robotType = (RobotType)type;

        body.Init(robotType);

        lArm.Init();
        rArm.Init();

        lLeg.Init();
        rLeg.Init();
    }
}

public enum RobotType
{
    cleaner,
    gardener,
    construction,
    artist,
    kill
}
