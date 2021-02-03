using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public Transform playerCam;
    public Transform orientation;

    private Rigidbody rb;

    //rotation and looking
    private float xRotation;
    private float sensitivity = 100f;
    private float xDesired;

    
    public Transform groundCheckTransform;
   
    //jumping
    private float jumpStrength = 550f;
    


    private void Awake()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myInputs();
        look();   
    }

    void myInputs ()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            if (Physics.OverlapSphere(this.groundCheckTransform.position, 0,1).Length == 1)
            {
                jump();
            }
           // jump();
            
           
        }

    }

    
    void look ()
    {
        float mouseX = Input.GetAxis("Mouse X") * this.sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * this.sensitivity * Time.deltaTime;

        //find location player is looking at.
        Vector3 rot = this.playerCam.transform.rotation.eulerAngles;
        this.xDesired = rot.y + mouseX;

        this.xRotation -= mouseY;
        this.xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Perform the rotations
        playerCam.transform.localRotation = Quaternion.Euler(xRotation, this.xDesired, 0);
        orientation.transform.localRotation = Quaternion.Euler(0, this.xDesired, 0);
    }

    void jump ()
    {
        this.rb.AddForce(Vector3.up * this.jumpStrength * 1.5f);
    }


}
