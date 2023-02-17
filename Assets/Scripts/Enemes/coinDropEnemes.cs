using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinDropEnemes : Chest
{
    public static coinDropEnemes _coinDropEnemes;
    public void Start()
    {
        _coinDropEnemes = this;      
    }

    public void coin()
    {
       lootChest();      
    }

    public new void OnTriggerEnter2D(Collider2D collision) 
    { }
}
