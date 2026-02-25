using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerpick : MonoBehaviour
{
    public Camera kam;
    public float pickuprange = 3f;
    public Weaponswitch ni;
    public WeaponPick nig;
    public string name;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        ni = GameObject.Find("EquipPos").GetComponent<Weaponswitch>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Physics.Raycast(kam.transform.position, kam.transform.forward, out hit, pickuprange) && Input.GetKeyDown(KeyCode.E) && ni.a < 3)
        {

            if (hit.transform.tag == "CanGrab")
            {
                name = hit.transform.name;
                nig = GameObject.Find(name).GetComponent<WeaponPick>();
                if (!nig.equipped)
                {
                    ni.a = ni.a + 1;
                    
                    nig.PickUp();
                }

        }   }
        if (Input.GetKeyDown(KeyCode.Q)&& nig.equipped) nig.Drop();
    }
}
