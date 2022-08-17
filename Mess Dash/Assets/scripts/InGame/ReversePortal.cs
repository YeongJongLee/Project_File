using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePortal : MonoBehaviour
{
    Camera cam;
    bool isPortal = false;
    private int count;
    private float spinSpeed = 0.0001f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isPortal)
        {
            isPortal = true;    
            StartCoroutine("Spin");
        }
    }
    private void Start()
    {
        cam = Camera.main;
    }
    IEnumerator Spin()
    {
        while (count < 30)
        {
            cam.transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, cam.transform.rotation.eulerAngles.z + 3);
            count++;

            yield return new WaitForSeconds(spinSpeed);
        }
        count = 0;
        isPortal = false;
    }
}
