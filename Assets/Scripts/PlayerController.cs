using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    Rigidbody rigid;
    Animator animator;

    float speed = 5;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    public void MoveTo(Vector3 direction)
    {
        direction = direction.normalized * speed * Time.deltaTime;
        rigid.MovePosition(transform.position + direction);
    }
    public void LookAt(Vector2 lookAt)
    {
        
    }
}
