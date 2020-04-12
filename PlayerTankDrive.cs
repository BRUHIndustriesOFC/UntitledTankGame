using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTankDrive : MonoBehaviour
{

    public float rotSpeed = 10f;
   
    float forwardBackAdj;
    float leftRightAdj;
    public float speedUpSpeed;

    float throttle = 0f; //lol speed iz tis

    public float MaxSpeed;
    public float ReverseSpeed;
    public Text speedText;

    
    public Light[] lights;
    bool sett = false;


    Rigidbody rbTank;
    public static float forwardBack;
    public static float leftRight;
    bool forward = false;
    bool back = false;
    bool left = false;
    bool right = false;

    public string TankName;
    float speedTimer;

    private void Awake()
    {
        rbTank = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }
    public void Forward()
    {
        forward = true;
    }
    public void Back()
    {
        back = true;
    }
    public void Left()
    {
        left = true;

    }
    public void Right()
    {
        right = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (sett)
            {
                sett = false;
                foreach (Light l in lights)
                {
                    l.gameObject.SetActive(false);
                }
            }
            else if (!sett)
            {
                sett = true;
                foreach (Light l in lights)
                {
                    l.gameObject.SetActive(true);
                }

            }
        }

        // forwardBack = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //leftRight = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        forwardBack = Input.GetAxis("Vertical");
 
        leftRight = Input.GetAxis("Horizontal");
        speedText.text = "Speed: " + throttle + "f";

        if (forward == true)
        {
            forwardBack = -1f;

        }
        if(back == true)
        {
            forwardBack = 1f;
        }
        if(left == true)
        {
            leftRight = -1f;
        }
        if(right == true)
        {
            leftRight = 1f;
        }

      
        //
        if(forwardBack == 1)
        {
          

            if (throttle <= speedUpSpeed)
            {
                if (!SoundMng.instance.TankSpeedUp.isPlaying)
                {
                    if (throttle >= speedUpSpeed)
                    {
                        SoundMng.instance.TankSpeedUp.Stop();
                    }
                    if (throttle < speedUpSpeed)
                    {
                        SoundMng.instance.TankGo.Stop();
                    }
                    SoundMng.instance.StartTank();
                    
                }
            }
              
                if (throttle > speedUpSpeed)
                {
                if(!SoundMng.instance.TankGo.isPlaying)
                {
                    if(!SoundMng.instance.TankSpeedUp.isPlaying)
                    {
                        if (throttle >= speedUpSpeed)
                        {
                            SoundMng.instance.TankSpeedUp.Stop();
                        }
                        if (throttle < speedUpSpeed)
                        {
                            SoundMng.instance.TankGo.Stop();
                        }
                        SoundMng.instance.DriveTank();
                       

                    }
                    else
                    {
                        SoundMng.instance.TankSpeedUp.Stop();
                    }
                    
                }
                   
                }
            
            
            StartCoroutine(goForward());
         

        }
        if (forwardBack == -1)
        {
            SoundMng.instance.TankGo.Stop();
            SoundMng.instance.TankSpeedUp.Stop();
            StartCoroutine(goBack());
        }
        if (forwardBack == 0)
        {
            SoundMng.instance.TankGo.Stop();
            SoundMng.instance.TankSpeedUp.Stop();
            StartCoroutine(slowDown());
         
        }


        //forwardBackAdj = forwardBack * throttle * Time.deltaTime;

        //forwardBackAdj = throttle * Time.fixedDeltaTime;
        //leftRightAdj = leftRight * rotSpeed * Time.fixedDeltaTime;
        forwardBackAdj = throttle * Time.deltaTime;
        leftRightAdj = leftRight * rotSpeed * Time.deltaTime;

    }

    IEnumerator goForward()
    {
        
       if(throttle <= MaxSpeed)
        {
            yield return new WaitForSeconds(0.7f);
            throttle += 1;

        }
        else if(throttle >= MaxSpeed)
        {
            throttle = MaxSpeed - 1;
        }
 
    }
    IEnumerator slowDown()
    {
      
        yield return new WaitForSeconds(0.5f);
        if(throttle > 0)
        {
            throttle -= 1;
        }else if(throttle < 0)
        {
            throttle += 1;
    
        }
       
        
    }
    IEnumerator goBack()
    {
        Debug.Log("reverse + " + ReverseSpeed + "thr " + throttle);
        if(throttle >= ReverseSpeed)
        {
            yield return new WaitForSeconds(0.7f);
            throttle -= 1;
           
        }
        else
        {
            throttle = ReverseSpeed + 1;
        }
    }




    private void FixedUpdate()
    {
        //forwardBackAdj = throttle * Time.fixedDeltaTime;
        //leftRightAdj = leftRight * rotSpeed * Time.fixedDeltaTime;

        TankForwardBack();
        TankRotateLeftRight();

        //if(Input.GetKeyDown(KeyCode.L))
        //{
        //    if(sett)
        //    {
        //        sett = false;
        //        foreach (Light l in lights)
        //        {
        //            l.gameObject.SetActive(false);
        //        }
        //    }
        //    else if(!sett)
        //    {
        //        sett = true;
        //        foreach(Light l in lights)
        //        {
        //            l.gameObject.SetActive(true);
        //        }

        //    }
        //}

    }
    void TankForwardBack()
    {
     
            Vector3 moveFB = transform.forward * forwardBackAdj;
        rbTank.MovePosition(rbTank.position + moveFB);
      
 
    }

  

    void TankRotateLeftRight()
    {
        Quaternion rotateLR = Quaternion.Euler(0f, leftRightAdj, 0f);
        rbTank.MoveRotation(rbTank.rotation * rotateLR);
        
       
    }
    public void SwitchBoolsOff()
    {
        forward = false;
        back = false;
        left = false;
        right = false;
    }
}
