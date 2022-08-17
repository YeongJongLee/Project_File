using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{

    public void GoToTitle()
    {
        GameManager.instance.StartCoroutine("GoToTitle");
    }
    public void GoToInGame()
    {
        GameManager.instance.StartCoroutine("GoToInGame");
    }
    public void GoToCustom()
    {
        GameManager.instance.StartCoroutine("GoToCustom");
    }

}
