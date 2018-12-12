using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;

    //När man rör vid marken eller när ens trigger rör vid den
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //gör isGrounded till sann (säger till att det går att hoppa)
        isGrounded = true;
    }

    //När man lämnar marken eller när ens trigger lämnar den
    private void OnTriggerExit2D(Collider2D collision)
    {
        //gör isGrounded till falsk (säger till att det går INTE att hoppa)
        isGrounded = false;
    }
}
