using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respoint : MonoBehaviour
{

  
  // public Transform Poitposition;

  public static Respoint respoitClass;
   public  void Start()
    {
        respoitClass = this;
    }


    public void TransformPoint()
    {
        
        player.playerClass.transform.position = new Vector2(transform.position.x, transform.position.y);
    }



}
