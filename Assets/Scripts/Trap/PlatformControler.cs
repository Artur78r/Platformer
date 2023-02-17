using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControler : SawControler
{

    private void FixedUpdate()
    {
        MovePlatform();
    }




    public void MovePlatform()
    {

        Patrol();


    }
}
