using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    public float obrazenia = 10f;
    public float zasieg = 100f;
    public float impactForce = 30f;
    public Camera fpscam;
    public ParticleSystem Particle;
    public GameObject Efekt;
    public Animator strzel;
    public Animator reload;
    public float maxAmmo = 10f;
    private float currentAmmo;
    public float reloadTime = 1f;
    private bool isRealoding = false;
    public float fireRate = 1f;
    public float nextFire = 0f;
    [SerializeField]
    private Ammo Celownik; 
    // Update is called once per frame
    void Start()
    {

      Celownik = GameObject.Find("Celownik").GetComponent<Ammo>();
        currentAmmo = maxAmmo;
        strzel = GetComponent<Animator>();


    }
    void OnEnable()
    {
        isRealoding = false;
        

    }
    void Update()
    {
        Celownik.UpdateAmmo(currentAmmo);
        Celownik.MaxAmmo(maxAmmo);

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            reload.SetTrigger("Reloading");
            StartCoroutine(Reload());
            
            return;
        }
        if (isRealoding)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            reload.SetTrigger("Reloading");
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            
            nextFire = Time.time + fireRate;
            strzel.SetTrigger("Shoot");
            Strzelanie();
            
        }

    }
    void Strzelanie()
    {
        Celownik.UpdateAmmo(currentAmmo);
        currentAmmo--;
        Particle.Play();
        RaycastHit trafienie;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out trafienie, zasieg))
        {
            Debug.Log(trafienie.transform.name);
            cel target = trafienie.transform.GetComponent<cel>();
            if (target != null)
            {
                target.Obrazenie(obrazenia);
            }
            if (trafienie.rigidbody != null)
            {
                trafienie.rigidbody.AddForce(-trafienie.normal * impactForce);
            }
            GameObject ImpactGO = Instantiate(Efekt, trafienie.point, Quaternion.LookRotation(trafienie.normal));
            
            Destroy(ImpactGO, 2f);
            
        }
    }
    IEnumerator Reload()
    {
        
        isRealoding = true;
        Debug.Log("Prze³adowywanie...");
        
        yield return new WaitForSeconds(reloadTime - .25f);
   
        yield return new WaitForSeconds( .25f);
        currentAmmo = maxAmmo;
        isRealoding = false;
        Celownik.UpdateAmmo(currentAmmo);
        
    }

}
