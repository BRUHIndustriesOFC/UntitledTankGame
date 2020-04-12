using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarrelgun : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeBetweenShots = 0.3f;
    float shotTimer;
    float reloadTimer;
    public float totalAmmunition;
    public float practicalAmmunition;
    public float currentAmmunition;
    public float gunNumber;
    public float force = 100f;
    public float reloadTime;
    public ParticleSystem[] muzzle;
    public Text totalAmmo;
    public Text currentAmmo;
    public Text waitTime;
    bool reloading = false;
    public Transform[] barrels;
    public Rigidbody shellPrefab;
    public string TANKMODEL;



    private void Update()
    {
        if (Input.GetButton("Fire1") == true)
        {
            if (shut == true)
            {
                if (currentAmmunition > 0 && reloading == false) // eğer yüklü olan mermi varsa
                {

                    foreach (ParticleSystem m in muzzle)
                    {
                        m.Play();


                    }
                    ShootGun();
                    //transform.gameObject.GetComponent<Rigidbody>().AddForce(transform.GetComponent<Rigidbody>().mass * 2, 10000, 10000);
                }


            }

        }
    }


    private void Awake()
    {
        // ResetGun();
        currentAmmunition = practicalAmmunition;
        totalAmmunition -= practicalAmmunition;
        totalAmmo.text = "AVAILABLE AMMO" + totalAmmunition;
        currentAmmo.text = "CURRENT AMMO:" + currentAmmunition;

    }

    public void ShootGun()
    {
        StartCoroutine("CoShoot");

    }
    public void ReloadG()
    {

        if (TANKMODEL == "T65A")
        {
            SoundMng.instance.ReloadT65A();
        }
        if (TANKMODEL == "T40")
        {
            SoundMng.instance.ReloadT40();
        }
        if(TANKMODEL == "T34A")
        {
            SoundMng.instance.ReloadT40();
        }
        if(TANKMODEL == "T31")
        {
            SoundMng.instance.ReloadT31();
        }
        if(TANKMODEL == "T17IFV")
        {
            SoundMng.instance.ReloadT40();
        }
        if(TANKMODEL == "T302L")
        {
            SoundMng.instance.ReloadT31();
        }
            
            
        StartCoroutine("Reload");
    }

   



    bool shut = true;
    private void FixedUpdate()
    {
        
        //if(Input.GetButton("Fire1")== true)
        //{
        //   if(shut == true )
        //    {
        //        if(currentAmmunition > 0 && reloading == false) // eğer yüklü olan mermi varsa
        //        {
                   
        //          foreach(ParticleSystem m in muzzle)
        //            {
        //                m.Play();
                       
                        
        //            }
        //            ShootGun();
                   
        //        }
                
    
        //    }
           
        //}
        if (currentAmmunition <= 0)
        {

            if (totalAmmunition > 0 && reloading == false) //yüklenebilecek mermi varsa
            {
                reloading = true;
                ReloadG();

            }
        }


    }

    

    IEnumerator CoShoot()
    {
       
        foreach (Transform barrel in barrels)
        {
            Rigidbody shellA = Instantiate(shellPrefab, barrel.position, barrel.rotation) as Rigidbody;
            shellA.velocity = -force * barrel.forward;
           
        }
   

        if (TANKMODEL == "T65A")
        {
            SoundMng.instance.ShootBarrelGun();
        }
        if (TANKMODEL == "T40")
        {
            SoundMng.instance.ShootT40();
        }
        if(TANKMODEL == "T34A")
        {
            SoundMng.instance.ShootT34();
        }
        if(TANKMODEL == "T31")
        {
            SoundMng.instance.ShootT31();
        }
        if(TANKMODEL == "T17IFV")
        {
            SoundMng.instance.ShootT17IFV();
        }
        if(TANKMODEL == "T302K")
        {
            SoundMng.instance.ShootT34();
        }
        currentAmmunition -= gunNumber;
        shut = false;
        shotTimer = timeBetweenShots;
        
        while(shotTimer > 0)
        {
            yield return new WaitForSeconds(0.3f);
          
            shotTimer--;
        }
      
        foreach(ParticleSystem s in muzzle)
        {
            s.Stop();
        }
        shut = true;
        totalAmmo.text = "AVAILABLE AMMO:" + totalAmmunition;
        currentAmmo.text = "CURRENT AMMO:" + currentAmmunition;
    
    }

    IEnumerator Reload()
    {
        
        reloadTimer = reloadTime;
        while(reloadTimer > 0)
        {
            yield return new WaitForSeconds(1f);

            reloadTimer-=1;
            waitTime.text = "Reload Time: " + reloadTimer.ToString();
        }
    
        currentAmmunition = practicalAmmunition;
        totalAmmunition -= practicalAmmunition;
        totalAmmo.text = "AVAILABLE AMMO:" + totalAmmunition;
        currentAmmo.text = "CURRENT AMMO:" + currentAmmunition;
        reloading = false;
        StopCoroutine("Reload");
    }
   


}
