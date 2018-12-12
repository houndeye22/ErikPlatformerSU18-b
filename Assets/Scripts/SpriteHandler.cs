using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{

    public SpriteRenderer spriter;
    public Sprite leftSlider;
    public Sprite rightSlider;
    public Sprite neutral;
    public wallJumpCheckerLeft wallJumpLeft;
    public wallJumpCheckerRight wallJumpRight;
    public GroundChecker groundCheck;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Om spelaren inte är på marken så...
        if (groundCheck.isGrounded == false)
        {
            //Kollar den spelaren rör vid vänstra väggen
            if (wallJumpLeft.touchingWallLeft == true)
            {
                //Ändrar den till spriten där spelaren ser ut som den "slidar" ner på vänstra väggen
                spriter.sprite = leftSlider;
            }
            //Kollar den om spelaren rör vid högra väggen
            if (wallJumpRight.touchingWallRight == true)
            {
                //Ändrar den till spriten där spelaren ser ut som den "slidar" ner på högra väggen
                spriter.sprite = rightSlider;
            }
        }
        //Om spelaren rör vid marken
        if (groundCheck.isGrounded == true)
        {
            //Så blir spelaren neutral (eller har sin orginella sprite)
            spriter.sprite = neutral;
        }

    }
}
