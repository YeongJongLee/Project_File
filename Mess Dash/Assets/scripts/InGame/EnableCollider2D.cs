using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCollider2D : MonoBehaviour
{
    Transform camTransfrom;
    Collider2D obtacleCollider;

    void Start()
    {
        camTransfrom = Camera.main.transform;
        obtacleCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (camTransfrom.position.x - 10 < transform.position.x && camTransfrom.position.x + 10 > transform.position.x)
            obtacleCollider.enabled = true;
        else
            obtacleCollider.enabled = false;
    }
}
