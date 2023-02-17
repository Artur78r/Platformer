using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever001 : lever
{


    public override void Start()
    {
        base.Start();

        Platform = GameObject.FindGameObjectWithTag("Platform002");
    }


    private void Update()
    {
        deactivation();
    }


    private void deactivation()
    {
        if( ChekLever == true)
        {
            Platform.SetActive(false);

        }


    }







}
