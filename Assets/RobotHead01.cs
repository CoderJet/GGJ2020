using UnityEditor;
using UnityEngine;
using System.Collections;

public class RobotHead01 : MonoBehaviour
{

    int currentMood = 0;
    string[] moodOptions = new string[]
    {
     "Happy", "Indifferent", "Angry", "Error",
    };

    currentMood = EditorGUILayout.Popup("Mood", currentMood, moodOptions); 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
