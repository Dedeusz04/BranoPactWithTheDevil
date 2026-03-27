using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float czulosc;
    float rotacjay = 0f;
    float rotacjax = 0f;
    public Transform model;
    // Start is called before the first frame update
    void Start()
    {
         GetComponent<Menu_Opcji>();
       
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        czulosc = PlayerPrefs.GetFloat("Czulosc") * 100f;
        float osX = Input.GetAxis("Mouse X") * czulosc * Time.deltaTime;
        float osY = Input.GetAxis("Mouse Y") * czulosc * Time.deltaTime;
        rotacjay -= osY;
        rotacjay = Mathf.Clamp(rotacjay, -90f, 90f);
        rotacjax += osX;
        transform.rotation = Quaternion.Euler(rotacjay, rotacjax, 0);
        model.rotation = Quaternion.Euler(0, rotacjax, 0);

    }
}
