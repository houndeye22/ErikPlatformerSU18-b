using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVerticalMovement : MonoBehaviour
{
    //Gör ett nummer med decimaler som heter "speed"
    public float speed = 2f;
    //Gör en bool som kan vara sann eller falsk
    public bool up = true;

    public float timer;

    public SpriteRenderer spriteRend;
    public Sprite wingFlap;
    public Sprite wingNeutral;

    //privat (syns inte i unity) fysik-objekt som heter rbody
    private Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        //sammanlänkar rbody med fiendens fysikobjekt
        rbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //Timer som ökar med en sekun när en sekund går
        timer += Time.deltaTime;
        //Om timern är mindre än en halv sekund så...
        if (timer < 0.5f)
        {
            //Visa spriten där humlan inte rör på "vingarna"
            spriteRend.sprite = wingNeutral;
        }

        //Om timern är mer än en halv sekund
        if (timer >= 0.5f)
        {
            //Visa spriten där humlan rör på vingarna
            spriteRend.sprite = wingFlap;
            
        }
        //När timern blir en sekund...
        if (timer >= 1)
        {
            //Starta om timern
            timer = 0;
        }
    }

    //FixedUpdate är som vanlig Update men den är inte beroende på framerate, typ som update fast * Time.deltaTime
    void FixedUpdate()
    {
        enemyMovementVertical();
    }

    //om fienden rör vid väggarna som bestämmer när den ska vända håll
    //OnTriggerEnter2D är en funktion som kollar efter om två saker kolliderar, så om någonting rör vid någonting annat så händer...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //kollar om det den kolliderar med är en osynlig vägg
        if (collision.tag == "InvisibleWall")
        {
            //vänder håll
            up = !up;
        }
    }



    void enemyMovementVertical()
    {
        if (up == true)
        {
            //konverterar vector3 till vector2 
            rbody.velocity = -(Vector2)transform.up * speed;
            transform.localScale = new Vector3(1, 1, 1);
        }
        //om den vänder sig åt andra hållet (höger)
        else
        {
            //gör samma sak som ovan fast åt höger
            rbody.velocity = (Vector2)transform.up * speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

