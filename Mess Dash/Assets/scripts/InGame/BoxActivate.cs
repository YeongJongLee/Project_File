using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxActivate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obtacle"))
            collision.transform.GetChild(0).gameObject.SetActive(true);
    }
}
