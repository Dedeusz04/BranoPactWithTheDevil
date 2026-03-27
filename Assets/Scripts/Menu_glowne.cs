using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_glowne : MonoBehaviour
{
    int f;
    public void PlayGame()
    {

        FindObjectOfType<Audiomanager>().Stop("track5");

        Audiomanager a = GameObject.Find("Audiomanager").GetComponent<Audiomanager>();
        a.a = 0;
        FindObjectOfType<Audiomanager>().Play("in");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        FindObjectOfType<Audiomanager>().Play("out");
        Application.Quit();

        Debug.Log("Było wychodzone.");
    }
    public void Soundin()
    {
        FindObjectOfType<Audiomanager>().Play("in");
    }
    public void Soundout()
    {
        FindObjectOfType<Audiomanager>().Play("out");
    }
    public void Hover()
    {
        FindObjectOfType<Audiomanager>().Play("hover");
    }

}
