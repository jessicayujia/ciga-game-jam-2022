using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3.5f;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2 (moveSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
    }
}
