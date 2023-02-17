using UnityEngine;

public class Chest : MonoBehaviour
{

    public Transform moneyPosition;
    public GameObject PrefabMoney;
      
    public void lootChest()
    {
        Instantiate(PrefabMoney, moneyPosition.position, transform.rotation);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Player")
        {
            int i = 0;
            while ( i <= 5)
            {   
               Instantiate(PrefabMoney, moneyPosition.position, transform.rotation);
                i++;
            }

            Destroy(gameObject);
        }
    }
}
