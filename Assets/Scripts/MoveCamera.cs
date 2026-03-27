using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform Camerapos;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = Camerapos.position;
    }
}
