using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform playerCam;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {


            
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = playerCam.position;
            bulletObject.transform.forward = playerCam.forward;
            
        }
            


    }
}
