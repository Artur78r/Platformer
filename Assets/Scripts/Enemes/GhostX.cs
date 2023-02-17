using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostX : SawControler 

{



    private void FixedUpdate()
    {
        Patrol();
        flip();
    }




    
    public void flip()
    {

        if (RunRightSaw == true)
        {

            //transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            transform.localRotation = Quaternion.Euler( 0, 0, 0);

        }
        if (RunRightSaw == false)
        {

         //   transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }




    }










}
