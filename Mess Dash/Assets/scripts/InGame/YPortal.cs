using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPortal : MonoBehaviour
{
    bool isPortal = false;
    Camera YPcamera;
    private int count;
    private float spinSpeed = 0.0001f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPortal)
        {
            isPortal = true;
            StartCoroutine("Spin");
        }
    }
    IEnumerator Spin()
    {
        while (count < 90)
        {
            YPcamera.transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y + 2, 
                Camera.main.transform.rotation.eulerAngles.z);

            for (int i = 0; i < 4; i++)
            {
                YPcamera.transform.GetChild(i).gameObject.SetActive(false);
            }
            count++;

            if(count == 45)
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z * -1);

            yield return new WaitForSeconds(spinSpeed);
        }
        count = 0;

        for (int i = 0; i < 4; i++)
        {
            YPcamera.transform.GetChild(i).gameObject.SetActive(true);
        }

        isPortal = false;
    }

    private void Start()
    {
        YPcamera = Camera.main;
    }
}
