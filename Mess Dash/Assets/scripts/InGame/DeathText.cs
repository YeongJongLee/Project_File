using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeathText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.text = GameManager.instance.deathCount.ToString();
    }
}
