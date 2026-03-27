using UnityEngine.Audio;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
public class Audiomanager : MonoBehaviour
{
    public Sound[] sounds;
    public int random,random2, m,a;
    // Start is called before the first frame update

    public static Audiomanager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.volume = PlayerPrefs.GetFloat("Glosnosc");
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }




    }
    void Start ()
    {

        GetComponent<Menu_Opcji>();
        Menu_Opcji x = GetComponent<Menu_Opcji>(); 
        m = sounds.Length;
        random2 = Random.Range(1, m-3 ); ;
        random = random2;
        a = 1;



    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.volume = PlayerPrefs.GetFloat("Glosnosc");
        s.source.Play();


    }
    public void Volume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }

        s.source.volume = PlayerPrefs.GetFloat("Glosnosc");
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }

        s.source.Stop();
    }
    public void Stopnb(float number)
    {
        Sound s = Array.Find(sounds, sound => sound.z == number);
        if (s == null)
        {
            return;
        }

        s.source.Stop();
    }
    public void Playrandom(float number)
    {
        Sound s = Array.Find(sounds, sound => sound.z == number);
        if (s == null)
        {
            return;
        }
        s.source.volume = PlayerPrefs.GetFloat("Glosnosc");
        s.source.Play();
    }
    void Update()
    {
        if (a == 0)
        {
            Sound s = Array.Find(sounds, sound => sound.z == random);
            if (s == null)
            {
                return;
            }
            if (!s.source.isPlaying)
            {


                Debug.Log(random2);
                if (random2 != random)
                {
                    Playrandom(random2);
                    random = random2;
                    random2 = Random.Range(1, m - 3);
                }
                else
                {
                    random2 = Random.Range(1, m - 3);
                }

            }

        }
    }

    // Update is called once per frame


}
