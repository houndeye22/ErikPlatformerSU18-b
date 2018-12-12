using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    //Definierar TextMeshProUGUI som text
    private TextMeshProUGUI text;

    // Use this for initialization
    void Start()
    {
        //Sammankopplar TextMeshProUGUI med "text"
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sätter texten till poängen man har i "Coin" scriptet.
        text.text = string.Format("Score: {0:0000}", Coin.score);
    }
}
