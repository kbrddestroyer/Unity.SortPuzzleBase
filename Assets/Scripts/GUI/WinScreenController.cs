using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{
    private static WinScreenController instance;
    public static WinScreenController Instance { get => instance; }

    private GameController gameController;

    [SerializeField] private string mainMenu;
    [SerializeField] private GameObject winScreen;

    private void Awake()
    {
        gameController = GameController.Instance;

        instance = this;
    }

    public void Toggle()
    {
        winScreen.SetActive(true);
    }

    public void LevelChange()
    {
        Debug.Log("Bruh");
        StartCoroutine(gameController.SwitchScene(gameController.NextLevel));
    }

    public void toMainMenu()
    {
        StartCoroutine(gameController.SwitchScene(mainMenu));
    }
}
