using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InGameManager : MonoBehaviour
{
    public void GoToStageMenu2()
    {
        GameManager.instance.deathCount = 0;
        GameManager.instance.StartCoroutine("GoToStageMenu2");
    }
}
