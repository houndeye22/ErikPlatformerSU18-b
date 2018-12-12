using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    //Gör en int som heter "minimumScoreNeeded".
    public int minimumScoreNeeded = 0;
    //Gör en string med ett namn på en scen som unity ska ladda. (kan bero på vad man vill skriva här, så att man kan ladda mer än bara en scen)
    public string sceneToLoad = "SampleScene";

    //När man rör vid en trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Om spelaren har t.ex 10 eller 100 Coins så kan han laddas in i en ny bana.
        if (collision.tag == "Player" && Coin.score >= minimumScoreNeeded)
        {
            //Gör så att spelaren inte har nyckeln
            keyScript.keyCollected = false;
            //Gör coin score till 0
            Coin.score = 0;
            //Gör så att spelaren inte har nyckeln
            keyScript.keyCollected = false;
            //laddar scenen som är sceneToLoad
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
