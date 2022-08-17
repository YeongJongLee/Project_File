using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleManager : MonoBehaviour
{
    public void GoToStageMenu()
    {
        GameManager.instance.StartCoroutine("GoToStageMenu");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
