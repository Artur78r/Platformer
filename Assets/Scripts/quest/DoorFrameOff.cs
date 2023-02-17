using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFrameOff : MonoBehaviour
{

    public static DoorFrameOff DoorFrameOffClass;

  public  BoxCollider2D boxDoor;

    public void Start()
    {
        DoorFrameOffClass = this;
    }


    public void DeactivateBoxCollider()
    {
        Destroy(boxDoor);



    }




}
