using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 15f;

    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2 (xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Movable")
        {
            GameObject parent = other.GetComponent<GameObject>().transform.parent.gameObject;

            SpriteRenderer spParent = parent.GetComponent<SpriteRenderer>();
            spParent.color = new Color (1f, 1f, 1f, 0.5f);

            Rigidbody2D rbParent = parent.GetComponent<Rigidbody2D>(); 
            rbParent.gravityScale = -rbParent.gravityScale;

        }

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
}
