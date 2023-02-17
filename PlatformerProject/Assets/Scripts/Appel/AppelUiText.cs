using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppelUiText : MonoBehaviour
{

    public static int Appel;
    Text text;


    public void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = Appel.ToString();


    }





}
