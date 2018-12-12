using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //som en global variabel som finns överallt (t.ex "coin.score" som kan användas överallt utan att behöva linka scriptet i unity)
    public static int score;

    //hur mycket pengar man har
    public int amount = 1;

    //hur snabbt coin ska snurra
    private float spinSpeed = 180;

    private void Update()
    {
        //snurrar på coin med spinspeed
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }

    //Kollar om spelaren kolliderar med coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //om spelaren (och bara spelaren eller ett objekt med en "Player" tag) rör vid en coin så...
        if(collision.tag == "Player")
        {
            //får dom pengen
            Coin.score += amount;
            //pengen föstörs
            Destroy(gameObject);
        }
    }
}
