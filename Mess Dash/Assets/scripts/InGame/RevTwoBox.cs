using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevTwoBox : MonoBehaviour
{
    bool isCol = false;
    float count;
    private float moveSpeed = 0.005f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isCol)
        {
            isCol = true;
            StartCoroutine("Move");
        }
    }
    IEnumerator Move()
    {
        while (count < 20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            count++;

            yield return new WaitForSeconds(moveSpeed);
        }
        count = 0;

    }
}
