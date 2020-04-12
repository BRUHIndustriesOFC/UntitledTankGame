using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health;
    public float PenetrationVal;
    public GameObject turret;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Helth " + Health + " pen " + PenetrationVal);
        if(Health <= 0)
        {
            //Destroy(gameObject);
            SoundMng.instance.DestroyTank();
            Destroy(gameObject);
        }
    }
}
