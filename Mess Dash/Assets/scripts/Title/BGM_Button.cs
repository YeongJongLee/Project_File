using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGM_Button : MonoBehaviour
{
    public Slider slidebar;


    private void Update()
    {
        if (slidebar.value == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        //if (transform.GetChild(0).gameObject.active == true)
        //{
        //    slidebar.value = 0;
        //}
    }
}
