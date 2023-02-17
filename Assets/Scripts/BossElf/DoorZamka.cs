using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorZamka : MonoBehaviour
{
    public static DoorZamka doorZamkaClass;

    Animator anim;


    public Transform positionEnemy;
    public GameObject PrefabEnemy;

    void Start()
    {
        doorZamkaClass = this;
        anim = GetComponent<Animator>();
    }


    public void OpenDoor()
    {
        anim.SetTrigger("OpenDoor");

    }


    public void RespawnEnemy()
    {
        Instantiate(PrefabEnemy, positionEnemy.position, transform.rotation);
    }

}
