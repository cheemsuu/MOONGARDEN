using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    float walkSpeed = 4f;
    float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    //Animations and states
    Animator animator;
    string currentAnimState;
    const string IDLE_FRAN = "IdleFran";
    const string LEFT_FRAN = "FranLeftWalk";
    const string RIGHT_FRAN = "FranRightWalk";
    const string UP_FRAN = "FranUpWalk";
    const string DOWN_FRAN = "FranDownWalk";

    public bool interactPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }

            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);

            if (inputHorizontal > 0)
            {
                ChangeAnimationState(RIGHT_FRAN);
            }

            else if (inputHorizontal < 0)
            {
                ChangeAnimationState(LEFT_FRAN);
            }

            else if (inputVertical > 0)
            {
                ChangeAnimationState(UP_FRAN);
            }

            else if (inputVertical < 0)
            {
                ChangeAnimationState(DOWN_FRAN);
            }


        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            ChangeAnimationState(IDLE_FRAN);

        }
    }
    //Animation state changer
    void ChangeAnimationState(string newState)

    {
        //stop animation interrupting itself
        if (currentAnimState == newState) return;
        //Play new animation
        animator.Play(newState);

        // update current state
        currentAnimState = newState;
    }

    public bool GetInteractPressed() 
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }
}
