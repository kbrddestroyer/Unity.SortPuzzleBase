using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance { get => instance; }
    
    [SerializeField] private string nextLevel;
    [SerializeField] private ColbController[] colbs;
    [SerializeField, Range(0, 100)] private int moneyAmount;

    private void Start()
    {
        instance = this;
        
        foreach (ColbController controller in colbs)
        {
            controller.FillPivotPoints();
        }
    }

    private bool Validate()
    {
        bool result = true;
        foreach (ColbController colb in colbs)
        {
            result &= colb.ValidateColb();
        }

        return result;
    }

    private IEnumerator SwitchScene()
    {
        if (!PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
        {
            int money = (PlayerPrefs.HasKey("money")) ? PlayerPrefs.GetInt("money") : 0;
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name, "pass");
            PlayerPrefs.SetInt("money", money + moneyAmount);
            PlayerPrefs.Save();
        }

        PivotPoint.Clear();
        BallController.Selected = null;
        instance = null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextLevel);
        operation.allowSceneActivation = false;
        while (operation.progress < 0.9f)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1f);
        operation.allowSceneActivation = true;
    }

    public void ValidateLevel()
    {
        if (Validate()) StartCoroutine(SwitchScene());            
    }
}
