using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : MonoBehaviour
{

    public bool seePlayer = false;
   
   
    

    private void Update()
    {
       if(questKey.questKeyClass.activationKey == false )
        {
            ActivationScroll();
        }
        else
        {
            ActivationScrollFinall();
            OpenDoor.OpenDoorlClass.activeOpenDoor();
            DoorFrameOff.DoorFrameOffClass.DeactivateBoxCollider();

        }
        
       

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            seePlayer = true;

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            seePlayer = false;
        }
    }


    public void ActivationScroll()
    {

        if ( seePlayer == true)
        {

            Scroll.ScrollClass.activeColor();

        }
        else if (seePlayer == false)
        {

            Scroll.ScrollClass.DeactivateColor();
        }

    }

    public void ActivationScrollFinall()
    {
        if (seePlayer == true)
        {

            ScrollFinal.ScrollFinalClass.activeColor();

        }
        else if (seePlayer == false)
        {

            ScrollFinal.ScrollFinalClass.DeactivateColor();
        }


    }








}
