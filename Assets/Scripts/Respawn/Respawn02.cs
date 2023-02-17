using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn02 : MonoBehaviour
{

    public static Respawn02 _respawn02;

    public Transform RespawnPointPosition;
    public GameObject PrefabPlayer;



    public void Awake()
    {
        _respawn02 = this;

    }


    public void RespawnPoint002()
    {

        GameObject player = Instantiate(PrefabPlayer, RespawnPointPosition.position, Quaternion.identity);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rrespawn.SpawnStart = false;
            Rrespawn.SpawnPoint01 = false;
            Rrespawn.RespawnPoint02 = true;


        }



    }



}
