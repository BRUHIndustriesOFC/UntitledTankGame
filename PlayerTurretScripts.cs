using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotSpeed = 1f;
    bool left = false;
    bool right = false;
    public string tANKNAME;
    public float rotspeedBarrel =10f;
    public float maxbarrelDown = -10f;
    public float maxbarrelUp = 1000f;
    float counter = 0f;
    public static bool barrelUp = false;
    bool barrelDown = false;

    public  GameObject[] barrels;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void RotateLeft()
    {
        left = true;
    }
    public void RotateRight()
    {
        right = true;
    }

    public void BarrelUp()
    {
        barrelUp = true;
    }

    public void BarrelDown()
    {
        barrelDown = true;
    }

    private void FixedUpdate()
    {
        float a = Input.GetAxis("Mouse X");

        float b = Input.GetAxis("Mouse Y");
        //
        //  transform.Rotate(0, 0, a);
       

      
        //barrel.transform.Rotate(-b * 2, 0, 0);
        //yukarı doğru b -
        //aşağı doğru b
        
      
            if (tANKNAME == "T31" )
            {
               
                //transform.Rotate(0, a, 0);
                transform.Rotate(0, 0, a);
            }
            else
            {
                //transform.Rotate(0, -rotSpeed, a);
                transform.Rotate(0, 0, a);
            }

            if (-b > 0)
            {
                barrelDown = true;
                barrelUp = false;
            }
            if (-b < 0)
            {
                barrelDown = false;
                barrelUp = true;
            }

            if (-b == 0)
            {
                barrelDown = false;
                barrelUp = false;
            }



            if (barrelUp == true && counter < maxbarrelUp)
            {
           
                foreach (GameObject k in barrels)
                {
                    k.transform.Rotate(-rotspeedBarrel, 0, 0);

                }
                counter += rotspeedBarrel;

            }
            if (barrelDown == true && counter > maxbarrelDown)
            {
           
                foreach (GameObject f in barrels)
                {
                    f.transform.Rotate(rotspeedBarrel, 0, 0);
                }
                counter -= rotspeedBarrel;
     
            }
        }
       
           
        
       


    public void RotateStop()
    {
        left = false;
        right = false;
        barrelUp = false;
        barrelDown = false;
    }


}
