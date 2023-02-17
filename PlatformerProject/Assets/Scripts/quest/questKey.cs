using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questKey : MonoBehaviour
{
    public static questKey questKeyClass;

    public  bool activationKey = false;

   

   

    public void Start()
    {
        questKeyClass = this;


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activationKey = true;

            gameObject.SetActive(false);
        }
    }




}
