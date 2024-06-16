using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLevelSwitch : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    [SerializeField, Range(0f, 10f)] private float delay;

    private IEnumerator changeLevel()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextLevel);
    }

    private void Start()
    {
        StartCoroutine(changeLevel());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            StopAllCoroutines();
            SceneManager.LoadScene(nextLevel);
        }
    }
}
