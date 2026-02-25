using UnityEngine.SceneManagement;
using UnityEngine;

public class graczhp : MonoBehaviour
{
    public float zycie = 100f;
    public void Obrazenie(float ilosc)
    {
        zycie -= ilosc;
        if (zycie <= 0f)
        {
            smierc();
        }
    }
    void smierc()
    {
        Audiomanager a = GameObject.Find("Audiomanager").GetComponent<Audiomanager>();
        a.a = 1;
        FindObjectOfType<Audiomanager>().Stopnb(a.random);
        SceneManager.LoadScene("Przegrales");
        Debug.Log("umarles");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Health")
        {
            zycie = 100f;
            Debug.Log("Uleczonko");
        }
    }
}
