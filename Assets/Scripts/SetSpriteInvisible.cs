using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteInvisible : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //Sammankopplar spriterenderern, som ska sen göra någonting osynligt
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
