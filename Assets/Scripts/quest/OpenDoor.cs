using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public static OpenDoor OpenDoorlClass;


    SpriteRenderer OpenDoorColor;

    private void Start()
    {
        OpenDoorlClass = this;
        OpenDoorColor = GetComponent<SpriteRenderer>();

    }



    public void activeOpenDoor()
    {

        OpenDoorColor.color = new Color(255, 255, 255, 255);

    }

    

}
