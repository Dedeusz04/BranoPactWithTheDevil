using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Czułość_myszy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Czulosc"))
        {
            MouseLook ml = GetComponent<MouseLook>();
            ml.czulosc = PlayerPrefs.GetFloat("Czulosc");
            ml = Camera.main.GetComponent<MouseLook>();
            ml.czulosc = PlayerPrefs.GetFloat("Czulosc");
        }
    }
}
