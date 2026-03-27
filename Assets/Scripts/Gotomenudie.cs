using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gotomenudie : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Wychodzenie do Menu...");
        FindObjectOfType<Audiomanager>().Play("track5");

        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
    }
}
