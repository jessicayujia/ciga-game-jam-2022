using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 100f;
    [SerializeField] float jumpSpeed = 5.5f;
    //[SerializeField] GameObject spray;
    [SerializeField] Transform sprayBottle;
    [SerializeField] Vector2 deathkick = new Vector2 (20f, 20f);
    [SerializeField] float levelLoadDelay = 3f;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    bool isAlive = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        
        myBodyCollider.isTrigger = false;
        myFeetCollider.isTrigger = false;
    }

    void Update()
    {
        if (!isAlive) { return; }
        Walk();
        FlipSprite();
        Die();
    }

    /**
    void OnFire(InputValue value)
    {
        Instantiate(spray, sprayBottle.position, transform.rotation);
    }*/

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Jumpable"))) { return; }

        if(value.isPressed)
        {
            myRigidbody.velocity += new Vector2 (0f, jumpSpeed);
        }
    }

    void Walk()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed * Time.fixedDeltaTime, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isWalking", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon; // check movement direction

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Bat")))
        {
            isAlive = false;
            myAnimator.SetTrigger("isDead");
            //myRigidbody.velocity = deathkick;
            myBodyCollider.isTrigger = true;
            myFeetCollider.isTrigger = true;

            SpriteRenderer mySpriteRenderer = GetComponent<SpriteRenderer>();
            mySpriteRenderer.color = new Color (1f, 1f, 1f, 0.3f);

            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
