using UnityEngine;

public class MoneyChest : MonoBehaviour
{
    
    private Rigidbody2D rigidbodyy2D;

    void Start()
    {
        rigidbodyy2D = GetComponent<Rigidbody2D>();

        Loot();
    }
    
    public void Loot()
    {
        rigidbodyy2D.AddForce(transform.up * 12, ForceMode2D.Impulse);                
    }
}
