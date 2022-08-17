using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverse : MonoBehaviour
{
    Rigidbody2D gravityRigidbody2D;
    private bool isCollision = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollision = true;
            gravityRigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollision = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isCollision)
        {
                isCollision = false;
                gravityRigidbody2D.gravityScale *= -1;
                transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
