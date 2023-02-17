using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollFinal : MonoBehaviour
{


    public static ScrollFinal ScrollFinalClass;


    SpriteRenderer ScrollFinallColor;

    private void Start()
    {
        ScrollFinalClass = this;
        ScrollFinallColor = GetComponent<SpriteRenderer>();

    }



    public void activeColor()
    {

        ScrollFinallColor.color = new Color(255, 255, 255, 255);

    }

    public void DeactivateColor()
    {
        ScrollFinallColor.color = new Color(255, 255, 255, 0);
    }







}
