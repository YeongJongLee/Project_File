using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obtacle : MonoBehaviour
{
    Vector3 move = new Vector3(-10f, 0, 0);

    public float moveSpeed;
    void Start()
    {
        moveSpeed = -10f;

    }
    void Update()
    {
           transform.Translate(move * Time.deltaTime, Space.World);
    }
}
