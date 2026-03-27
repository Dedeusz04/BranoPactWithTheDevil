using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Pauzy : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    private int i;
    public WeaponPick counter;
    public void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && i == 0)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && i == 1)
        {
            Resume();
        }
         
    }

    public void Resume ()
    {
        i = 0;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<Audiomanager>().Play("in");
    }

    void Pause ()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        i = 1;
    }

    public void LoadMenu()
    {
        counter = GameObject.FindWithTag("CanGrab").GetComponent<WeaponPick>();
        counter.i = 0;
        Time.timeScale = 1f;
        Audiomanager a = GameObject.Find("Audiomanager").GetComponent<Audiomanager>();
        a.a = 1;
        Debug.Log("Wychodzenie do Menu...");
        FindObjectOfType<Audiomanager>().Stopnb(a.random);
        FindObjectOfType<Audiomanager>().Play("track5");
        FindObjectOfType<Audiomanager>().Play("out");

        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = false;
    }
    public void Hover()
    {
        FindObjectOfType<Audiomanager>().Play("hover");
    }
}
