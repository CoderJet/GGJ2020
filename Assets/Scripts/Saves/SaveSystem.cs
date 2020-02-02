using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static string savePath = Application.persistentDataPath + "/savefile.sf";

    public static void Save(SaveData saveData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream stream = new FileStream(savePath, FileMode.Create);

        binaryFormatter.Serialize(stream, saveData);
        stream.Close();
    }

    public static SaveData Load()
    {
        if (!File.Exists(savePath))
            return null;

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream stream = new FileStream(savePath, FileMode.Open);
        SaveData data = binaryFormatter.Deserialize(stream) as SaveData;
        stream.Close();
        return data;
    }
}