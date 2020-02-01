using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public Dictionary<HeadType, int> heads;
    public Dictionary<RobotType, int> bodies;
    public Dictionary<ArmType, int> arms;
    public Dictionary<LegType, int> legs;
    public int day;
    public float money;
}