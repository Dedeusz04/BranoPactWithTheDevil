using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu_Opcji : MonoBehaviour
{


    public Slider mouseSensitivitySlider;

    void Start()
    {
        
        if (PlayerPrefs.HasKey("Czulosc"))
        {
            mouseSensitivitySlider.value = PlayerPrefs.GetFloat("Czulosc");
            
            Debug.Log("Zmieniono czulosc na " + mouseSensitivitySlider.value + ".");
        }


    }
    
    public void SetVolume (float Glosnosc)
    
    {
        if (!Application.isPlaying) return;
        PlayerPrefs.SetFloat("Glosnosc", Glosnosc);
        FindObjectOfType<Audiomanager>().Volume("track5");
        Debug.Log("Ustawiono Glosnosc na " + Glosnosc + " db." );
    }

    public void SetMouseSensitivity(float val)
    {
        if (!Application.isPlaying) return;
        PlayerPrefs.SetFloat("Czulosc", val);
        Debug.Log("Ustawiono czulosc na " + val + ".");
    }

}
