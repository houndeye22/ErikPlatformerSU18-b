using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontalMovement : MonoBehaviour
{
    //Gör ett nummer med decimaler som heter "speed"
    public float speed = 2f;
    //Gör en bool som kan vara sann eller falsk
    public bool left = true;

    //privat (syns inte i unity) fysik-objekt som heter rbody
    private Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        //sammanlänkar rbody med fiendens fysikobjekt
        rbody = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate är som vanlig Update men den är inte beroende på framerate, typ som update() fast * Time.deltaTime
    private void FixedUpdate()
    {   
        //funktion för kod nedan
        movementHandlerHorizontal();
    }
    //om fienden rör vid väggarna som bestämmer när den ska vända håll
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //kollar om det den kolliderar med är en osynlig vägg
        if (collision.tag == "InvisibleWall")
        {
            //vänder håll
            left = !left;
        }
    }

void movementHandlerHorizontal()
    {
        //Om fienden rör sig till vänster
        if (left == true)
        {
            //konverterar vector3 till vector2 
            rbody.velocity = -(Vector2)transform.right * speed;
            //gör så att musen "vänder" sig om
            transform.localScale = new Vector3(1, 1, 1);
        }
        //om den vänder sig åt andra hållet (höger)
        else
        {
            //gör samma sak som ovan fast åt höger
            rbody.velocity = (Vector2)transform.right * speed;
            //samma som ovan
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
