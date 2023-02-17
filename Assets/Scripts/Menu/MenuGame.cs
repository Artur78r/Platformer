using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{



    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Level01()
    {
        SceneManager.LoadScene(2);

    }

    public void level02()
    {
        SceneManager.LoadScene(3);
    }


    public void Level03()
    {
        SceneManager.LoadScene(4);

    }


    public void Level04()
    {
        SceneManager.LoadScene(5);

    }

    public void Level05()
    {
        SceneManager.LoadScene(6);

    }


    public void menu ()
     
    {
        SceneManager.LoadScene(0);
    }


}
