using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static Block BlockClass;

    void Start()
    {
        BlockClass = this;
    }

    public void DestroyBlock()
    {

        Destroy(gameObject);
    }



}