using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SwitchToActive(string defaultLevel)
    {
        string levelName = PlayerPrefs.GetString("activeLevel", defaultLevel);

        SwitchScene(levelName);
    }
}
