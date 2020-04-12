using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particles;
    public GameObject destroyParticles;
 
    public float PenetrationValue;
    
    float unitsTravelled;
    void Start()
    {
        
     
        Destroy(gameObject, 9f);

    }

    private void FixedUpdate()
    {
       
    }
   
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
       
            
           if(collision.transform.GetComponent<TankHealth>())
        {

           
            TankHealth h = collision.transform.GetComponent<TankHealth>();

            if(h.PenetrationVal > PenetrationValue)
            {
                if(h.PenetrationVal <= 50 && PenetrationValue >= 30)
                {
                    if (Mathf.Abs(h.PenetrationVal - PenetrationValue) <= 10)
                    {
                        h.PenetrationVal -= 7;
                    }
                    else if (Mathf.Abs(h.PenetrationVal - PenetrationValue) <= 15 && Mathf.Abs(h.PenetrationVal - PenetrationValue) > 10)
                    {
                        h.PenetrationVal -= 3;
                    }
                    else
                    {
                        //delemez artık yani
                    }
                }else if(h.PenetrationVal > 50 && h.PenetrationVal <=70 && PenetrationValue >= 55)
                {
                    if(Mathf.Abs(h.PenetrationVal - PenetrationValue) <= 10)
                    {
                        h.PenetrationVal -= 8;
                    }else if(Mathf.Abs(h.PenetrationVal - PenetrationValue) <= 15 && Mathf.Abs(h.PenetrationVal - PenetrationValue) > 10)
                    {
                        h.PenetrationVal -= 4;
                    }
                }
               
                else if(h.PenetrationVal == PenetrationValue)
                {
                    h.PenetrationVal -= PenetrationValue;
                }
                else
                {
                    h.PenetrationVal -= 7.5f;
                }
               
            }else if(h.PenetrationVal < PenetrationValue)
            {
               
                h.Health -= Mathf.Abs(h.PenetrationVal - PenetrationValue)/4;
            }



            //if(collision.transform.GetComponent<TankHealth>().PenetrationVal < PenetrationValue)
            // {
            //sh00t
            //collision.transform.GetComponent<TankHealth>().Health -= Mathf.Abs(collision.transform.GetComponent<TankHealth>().PenetrationVal - PenetrationValue);
            // }
            // else
            // {
            //     //d0nt sh00t lma0
            // }
            if(h.Health <= 0)
            {
                Instantiate(destroyParticles, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(particles, transform.position, Quaternion.identity);
            }
         
        }
        else
        {
            SoundMng.instance.ShellExplosion();
            Instantiate(particles, transform.position, Quaternion.identity);
        }
       
        Destroy(gameObject);
    }
}
