using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [Header("Visuals")]
    [SerializeField] private Transform playerCam;

    [Header("Gameplay")]
    private int ammo;
    public int Ammo { get { return ammo; } }
    private int ammoCap;
    private int ammoStorage;
    public int AmmoStorage { get { return ammoStorage; } }
   

    // Start is called before the first frame update
    void Start()
    {
        
        ammoCap = 10;
        this.ammoStorage = 40;
        this.ammo = ammoCap;


    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0) {
                ammo--;

                GameObject bulletObject = ObjectPoolingManager.Instance.getBullet();
                bulletObject.transform.position = playerCam.position + playerCam.transform.forward;
                bulletObject.transform.forward = playerCam.transform.forward;

               
               
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            if (ammoStorage > ammoCap)
            {
                int ammoToAdd = ammoCap - this.ammo;
                this.ammo += ammoToAdd;
                ammoStorage -= ammoToAdd;

            } else
            {

                this.ammo += ammoStorage;
                ammoStorage = 0;

            }

        }
            


    }
}
