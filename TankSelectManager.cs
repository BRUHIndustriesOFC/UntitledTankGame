using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankSelectManager : MonoBehaviour
{
    // Start is called before the first frame update public Camera[] toActiveOrNot;
  

    public Text[] mainGunText;
    public Text[] MGText;
    public Text[] axialText;
    public Text speedText;

    public Camera selectioncam;//T

    public GameObject T65A;//t
    public GameObject T40;//T
    public GameObject T34A;
    public GameObject T31;
    public GameObject T17IFV;
    public GameObject T302L;
    public Button btnT65;
    public Button btnT40;
    public Button btnT34A;
    public Button btnT31;
    public Button btnT17IFV;
    public Button btnT302L;
    public RawImage[] tankPhotos;

    public RawImage[] details;
    public Text detailsTextBRUH;
    public Text detailsTextFurry;
    public GameObject[] logos;
    //3 camera Tank başına

    public GameObject FurryEnemy;
    public GameObject BruhEnemy;

    public string selectedTank;
    void Start()
    {
        // TANKLARLA İLGİLİ HER ŞEY KAPATILIYOR.
        foreach(Text t in axialText)
        {
            t.enabled = false;
        }
        foreach (GameObject logo in logos)
        {
            logo.SetActive(true);
        }
        speedText.enabled = false;
        T65A.SetActive(false);
        T40.SetActive(false);
        T34A.SetActive(false);
        T31.SetActive(false);
        T17IFV.SetActive(false);
        T302L.SetActive(false);
        foreach(Text t in mainGunText)
        {
            t.gameObject.SetActive(false);

        }
        foreach (Text t in MGText)
        {
            t.gameObject.SetActive(false);

        }

        selectioncam.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        foreach (RawImage t in details)
        {
            t.gameObject.SetActive(false);

        }

        BruhEnemy.SetActive(false);
       FurryEnemy.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //selectioncam.transform.Rotate(0, 0.3f, 0);
        //selectioncam.transform.Translate(0, 0, 1);
    }

    public void SELECTT65A()
    {
        foreach (GameObject logo in logos)
        {
            logo.SetActive(false);
        }
        selectedTank = "T65A";
        T65A.SetActive(true);
        T40.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        selectioncam.enabled = false;
        speedText.enabled = true;
        btnT17IFV.gameObject.SetActive(false);
        btnT31.gameObject.SetActive(false);
        btnT34A.gameObject.SetActive(false);
        btnT65.gameObject.SetActive(false);
        btnT40.gameObject.SetActive(false);
        btnT302L.gameObject.SetActive(false);
        foreach (Text t in mainGunText)
        {
            t.gameObject.SetActive(true);

        }
        foreach (Text t in MGText)
        {
            t.gameObject.SetActive(false);

        }

        foreach(RawImage img in tankPhotos)
        {
            Destroy(img.gameObject);
        }
        foreach (RawImage t in details)
        {
            t.gameObject.SetActive(true);

        }
        spawnFurryEnemy();
    }

    public void SELECTT40()
    {
        foreach (GameObject logo in logos)
        {
            logo.SetActive(false);
        }
        selectedTank = "T40";
        T40.SetActive(true);
        T65A.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        selectioncam.enabled = false;
        speedText.enabled = true;

        btnT17IFV.gameObject.SetActive(false);
        btnT31.gameObject.SetActive(false);
        btnT34A.gameObject.SetActive(false);
        btnT65.gameObject.SetActive(false);
        btnT40.gameObject.SetActive(false);
        btnT302L.gameObject.SetActive(false);
        foreach (Text t in mainGunText)
        {
            t.gameObject.SetActive(true);

        }
        foreach (Text t in MGText)
        {
            t.gameObject.SetActive(true);

        }
        foreach (RawImage img in tankPhotos)
        {
            Destroy(img.gameObject);
        }
        foreach (RawImage t in details)
        {
            t.gameObject.SetActive(true);

        }
        spawnFurryEnemy();
    }

    public void SelectT34A()
    {
        foreach (GameObject logo in logos)
        {
            logo.SetActive(false);
        }
        selectedTank = "T34A";
        T40.SetActive(false);
        T65A.SetActive(false);
        T34A.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        selectioncam.enabled = false;
        speedText.enabled = true;
        foreach (Text t in axialText)
        {
            t.enabled = true;
        }
        btnT17IFV.gameObject.SetActive(false);
        btnT31.gameObject.SetActive(false);
        btnT34A.gameObject.SetActive(false);
        btnT65.gameObject.SetActive(false);
        btnT40.gameObject.SetActive(false);
        btnT302L.gameObject.SetActive(false);
        foreach (Text t in mainGunText)
        {
            t.gameObject.SetActive(true);

        }
        foreach (Text t in MGText)
        {
            t.gameObject.SetActive(true);

        }
        foreach (RawImage img in tankPhotos)
        {
            Destroy(img.gameObject);
        }
        foreach (RawImage t in details)
        {
            t.gameObject.SetActive(true);

        }
        spawnFurryEnemy();
    }

    public void SelectT31()
    {
        foreach (GameObject logo in logos)
        {
            logo.SetActive(false);
        }
        selectedTank = "T31";
        T40.SetActive(false);
        T65A.SetActive(false);
        T34A.SetActive(false);
        T31.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        selectioncam.enabled = false;
        speedText.enabled = true;
        foreach (Text t in axialText)
        {
            t.enabled = true;
        }
        Destroy(btnT17IFV.gameObject);
        btnT17IFV.gameObject.SetActive(false);
        btnT31.gameObject.SetActive(false);
        btnT34A.gameObject.SetActive(false);
        btnT65.gameObject.SetActive(false);
        btnT40.gameObject.SetActive(false);
        btnT302L.gameObject.SetActive(false);
        foreach (Text t in mainGunText)
        {
            t.gameObject.SetActive(true);

        }
        foreach (Text t in MGText)
        {
            t.gameObject.SetActive(true);

        }
        foreach (RawImage img in tankPhotos)
        {
            Destroy(img.gameObject);
        }
        foreach (RawImage t in details)
        {
            t.gameObject.SetActive(true);

        }
        spawnFurryEnemy();
    }

    public void SelectT17IFV()
    {
        foreach (GameObject logo in logos)
        {
            logo.SetActive(false);
        }
        selectedTank = "T17IFV";
        T40.SetActive(false);
        T65A.SetActive(false);
        T34A.SetActive(false);
        T31.SetActive(false);
        T17IFV.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        selectioncam.enabled = false;
        speedText.enabled = true;
        foreach (Text t in axialText)
        {
            t.enabled = true;
        }
        foreach (Text t in axialText)
        {
            t.enabled = true;
        }
        btnT17IFV.gameObject.SetActive(false);
        btnT31.gameObject.SetActive(false);
        btnT34A.gameObject.SetActive(false);
        btnT65.gameObject.SetActive(false);
        btnT40.gameObject.SetActive(false);
        btnT302L.gameObject.SetActive(false);
        foreach (Text t in mainGunText)
        {
            t.gameObject.SetActive(true);

        }
        foreach (Text t in MGText)
        {
            t.gameObject.SetActive(true);

        }
        foreach (RawImage img in tankPhotos)
        {
            Destroy(img.gameObject);
        }
        foreach (RawImage t in details)
        {
            t.gameObject.SetActive(true);

        }
        spawnFurryEnemy();
    }

    public void SelectT302L()
    {
        foreach (GameObject logo in logos)
        {
            logo.SetActive(false);
        }
        selectedTank = "T302L";
        T40.SetActive(false);
        T65A.SetActive(false);
        T34A.SetActive(false);
        T31.SetActive(false);
        T17IFV.SetActive(false);
        T302L.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        selectioncam.enabled = false;
        speedText.enabled = true;
        foreach (Text t in axialText)
        {
            t.enabled = true;
        }
        foreach (Text t in axialText)
        {
            t.enabled = true;
        }
        btnT17IFV.gameObject.SetActive(false);
        btnT31.gameObject.SetActive(false);
        btnT34A.gameObject.SetActive(false);
        btnT65.gameObject.SetActive(false);
        btnT40.gameObject.SetActive(false);
        btnT302L.gameObject.SetActive(false);
        foreach (Text t in mainGunText)
        {
            t.gameObject.SetActive(true);

        }
        foreach (Text t in MGText)
        {
            t.gameObject.SetActive(true);

        }
        foreach (RawImage img in tankPhotos)
        {
            Destroy(img.gameObject);
        }
        foreach (RawImage t in details)
        {
            t.gameObject.SetActive(true);

        }
        spawnBRUHEnemy();
    }


    void spawnFurryEnemy()
    {
        FurryEnemy.SetActive(true);
    }

    void spawnBRUHEnemy()
    {
        BruhEnemy.SetActive(true);
    }
    public void InfoT65SPAAG()
    {
        detailsTextBRUH.text = "BRUH Industries T-65 Self Propelled Anti Aircraft Gun  \n Armaments: 4x40mm AB-40ACAA Autocannons (Total 320 Ammunition) \n Maximum Speed: 30 Units \n Fire Rate: High"; 
    }

    public void InfoT40SPAG()
    {
        detailsTextBRUH.text = "BRUH Industries T-40 Self Propelled Artillery Gun  \n Armaments: 1x170mm AB-172LRT Howitzer (Total 30 Ammunition) + Fixed 7.9mm BC Machinegun(Total Ammo: 2800) \n Maximum Speed: 15 Units \n Fire Rate: Slow";

    }

    public void InfoT34AMBT()
    {
        detailsTextBRUH.text = "BRUH Industries T-34A 2nd Generation Main Battle Tank  \n Armaments: 1x120mm AB-120SBT (Total 50 Ammunition) + 1x Co-Axial 7.9mm BC Machinegun(Total Ammo:1600) + 1xAxial 7.9mm BC Machinegun(Total Ammo: 600) \n Maximum Speed: 22 Units \n Fire Rate: Slow";

    }

    public void InfoT31MBT()
    {
        detailsTextBRUH.text = "BRUH Industries T-31 3rd Generation Main Battle Tank  \n Armaments: 1x135mm AB-135SBTPP (Total 30 Ammunition) + 1xCo-Axial 7.9mm BC Machinegun (Total Ammo:1200) + 1x20mm AB/20SS Autocannon (400 ammunition) \n Maximum Speed: 30 Units \n Fire Rate: Slow";

    }

    public void InfoNothing()
    {
        detailsTextBRUH.text = "";

    }

    public void InfoT17IFV()
    {
        detailsTextBRUH.text = "BRUH Industries T-17 Infantry Fighting Vehicle  \n Armaments: 1x50mm AB-50LLAC (Total Ammo: 300) + 1xAxial 8mm DC_R Machinegun (Total Ammo:700)  \n Maximum Speed: 35 Units \n Fire Rate: Medium";

    }

    public void InfoT302L()
    {
        detailsTextFurry.text = "Furry Terrorists T-302K Battle Tank \n Armaments: 1x105mm Fr-105DC (Total Ammo: 55) (Rifled Cannon) + 1xAxial 7.6mm Lg-26 Machinegun ( Total Ammo: 700 ) \n Maximum Speed: 30 \n Fire Rate:A bit more than medium";
    }

    public void InfoNothingFurry()
    {
        detailsTextFurry.text = "";
    }


}
