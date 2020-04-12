using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmokeGrenade : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform smokeGrenades;
    public Rigidbody smokeGrenade;
    public int SmokeGrenadeTotalNumber;
    public int SmokeGrenadePracticalNumber;
    public int SmokeGrenadeNumber;
    public Text smokeText;
    public float force;

    public int ReloadTime;
    int reloadTimer;

    bool reloading = false;
    void Start()
    {
        SmokeGrenadeTotalNumber -= SmokeGrenadePracticalNumber;
        SmokeGrenadeNumber = SmokeGrenadePracticalNumber;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (SmokeGrenadeNumber > 0)
            {
                StartCoroutine("ShootSmoke");
            }

        }

        if (reloading == false && SmokeGrenadeNumber <= 0)
        {
            if (SmokeGrenadeTotalNumber > 0)
            {
                StartCoroutine("ReloadSmoke");
            }
            else
            {
                //hiç kalmamış GG
                smokeText.text = "NO SMOKE GRENADE";
            }
        }
    }

    IEnumerator ReloadSmoke()
    {
        reloading = true;
        reloadTimer = ReloadTime;
        smokeText.color = Color.red;

        while (reloadTimer > 0)
        {
            yield return new WaitForSeconds(1f);
            reloadTimer -= 1;
            smokeText.text = "Reload Smoke: " + reloadTimer.ToString();
        }
        SmokeGrenadeNumber = SmokeGrenadePracticalNumber;
        SmokeGrenadeTotalNumber -= SmokeGrenadePracticalNumber;
        smokeText.color = Color.green;
        smokeText.text = "SMOKE READY";
        reloading = false;
        StopCoroutine("ReloadSmoke");
    }

    IEnumerator ShootSmoke()
    {
        smokeText.color = Color.yellow;
        smokeText.text = "Shooting";
       
            Rigidbody shellA = Instantiate(smokeGrenade, smokeGrenades.position, smokeGrenades.rotation) as Rigidbody;
            shellA.velocity = -force * smokeGrenades.forward;
        
 
        SmokeGrenadeNumber -= 1;

        yield return 0;
    }

}
