using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : MonoBehaviour
{
    public AudioSource shootBarrelGun;
    public AudioSource shellExplosion;
    public AudioSource T65AReload;
    public AudioSource T40Shoot;
    public AudioSource T40Reload;
    public AudioSource smokeEffect;
    public AudioSource MGFire1;
    public AudioSource MGReload1;
    public AudioSource T34AShoot;
    public AudioSource TankSpeedUp;
    public AudioSource TankGo;
    public AudioSource tankDestroy;
    public AudioSource T31Fire;
    public AudioSource T31Reload;
    public AudioSource T31ACFire;
    public AudioSource T17IFVFire;
    public static SoundMng instance = null;
    
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ShootBarrelGun()
    {
        shootBarrelGun.Play();

    }

    public void ShellExplosion()
    {
        shellExplosion.Play();
    }

    public void ReloadT65A()
    {
        T65AReload.Play();
    }
   
    public void ShootT40()
    {
        T40Shoot.Play();
    }

    public void ReloadT40()
    {
        T40Reload.Play();
    }

    public void smokeExplosion()
    {
        smokeEffect.Play();
    }

    public void MGFire()
    {
        MGFire1.Play();
    }

    public void MGReload()
    {
        MGReload1.Play();
    }

    public void ShootT34()
    {
        T34AShoot.Play();
    }

    public void StartTank()
    {
        TankSpeedUp.Play();
    }

    public void DriveTank()
    {
        TankGo.Play();
    }

    public void DestroyTank()
    {
        tankDestroy.Play();
    }


    public void ShootT31()
    {
        T31Fire.Play();
    }

    public void ReloadT31()
    {
        T31Reload.Play();
    }

    public void ShootT31AC()
    {
        T31ACFire.Play();
    }

    public void ShootT17IFV()
    {
        T17IFVFire.Play();
    }

}
