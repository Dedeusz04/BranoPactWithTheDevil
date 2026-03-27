using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPick : MonoBehaviour
{

    public gunscriptauto gunscript1;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;
    public float dropForwardForce, dropUpwardForce;
    public bool equipped;
    public Animator animacja;
    public int i;
    public Weaponswitch ni;
    void Start()
    {
        ni = GameObject.Find("EquipPos").GetComponent<Weaponswitch>();
        if (!equipped)
        {
           
            gunscript1.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
           
            gunscript1.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            

        }
    }
    private void Update()
    {
    }
    public void PickUp()
    {
        rb.detectCollisions = false;
        animacja.GetComponent<Animator>().enabled = true;
        equipped = true;
        
        
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        if (ni.a >= 1)
        {
            ni.SelectWeapon();

        }











        rb.isKinematic = true;
        coll.isTrigger = true;
        gunscript1.enabled = true;
       
    }
    public void Drop()
    {
        rb.detectCollisions = true;
        ni.a = ni.a - 1;
        animacja.GetComponent<Animator>().enabled = false;
       
        gunscript1.enabled = false;
        equipped = false;
        
        transform.SetParent(null);
        rb.isKinematic = false;
        coll.isTrigger = false;
        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        
        



        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
       
    }
}
