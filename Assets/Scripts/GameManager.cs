using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Report report = new Report();

    SaveData saveData;
    public TextMeshProUGUI RobotType;
    public TextMeshProUGUI RobotFaults;
    public TextMeshProUGUI RobotScore;

    public Transform robotSpawnPosition;
    public Transform robotRepairPosition;
    public Transform robotEndPosition;

    public Conveyor conveyorBelt;
    public Button button;

    public RobotDisplay display;
    private int score = 0;

    public GameObject spawnBot;
    private GameObject currentRobot;
    private GameObject lastRobot;

    bool currentRobotMovingToRepairBay = false;
    bool lastRobotMovingToFinishBay = false;

    void Start()
    {
        if (File.Exists(SaveSystem.savePath))
        {
            saveData = SaveSystem.Load();
        }
        else
        {
            saveData = new SaveData();
            SaveSystem.Save(saveData);
        }
    }

    private void Update()
    {
        if (button.InTriggerArea() && canClickButton)
        {
            if (Input.GetButtonDown("Jump") && currentRobotMovingToRepairBay == false && lastRobotMovingToFinishBay == false)
            {
                InitiateGameStep();
            }
        }

        if (conveyorBelt.InTriggerArea())
        {
            if (Input.GetButtonDown("Jump") && currentRobotMovingToRepairBay == false && lastRobotMovingToFinishBay == false && currentRobot != null)
            {
                display.UpdateRobot(currentRobot.GetComponent<Robot>());
                display.Show();
            }
        }
        else
        {
            display.Hide();
        }

        if (currentRobotMovingToRepairBay)
        {
            currentRobot.transform.position = Vector3.MoveTowards(currentRobot.transform.position, robotRepairPosition.position, Time.deltaTime * 0.2f);
            if (Vector3.Distance(currentRobot.transform.position, robotRepairPosition.position) <= 0.001f)
            {
                currentRobotMovingToRepairBay = false;
                conveyorBelt.AnimateConveyor(false);
            }
        }

        if (lastRobotMovingToFinishBay)
        {
            lastRobot.transform.position = Vector3.MoveTowards(lastRobot.transform.position, robotEndPosition.position, Time.deltaTime * 0.2f);
            if (Vector3.Distance(lastRobot.transform.position, robotEndPosition.position) <= 0.001f)
            {
                lastRobotMovingToFinishBay = false;
                if (currentRobot == null)
                    conveyorBelt.AnimateConveyor(false);
                report.AddRobotScore(lastRobot.GetComponent<Robot>());
                //Debug.Log("Current report score: " + report.GetStarRating());
                score += 10;
                Destroy(lastRobot);
            }
        }

        if (currentRobot != null)
            InitialiseText(currentRobot.GetComponent<Robot>());

        RobotScore.text = "Current Score: " + score;
    }

    void InitiateGameStep()
    {
        // Animate the conveyor belt moving while things move to the correct place.
        // If we have a previous robot, move it off the screen as well, then add its "score" to the overall reported score.
        // Also populate the text screen with the type of robot we're now looking at, and what's wrong with it.
        if (currentRobot == null)
        {
            currentRobot = Instantiate(spawnBot, robotSpawnPosition.transform.position, Quaternion.identity);
            InitialiseText(currentRobot.GetComponent<Robot>());
            display.UpdateRobot(currentRobot.GetComponent<Robot>());
            conveyorBelt.AnimateConveyor(true);
            currentRobotMovingToRepairBay = true;
        }
        else
        {
            // Do the next loop.
            lastRobot = currentRobot;
            currentRobot = Instantiate(spawnBot, robotSpawnPosition.transform.position, Quaternion.identity);
            InitialiseText(currentRobot.GetComponent<Robot>());
            display.UpdateRobot(currentRobot.GetComponent<Robot>());
            conveyorBelt.AnimateConveyor(true);
            currentRobotMovingToRepairBay = true;
            lastRobotMovingToFinishBay = true;
        }
    }

    bool canClickButton = true;
    void InitialiseText(Robot rob)
    {
        bool completed = currentRobot.GetComponent<Robot>().Completed();
        RobotType.text = "Next Robot - " + rob.GetTypeFriendly();
        if (!completed)
            RobotFaults.text = rob.GetFaults();
        else
            RobotFaults.text = "Completed!";
        canClickButton = (currentRobot == null || completed);
    }    
}
