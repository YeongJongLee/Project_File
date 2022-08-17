using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePortal : MonoBehaviour
{
    public Transform outputPortal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = outputPortal.position;
        }
    }
}
