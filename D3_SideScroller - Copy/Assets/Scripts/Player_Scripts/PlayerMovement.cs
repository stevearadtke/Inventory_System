using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D myrigidbody;
    Animator myAnimator;
    BoxCollider2D myCollider;
    [SerializeField] float playerSpeed= 5f;
    [SerializeField] float jumpSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        Run();
        FlipSprite();

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
       
    }

    void OnJump(InputValue value)
    {
        //bool playerIsJumping = myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (value.isPressed && myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myrigidbody.velocity += new Vector2(0f, jumpSpeed);
            //myAnimator.SetBool("isJumping", false);

        }
        
        //myAnimator.SetBool("isJumping", playerIsJumping);
    }



    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, myrigidbody.velocity.y);
        myrigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;

        if (playerVelocity.x != Mathf.Epsilon)
        {
            myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
        }


    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myrigidbody.velocity.x), 1f);
        }
    }

    
    
 




}
