using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallJumpCheckerRight : MonoBehaviour
{
    public wallJumpCheckerLeft wallJumpLeft;
    public int wallJumpCounter;
    public bool touchingWallRight;
    public GroundChecker groundCheck;
    private Rigidbody2D rbody;
    public PlayerMovement playmov;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Samma som "wallJumpCheckerRight" fast den är på högra sidan. kollar om spelaren rör vid högra sidan.
        touchingWallRight = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Kollar efter om spelaren lämnar högra sidan.
        touchingWallRight = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //om spelaren har rört vid den högra väggen en gång så...
        if (playmov.wallJumpRightTouchedOnce == true)
        {
            //Kollar den om man har försökt hoppa
            if (Input.GetButtonDown("Jump"))
            {
                //lägger den till ett nummer i wallJumpCounter
                wallJumpCounter += 1;
            }
        }
        //Om spelaren rör vid marken så...
        if (groundCheck.isGrounded == true)
        {
            //blir räknaren till noll
            wallJumpCounter = 0;
        }
    }
}