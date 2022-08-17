using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGM_Controller : MonoBehaviour
{
    private GameManager gameManager;
    private Slider bgmSlider;
    private void Awake()
    {
        bgmSlider = GetComponent<Slider>();
        gameManager = FindObjectOfType<GameManager>();
        bgmSlider.value = gameManager.Volume;
    }
}
