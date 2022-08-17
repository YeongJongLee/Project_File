using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Death_Text : MonoBehaviour
{
    TextMeshProUGUI deathText;

    void Start()
    {
        deathText = GetComponent<TextMeshProUGUI>();

        deathText.text = "Total Death : " + GameManager.instance.deathCount.ToString();
    }
}
