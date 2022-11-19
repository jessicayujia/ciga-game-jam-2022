using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool isPlayerInTrashBin;
    private Rigidbody2D myRigidBody;
    private float itemGravity;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        itemGravity = myRigidBody.gravityScale;
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPlayerInTrashBin)
        {
            myRigidBody.gravityScale = -myRigidBody.gravityScale;
            //myRigidBody.velocity = new Vector2(0f, 0f);

            if (myRigidBody.gravityScale < 0) 
            {
                sp.color = new Color(1f, 1f, 1f, 0.5f);
            } else
            {
                sp.color = new Color(1f, 1f, 1f, 1f);
            }

            //myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        }

        /**
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPlayerInTrashBin && itemGravity == 0) 
            {
                //FreezeItem(0);
                itemGravity = -1;
                myRigidBody.gravityScale = -1;
                myRigidBody.velocity = new Vector2(0f, 0f);
                sp.color = new Color(1f, 1f, 1f, 0.3f);
            }
            else if(isPlayerInTrashBin && itemGravity > 0)
            {
                //FreezeItem(1);
                itemGravity = 0;
                myRigidBody.gravityScale = 0;
                myRigidBody.velocity = new Vector2(0f, 0f);
                sp.color = new Color(1f, 1f, 1f, 0.5f);
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            if (isPlayerInTrashBin && itemGravity == 0) 
            {
                //FreezeItem(0);
                //myRigidBody.freezeRotation = false;
                itemGravity = 1;
                myRigidBody.gravityScale = 1;
                myRigidBody.velocity = new Vector2(0f, 0f);
                sp.color = new Color(1f, 1f, 1f, 1f);
            }
            else if (isPlayerInTrashBin && itemGravity < 0)
            {
                //FreezeItem(1);
                itemGravity = 0;
                myRigidBody.gravityScale = 0;
                myRigidBody.velocity = new Vector2(0f, 0f);
                sp.color = new Color(1f, 1f, 1f, 0.5f);
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fox")
        {
            isPlayerInTrashBin = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Fox")
        {
            isPlayerInTrashBin = false;
        }
    }

    /**
    private void FreezeItem(int tag)
    {
        if(tag == 1)//冻结
        {
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        
    }*/

    /**
    private void OnCollisionEnter2D(Collision2D other) 
    {
        myRigidBody.bodyType = RigidbodyType2D.Static;
    }*/

}
