using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayer : MonoBehaviour
{
    Vector3 move = new Vector3(10f, 0, 0);
    private int count;
    float moveSpeed;
    Rigidbody2D playerRigidbody2D;
    private float jumpSpeed = 25;
    private float spinSpeed = 0.0045f;
    void Start()
    {
        moveSpeed = -10f;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine("Jump");
    }
    void Update()
    {
        transform.Translate(move * Time.deltaTime, Space.World);
    }

    IEnumerator Jump()
    {
        while(true)
        {
            playerRigidbody2D.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            while (count < 90)
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 2);
                count++;

                yield return new WaitForSeconds(spinSpeed);
            }
            count = 0;

            yield return new WaitForSeconds(3f);
        }
    }
}
