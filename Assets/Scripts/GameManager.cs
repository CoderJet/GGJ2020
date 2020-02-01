using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SaveData saveData;

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
}
