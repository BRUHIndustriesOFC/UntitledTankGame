using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMG : MonoBehaviour
{

    //PUBLIC
    public float RPM;
    public float totalAmmo;
    public float practicalAmmo;
    public float MGNumber;

    public float force;


    
    
    public ParticleSystem[] muzzleEffects;
    public Text MGTotalAmmo;
    public Text MGCurrentAmmo;
    public Text MGWaitTime;

    public Rigidbody shell;
    public string tankName;
    public Transform[] barrels;
    bool barrelUp;
    bool barrelDown;

    //INTERNAL
    float shotTimer;
    public float reloadTime;
    float currentAmmo;
    float reloadTimer;
    bool reloading = false;
    bool shoot = true;

    float counter = 0f;
    private void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            if (shoot == true)
            {
                if (currentAmmo > 0 && reloading == false)
                {


                    foreach (ParticleSystem m in muzzleEffects)
                    {
                        m.Play();
                    }





                    ShootGun();
                }
                else
                {
                    //empty 
                }
            }
        }
    }
    private void Awake()
    {
        currentAmmo = practicalAmmo;
        totalAmmo -= practicalAmmo;
        MGTotalAmmo.text = "Total Ammo: " + totalAmmo;
        MGCurrentAmmo.text = "Current Ammo: "  + currentAmmo;
    }

    public void ShootGun()
    {
    

        StartCoroutine("Shoot");
    }

    public void ReloadGun()
    {
        SoundMng.instance.MGReload();
        StartCoroutine("Reload");
    }

    IEnumerator Shoot()
    {
      
            foreach (Transform barrel in barrels)
            {

                Rigidbody shellA = Instantiate(shell, barrel.position, barrel.rotation) as Rigidbody;
                shellA.velocity = -force * barrel.forward;

            }

            currentAmmo -= MGNumber;



            shoot = false;
            

            shotTimer = RPM;
            while (shotTimer > 0)
            {
                yield return new WaitForSeconds(0.1f);

                shotTimer--;
            }

            foreach (ParticleSystem s in muzzleEffects)
            {
                s.Stop();
            }

            shoot = true;
            MGTotalAmmo.text = "Total Ammo: " + totalAmmo;
            MGCurrentAmmo.text = "Current Ammo: " + currentAmmo;

            shoot = false;
            SoundMng.instance.MGFire();
            shotTimer = RPM;
            while (shotTimer > 0)
            {
                yield return new WaitForSeconds(0.1f);

                shotTimer--;
            }


            shoot = true;
            MGTotalAmmo.text = "Total Ammo: " + totalAmmo;
            MGCurrentAmmo.text = "Current Ammo: " + currentAmmo;


        


    }
        IEnumerator Reload()
        {
            reloadTimer = reloadTime;
            while (reloadTimer > 0)
            {
                yield return new WaitForSeconds(1f);

                reloadTimer -= 1;
                MGWaitTime.text = "Reload Time: " + reloadTimer.ToString();
            }


            currentAmmo = practicalAmmo;
            totalAmmo -= practicalAmmo;
            MGTotalAmmo.text = "AVAILABLE AMMO:" + totalAmmo;
            MGCurrentAmmo.text = "CURRENT AMMO:" + currentAmmo;
            reloading = false;
            StopCoroutine("Reload");
        }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //    if (Input.GetButton("Fire2"))
        //{
        //    if(shoot == true)
        //    {
        //        if(currentAmmo > 0 && reloading == false)
        //        {
                   
                   
        //                foreach (ParticleSystem m in muzzleEffects)
        //                {
        //                    m.Play();
        //                }
                    
                       
                      
                    

        //            ShootGun();
        //        }
        //        else
        //        {
        //            //empty 
        //        }
        //    }
        //}

        if(currentAmmo <= 0)
        {
            if(totalAmmo > 0)
            {
                reloading = true;
                ReloadGun();
            }
        }

        

        }
    }
        



