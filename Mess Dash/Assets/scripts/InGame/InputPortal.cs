using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPortal : MonoBehaviour
{
    private float     count         = 0;
    private float     moveSpeed     = 0.005f;
    public  Transform outputPortal;
    Camera IPcamera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = outputPortal.position;

            StartCoroutine("CamMove");
        }
    }

    private void Start()
    {
        IPcamera = Camera.main;
    }

    IEnumerator CamMove()
    {
        while (count < 1f)
        {
            Vector2 pos = Vector2.Lerp(IPcamera.transform.position, 
                new Vector3(outputPortal.position.x + 4.55f, outputPortal.position.y, outputPortal.position.z), count);

            count += 0.1f;

            IPcamera.transform.position = new Vector3(pos.x, 0, IPcamera.transform.position.z);

            for(int i=0;i<4;i++)
            {
                IPcamera.transform.GetChild(i).gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(moveSpeed);
        }
        count = 0;

        IPcamera.transform.position = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z);

        for (int i = 0; i < 4; i++)
        {
            IPcamera.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
