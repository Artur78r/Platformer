using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Shooting : MonoBehaviour
{

    public GameObject Appel;
    public Transform AppelPosition;



    public void ButtonAppelShoot()
    {
        //Instantiate(Appel, AppelPosition.position, transform.rotation);
       player.Anim.SetTrigger("throw");

    }

    public void AnimThrow()
    {
        
        if (AppelUiText.Appel >= 1)
        {
            Instantiate(Appel, AppelPosition.position, transform.rotation);
            AppelUiText.Appel -= 1;
        }
        else
        {

        } 
            
        
    }



}
