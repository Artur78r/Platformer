using UnityEngine;

public class lever : MonoBehaviour
{

    public bool ChekLever;
    public GameObject Platform;


    public virtual void Start()
    {
        Platform = GameObject.FindGameObjectWithTag("Platform001");
    }

    private void Update()
    {
        ActivationPlatform();
    }


   public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            ChekLever = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (collision.gameObject.tag == "Apple")
        {
            ChekLever = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void ActivationPlatform()
    {
        if(ChekLever == true )
        {
            Platform.SetActive(true);
        }

    }






}
