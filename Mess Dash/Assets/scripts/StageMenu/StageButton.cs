using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.instance.isClear)
            transform.GetChild(0).gameObject.SetActive(true);
    }
}
