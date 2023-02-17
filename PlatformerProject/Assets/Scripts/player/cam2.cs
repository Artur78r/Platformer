using UnityEngine;

public class cam2 : MonoBehaviour
{
    public Transform player;
    public float speedcam=3;
    public Vector3 pos;

    public static cam2 cameraController; 
   

    private void Awake()
    {
        cameraController = this;
                
    }

    public void Update()
    {
        following();
    }

    public virtual  void following()
    {
                
        if (! player)
        {
           player = FindObjectOfType<player>().transform;
           
        }

         pos = player.position;
         pos.z = -10f;
        
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speedcam);
    }

}





