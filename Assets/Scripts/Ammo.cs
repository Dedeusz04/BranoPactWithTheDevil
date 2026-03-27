using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;
    public  Text maxAmmo;
    // Start is called before the first frame update
    public void UpdateAmmo(float count)
    {
        _ammoText.text = "Ammo: " + count;
    }
    public void MaxAmmo(float count1)
    {
        maxAmmo.text = "/" + count1;
    }
}
