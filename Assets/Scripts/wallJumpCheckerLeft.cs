using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallJumpCheckerLeft : MonoBehaviour
{
    public wallJumpCheckerRight wallJumpRight;
    public int wallJumpCounter;
    public bool touchingWallLeft;
    public GroundChecker groundCheck;
    public PlayerMovement playmov;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //om boxcolliderns trigger rör vid en vägg (kan bara vara den vänstra) så sätter den "touchingWallLeft" till sann, spelaren rör vid väggen.
        touchingWallLeft = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //När boxcolliderns trigger lämnar väggen så rör spelaren inte längre väggen.
        touchingWallLeft = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Om spelaren har rört vid den vänstra väggen en gång så...
        if (playmov.wallJumpLeftTouchedOnce == true)
        {
            //Kollar den om man klickar "hopp" knappen
            if (Input.GetButtonDown("Jump"))
            {
                //Lägger till en etta i wallJumpCounter.
                wallJumpCounter += 1;
            }
        }
        //om spelaren rör vid marken
        if (groundCheck.isGrounded == true)
        {
            //om man rör vid marken igen så blir walljumpcounter noll igen.
            wallJumpCounter = 0;
        }
    }
}




