using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevObtacle : MonoBehaviour
{
    float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }
}
