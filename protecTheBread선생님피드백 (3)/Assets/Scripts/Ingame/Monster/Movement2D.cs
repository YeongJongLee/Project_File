using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{

    
    
    //[SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    Enemy enemy;

    public float MoveSpeed;

    private void Start()
    {
        moveSpeed = MoveSpeed;
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        
        if(enemy.animator.GetBool("RightAttack") == true)
            moveSpeed = 0.0f;
        else if(enemy.animator.GetBool("LeftAttack") == true)
            moveSpeed = 0.0f;
        else
            moveSpeed = MoveSpeed;

        if (enemy.isSlow == true)
            moveSpeed = moveSpeed * 0.7f;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
