using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Fox")
        {
            Destroy(gameObject);
            LevelExit.isKeyPickedUp = true;
        }
    }
}
