using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever003 : lever
{

    public override void Start()
    {
        base.Start();

        Platform = GameObject.FindGameObjectWithTag("Platform003");
    }


    private void Update()
    {
        Activation();
    }


    private void Activation()
    {
        if (ChekLever == true)
        {
            Platform.SetActive(true);

        }


    }
}
