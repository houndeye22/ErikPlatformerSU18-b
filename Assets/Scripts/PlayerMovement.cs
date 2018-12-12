using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //nummer med decimaler som man kan ändra i unity, bestämmer hur snabbt spelaren rör på sig.
    public float moveSpeed = 6f;
    //nummer med decimaler som man kan ändra i unity, bestämmer hur snabbt spelaren hoppar.
    public float jumpSpeed = 12f;
    public int wallJumpSpeedLeft;
    public int wallJumpSpeedRight;

    public bool wallJumpRightTouchedOnce;
    public bool wallJumpLeftTouchedOnce;

    public float dragStrength;

    //Sammankopplar ett annat script så man kan använda en funktion från den
    public GroundChecker groundCheck;
    //Samma som ovan
    public wallJumpCheckerLeft wallJumpLeft;
    public wallJumpCheckerRight wallJumpRight;

    //Fysik-object som spelaren kontrollerar
    private Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        //Hämtar rbody från sig själv
        rbody = GetComponent<Rigidbody2D>();
    }




    //Jag är helt medveten om hur kladdig och onödig många delar av koden är nedan.
    //Jag hade kunnat använda bools istället för integers och vice versa, men jag blev glad att det fungerade.
    //Jag vågar nästan inte röra på koden för att jag har en deadline och jag var rädd för att göra sönder allt.
    


    // Update is called once per frame
    void Update()
    {
        //print(rbody.velocity);

        //Sätter velocity på spelaren i direktionen (i vector 2) ditåt man trycker * movespeed
        rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rbody.velocity.y);

        //om man trycker på "Hopp" knappen
        if (Input.GetButtonDown("Jump"))
        {
            //Kollar om spelaren är på marken från scriptet "groundCheck"
            if (groundCheck.isGrounded == true)
            {
                //Spelarens hastighet är X hastigheten med jumpSpeed
                rbody.velocity = new Vector2(rbody.velocity.x, jumpSpeed);
            }

        }

        WallJumpHandler();
    }


    void WallJumpHandler()
    {
        //om spelaren inte rör vid marken
        if (groundCheck.isGrounded == false)
        {
            //om spelaren rör vid den vänstra väggen
            if (wallJumpLeft.touchingWallLeft == true)
            {
                //blir dragkraften emot väggen 0 (vet inte hur jag tänkte här, har inte tid att fixa det nu)
                rbody.drag = 0;
                //om wallJumpCounter är under eller lika med ett så att man inte kan hoppa flera gånger på en vägg
                if (wallJumpLeft.wallJumpCounter <= 1)
                {
                    //Kollar den efter ett hopp
                    if (Input.GetButtonDown("Jump"))
                    {
                        //lägger till kraften uppåt som man får av ett hopp
                        rbody.velocity = new Vector2(0, jumpSpeed);
                    }
                }
            }
            //Om den inte rör vid den vänstra väggen så...
            if (wallJumpLeft.touchingWallLeft == false)
            {
                //blir draget emot världen 0 (här fattar jag hur jag tänkte, aja)
                rbody.drag = 0;
            }
        }
        //Om spelaren inte rör vid marken
        if (groundCheck.isGrounded == false)
        {
            //Om spelaren rör vid den högra väggen
            if (wallJumpRight.touchingWallRight == true)
            {
                //dragkraften mot väggen blir till det man skrivit i unity
                rbody.drag = dragStrength;

                //om walljumpcounter på högra väggen är ett eller mindre...
                if (wallJumpRight.wallJumpCounter <= 1)
                {
                    //Om man trycker ned "hopp" knappen
                    if (Input.GetButtonDown("Jump"))
                    {
                        //lägg till kraften som för en uppåt
                        rbody.velocity = new Vector2(0, jumpSpeed);
                    }
                }
            }
            //Om man inte rör vid högra väggen... så blir dragkraften till hur stark man har skrivit att den ska vara i unity(förstår inte hur jag tänkte här???)
            if (wallJumpRight.touchingWallRight == false)
            {
                //så blir dragkraften till hur stark man har skrivit att den ska vara i unity(förstår inte hur jag tänkte här ???)
                rbody.drag = dragStrength;
            }
        }
        //om man rör vid marken
        if (groundCheck.isGrounded == true)
        {
            //draget blir noll
            rbody.drag = 0;

            //vänstra väggen har blivit rörd noll gånger
            wallJumpLeftTouchedOnce = false;
            //högra väggen har blivit rörd noll gånger
            wallJumpRightTouchedOnce = false;

            //räknarna som räknar hur många gånger man har försökt hoppa på väggen blir till noll
            wallJumpLeft.wallJumpCounter = 0;
            wallJumpRight.wallJumpCounter = 0;
        }

        //om man rör vid den högra väggen
        if (wallJumpRight.touchingWallRight == true)
        {
            //har den högra väggen blivit rörd en gång och den vänstra noll gånger
            wallJumpRightTouchedOnce = true;
            wallJumpLeftTouchedOnce = false;
            //om man försöker hoppa
            if (Input.GetButtonDown("Jump"))
            {
                //Om den högra väggen har blivit rörd en gång
                if (wallJumpRightTouchedOnce == true)
                {
                    //ta bort en räknare på den vänstra räknaren och lägg till en på den högra (så man kan hoppa från vägg till vägg)
                    wallJumpRight.wallJumpCounter = 1;
                    wallJumpLeft.wallJumpCounter = -1;
                }
            }
        }
        //Om man har rört vid den vänstra väggen en gång så...
        if (wallJumpLeft.touchingWallLeft == true)
        {
            //har den vänstra väggen blivit rörd och den högra inte det
            wallJumpLeftTouchedOnce = true;
            wallJumpRightTouchedOnce = false;
            //om man försöker hoppa
            if (Input.GetButtonDown("Jump"))
            {
                //om den vänstra är den senaste som är rörd
                if (wallJumpLeftTouchedOnce == true)
                {
                    //lägg till en siffra i det vänstra ledet och dra bort en från den högra
                    wallJumpLeft.wallJumpCounter = 1;
                    wallJumpRight.wallJumpCounter = -1;
                }
            }
        }
    }
}
