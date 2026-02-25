using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponswitch : MonoBehaviour

{
    public int selectedWeapon = 0;
    private int i = 0;
    public int previousSelectedWeapon;
    public int a = 0;
    public Playerpick nip;

    void Start()
    {
        nip = GameObject.Find("Gracz").GetComponent<Playerpick>();
        SelectWeapon();
    }


    // Update is called once per frame
    void Update()
    {

        int previousSelectedWeapon = selectedWeapon;


        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {

                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
            if (previousSelectedWeapon != selectedWeapon)
            {

                SelectWeapon();
            }
            else if (a == 1)
            {
                SelectWeapon();
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
               
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
            if (previousSelectedWeapon != selectedWeapon)
            {

                SelectWeapon();
            }
            else if (a == 1)
            {
                SelectWeapon();
            }
        }
    }
    public void SelectWeapon()
    {
        i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
               
                weapon.gameObject.SetActive(true);
                nip.nig = GameObject.Find(weapon.name).GetComponent<WeaponPick>();
            }
            else
            {
                weapon.gameObject.SetActive(false);


                
            }
            i++;
        }
    }
}
