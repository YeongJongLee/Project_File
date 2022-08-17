using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPosiotion : MonoBehaviour
{
    public GameObject gameObject;
    RectTransform rt;
    private void Start()
    {
        rt = transform as RectTransform;

    }
    void Update()
    {
        rt.anchoredPosition = gameObject.transform.position;
    }
}
