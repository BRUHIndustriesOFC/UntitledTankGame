using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPositionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] cameras;
    public GameObject[] gunnerCamControls;
    public GameObject[] machineGunnerCamControls;
    public Text txt;
    public string tankName;
    public int counter = 0;

    private void Awake()
    {
        TurnOffEverything();
        txt.text = "View: Driver";
        cameras[0].SetActive( true);
        //Driver
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ChooseCamera();
            
        }
    }
    public void ChooseCamera()
    {
        TurnOffEverything();
        counter++;

        if(counter == 1)
        {
            cameras[1].SetActive(true);
            txt.text = "View: Commander";
            //commander
        }
        if(counter == 2)
        {
            cameras[2].SetActive(true);
            //gunner
            txt.text = "View: Gunner";
            foreach(GameObject gunnercamControl in gunnerCamControls )
            {
                gunnercamControl.SetActive(true);
            }
        }
       
        if(counter == 3)
        {
            if(tankName == "T34A" || tankName == "T17" || tankName == "T31" ||tankName == "T17IFV" ||tankName == "T302K")
            {
                cameras[3].SetActive(true);
                txt.text = "View:Machine Gunner";
                foreach(GameObject obj in machineGunnerCamControls)
                {
                    if(obj.GetComponent<PlayerBarrelgun>() != false)
                    {
                        //foreach(Transform barrel in obj.GetComponent<PlayerBarrelgun>().barrels)
                        //{
                        //    barrel.Rotate(0, 0, 0, 0);
                        //}
                        obj.GetComponent<PlayerBarrelgun>().enabled = false;
                    }
  
                  
                    if(obj.GetComponent<PlayerMG>() == true)
                    {
                        obj.GetComponent<PlayerMG>().enabled = false;
                    }
                  

                }
                
            }
        }
        if(tankName != "T17" && tankName != "T34A" && tankName != "T31" && tankName != "T17IFV" && tankName != "T302K")
        {
            if (counter > 2)
            {
                counter = 0;
                cameras[0].SetActive(true);
                //driver
                txt.text = "View: Driver";
            }
        }else
        {
            if (counter > 3)
            {
                counter = 0;
                cameras[0].SetActive(true);
                //driver
                txt.text = "View: Driver";
                foreach (GameObject obj in machineGunnerCamControls)
                {
                    if (obj.GetComponent<PlayerBarrelgun>() != false)
                    {
                        obj.GetComponent<PlayerBarrelgun>().enabled = true;
                    }

                    
                    if (obj.GetComponent<PlayerMG>() == true)
                    {
                        obj.GetComponent<PlayerMG>().enabled = true;
                    }

                }
            }
        }
       

    }

    void TurnOffEverything()
    {
        foreach(GameObject camera in cameras)
        {
            camera.SetActive(false);
        }
        foreach(GameObject cam in gunnerCamControls)
        {
            cam.SetActive(false);
        }
    }
}
