using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bicie : MonoBehaviour
{
    GameObject target;
    GameObject bot;

    public float damage;
    void Start()
    {
        target = GameObject.Find("Gracz");
        bot = GameObject.Find("Gracz");
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer != 9)
        {
            Destroy(gameObject, 2f);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            target.GetComponent<graczhp>().Obrazenie(damage);
            Debug.Log("Dostales hita");
        }
    }
}
