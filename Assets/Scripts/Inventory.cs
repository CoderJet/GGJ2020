using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] float money;
    [SerializeField] int startingHeadCount;
    [SerializeField] int startingBodyCount;
    [SerializeField] int startingArmCount;
    [SerializeField] int startingLegCount;

    public Dictionary<HeadType, int> heads;
    public Dictionary<RobotType, int> bodies;
    public Dictionary<ArmType, int> arms;
    public Dictionary<LegType, int> legs;

    void Start()
    {
        InitializeHeads();
        InitializeBodies();
        InitializeArms();
        InitializeLegs();
    }

    void InitializeHeads()
    {
        heads = new Dictionary<HeadType, int>();

        foreach (HeadType headType in (HeadType[])Enum.GetValues(typeof(HeadType)))
        {
            heads.Add(headType, startingHeadCount);
        }
    }

    void InitializeBodies()
    {
        bodies = new Dictionary<RobotType, int>();

        foreach (RobotType bodyType in (RobotType[])Enum.GetValues(typeof(RobotType)))
        {
            bodies.Add(bodyType, startingBodyCount);
        }
    }

    void InitializeArms()
    {
        arms = new Dictionary<ArmType, int>();

        foreach (ArmType armType in (ArmType[])Enum.GetValues(typeof(ArmType)))
        {
            arms.Add(armType, startingArmCount);
        }
    }

    void InitializeLegs()
    {
        legs = new Dictionary<LegType, int>();

        foreach (LegType legType in (LegType[])Enum.GetValues(typeof(LegType)))
        {
            legs.Add(legType, startingLegCount);
        }
    }
}
