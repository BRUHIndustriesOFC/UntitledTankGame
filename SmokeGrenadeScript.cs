using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeGrenadeScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject particles;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log(transform.position);

        SoundMng.instance.smokeExplosion();
    }
}
