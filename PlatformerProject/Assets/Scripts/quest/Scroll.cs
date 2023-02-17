using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public static Scroll ScrollClass;


     SpriteRenderer ScrollColor;

    private void Start()
    {
        ScrollClass = this;
        ScrollColor = GetComponent<SpriteRenderer>();

    }



    public void activeColor()
    {

        ScrollColor.color = new Color(255, 255, 255, 255);

    }

    public void DeactivateColor()
    {
        ScrollColor.color = new Color(255, 255, 255, 0);
    }





}
