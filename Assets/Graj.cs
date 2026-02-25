using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Graj : MonoBehaviour
{


    // Update is called once per frame
    public void Play()
     {
        FindObjectOfType<Audiomanager>().Stop("track6");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }
}
