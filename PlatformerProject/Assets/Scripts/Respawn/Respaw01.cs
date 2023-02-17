using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respaw01 : MonoBehaviour
{
    public static Respaw01 respaw01;


    public Transform Respawn01position;
    public GameObject playerPrefab;

    


    public void Awake()
    {

        respaw01 = this;
    }



    public void Respawnpoin01()
    {
        GameObject player = Instantiate(playerPrefab, Respawn01position.position, Quaternion.identity);


    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rrespawn.SpawnStart = false;
            Rrespawn.SpawnPoint01 = true;

                 

        }


    }



}
