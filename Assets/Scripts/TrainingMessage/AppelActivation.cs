using UnityEngine;

public class AppelActivation : MonoBehaviour
{

    public bool AppelCheck;

    public  GameObject ShootButton;
    public GameObject ScrollActive;
    public GameObject TextAppel;




    void Start()
    {
        ShootButton = GameObject.FindGameObjectWithTag("ShootButton");
        ScrollActive = GameObject.FindGameObjectWithTag("ScrollActive");
        TextAppel = GameObject.FindGameObjectWithTag("TextAppel");
    }



    public void Update()
    {
        TrainingMessage();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AppelCheck = true;

             ShootButton.SetActive(true);
             TextAppel.SetActive(true);
            ScrollActive.SetActive(true);
           

        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            AppelUiText.Appel += 4;

        }

    }

   
    public void TrainingMessage()
    {
        if(AppelCheck == true)
        {
            
            Destroy(gameObject);
        }    
    }




 





}
