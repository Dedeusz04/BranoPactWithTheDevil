using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Monolit : MonoBehaviour
{ 
    public AudioClip monolit_dzwiek;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   private void OnTriggerEnter (Collider other)
    {
        if (monolit_dzwiek != null)
        {
            audioSource.PlayOneShot(monolit_dzwiek, 0.7f);
        }
    }

}