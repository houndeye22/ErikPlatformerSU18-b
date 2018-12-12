using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    public static bool keyCollected;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Om spelaren kolliderar med nyckeln
        if (collision.tag == "Player")
        {
            //försvinner den eller så "plockar spelaren upp den"
            Destroy(gameObject);
            //Gör bool:en "keyCollected" sann så att man vet att spelaren har nyckeln
            keyCollected = true;


        }
    }
}
