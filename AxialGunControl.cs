using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxialGunControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float totalAmmo;
    float currentAmmo;
    public float practicalAmmo;
    public float RPM;
    public float gunNumber;
    public float force;
    public ParticleSystem[] muzzleEffects;

    public Text AxialTotalAmmo;
    public Text AxialCurrentAmmo;
    public Text AxialReloadTime;

    public Transform[] barrels;

    public Rigidbody shell;

    public string Type;
    bool barrelUp;
    bool barrelDown;
    public float maxbarrelUp = 10f;
    public float maxbarrelDown = -3f;
    public float rotspeedBarrel;
    public float reloadTime;
    bool shoot = true;
    bool reloading = false;

    float counter = 0f;
    float reloadCounter = 0f;
    float shotCounter = 0f;
    bool switched = true;

    public GameObject[] axialGun;
    public Transform[] axialGunBarrel;

    public void Awake()
    {
        currentAmmo = practicalAmmo;
        totalAmmo -= practicalAmmo;
        AxialTotalAmmo.text = "Total Ammo: " + totalAmmo;
        AxialCurrentAmmo.text = "Current Ammo: " + currentAmmo;
    }

    public void Sh00t()
    {
        StartCoroutine("Shoot");
    }

    public void R3l04d()
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
        currentAmmo -= barrels.Length;
        shoot = false;
        shotCounter = RPM;
        if(Type == "T31_AC")
        {
            SoundMng.instance.ShootT31AC();
        }else if(Type == "T34_MG")
        {
            SoundMng.instance.MGFire();
        }else if(Type == "T17_MG")
        {
            SoundMng.instance.MGFire();
        }else if(Type == "T302K_MG")
        {
            SoundMng.instance.MGFire();
        }
       if(Type == "T31_AC")
        {
            while (shotCounter > 0)
            {
                yield return new WaitForSeconds(0.3f);
                Debug.Log(shotCounter);
                shotCounter--;

            }

        }
        else
        {
            while (shotCounter > 0)
            {
                yield return new WaitForSeconds(0.1f);
                Debug.Log(shotCounter);
                shotCounter--;

            }
        }
      


        foreach (ParticleSystem s in muzzleEffects)
        {
            s.Stop();
        }
        shoot = true;
  
       AxialTotalAmmo.text = "Axial Gun Total Ammo: " + totalAmmo;
        AxialCurrentAmmo.text = "Axial Gun Current Ammo: " + currentAmmo;
        //SoundMng.instance.

    }

    IEnumerator Reload()
    {
        reloadCounter = reloadTime;
        while (reloadCounter > 0)
        {
            yield return new WaitForSeconds(1f);
            reloadCounter -= 1;
            AxialReloadTime.text = "Axial Gun Reload Time: " + reloadCounter;
        }
        currentAmmo = practicalAmmo;
        totalAmmo -= practicalAmmo;
        AxialTotalAmmo.text = "Axial Gun Total Ammo: " + totalAmmo;
        AxialCurrentAmmo.text = "Axial Gun Current Ammo: " + currentAmmo;
        reloading = false;
        StopCoroutine("Reload");
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            if(switched == false)
            {
                switched = true;
            }else if(switched == true)
            {
                switched = false;
            }
        }

        if(currentAmmo <= 0 && reloading == false)
        {
            if(totalAmmo > 0)
            {
                reloading = true;
                R3l04d();
            }
            else
            {

            }
        }

        if(Input.GetButton("Fire2"))
        {
            //Debug.Log("SS"shoot);
            if(shoot)
            {
                if (currentAmmo > 0 && reloading == false)
                {
                    if (switched)
                    {
                        foreach (ParticleSystem sys in muzzleEffects)
                        {
                            sys.Play();
                        }
                       

                        Sh00t();
                    }
                }
            }
           
        }


        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");
        if (-x > 0)
        {
            barrelDown = true;
            barrelUp = false;
        }
        if (-x < 0)
        {
            barrelDown = false;
            barrelUp = true;
        }

        if (-x == 0)
        {
            barrelDown = false;
            barrelUp = false;
        }

       

        if (barrelUp == true && counter < maxbarrelUp)
        {

            foreach (Transform k in axialGunBarrel)
            {
                k.transform.Rotate(-rotspeedBarrel, 0, 0);

            }

            counter += rotspeedBarrel;

        }
        if (barrelDown == true && counter > maxbarrelDown)
        {
            foreach (Transform f in axialGunBarrel)
            {
                f.transform.Rotate(rotspeedBarrel, 0, 0);
            }

            counter -= rotspeedBarrel;
        }

        foreach(GameObject k in axialGun)
        {
            if(Type == "T17_MG" || Type == "T302K_MG")
            {
                k.transform.Rotate(0, 0, y * 3);
            }
            else
            {
                k.transform.Rotate(0, y * 3, 0);
            }
       
        }



    }
            
    }

