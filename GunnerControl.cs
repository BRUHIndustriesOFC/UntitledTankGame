using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public CameraEffect ef;
    bool zoomed = false;
    bool thermal = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z");
            if (zoomed == false)
            {
                //zoom
                cam.fieldOfView = 30f;
                zoomed = true;
            }
            else if (zoomed == true) 
            {
                cam.fieldOfView = 60f;

                zoomed = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (thermal == false)
            {
                //zoom
                ef.enabled = true;
                thermal = true;
            }
            else if (thermal == true)
            {

                ef.enabled = false;
                thermal = false;
            }
        }
    }
}
