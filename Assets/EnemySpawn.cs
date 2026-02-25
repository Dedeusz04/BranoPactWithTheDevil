using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    public float liczbaenemy;
    int i;
    public float repeatRate = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("kolizja");
            InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }
    void EnemySpawner()
    {
        i++;
            if (i <= liczbaenemy)
        {
            Instantiate(enemy, enemyPos.position, enemyPos.rotation);
        }
           
    }
}
