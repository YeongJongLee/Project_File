using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomManager : MonoBehaviour
{
    public GameObject customPanel;

    void Icon_Activate()
    {
        customPanel.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        customPanel.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        customPanel.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        customPanel.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        customPanel.transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
        customPanel.transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
    }
    public void SkyColor()
    {
        GameManager.instance.SkyColor();
        Icon_Activate();
        customPanel.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
    }

    public void RedColor()
    {
        GameManager.instance.RedColor();
        Icon_Activate();
        customPanel.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
    }

    public void BlueColor()
    {
        GameManager.instance.BlueColor();
        Icon_Activate();
        customPanel.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
    }

    public void GreenColor()
    {
        GameManager.instance.GreenColor();
        Icon_Activate();
        customPanel.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
    }

    public void OrangeColor()
    {
        GameManager.instance.OrangeColor();
        Icon_Activate();
        customPanel.transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
    }

    public void YellowColor()
    {
        GameManager.instance.YellowColor();
        Icon_Activate();
        customPanel.transform.GetChild(5).GetChild(0).gameObject.SetActive(true);
    }

    public void GoToStageMenu()
    {
        GameManager.instance.StartCoroutine("GoToStageMenu");
    }
}
