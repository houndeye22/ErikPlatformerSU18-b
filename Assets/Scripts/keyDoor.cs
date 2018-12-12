using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keyDoor : MonoBehaviour
{
    //gör ett täxtfält i unity där man kan skriva in scenen som man vill ladda
    public string sceneToLoad = "SampleScene";
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
        //Om spelaren har t.ex 10 eller 100 Coins så kan den laddas in i en ny scene.
        if (collision.tag == "Player" && keyScript.keyCollected == true)
        {
            //Coin poängen man har blir till noll
            Coin.score = 0;
            //Nyckeln förs inte med till nästa scene
            keyScript.keyCollected = false;

            //Laddar en ny scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
