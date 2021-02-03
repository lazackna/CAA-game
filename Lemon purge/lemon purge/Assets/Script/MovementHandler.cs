using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private Transform orientation;

    private Rigidbody rb;

   

    //rotation and looking
    private float xRotation;
    private float sensitivity = 100f;
    private float xDesired;

    //movement
    private float x;
    private float y;
    private float speed = 50f;
    private float maxSpeedMag = 100f;
    [SerializeField] private PhysicMaterial friction;
    private bool isMoving;


    [SerializeField] private Transform groundCheckTransform;
   
    //jumping
    private float jumpStrength = 550f;
    [SerializeField] private LayerMask whatIsGround;
    



    bool jumping;

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    private void Start()
    {
      
    }

    // FixedUpdate is called every physics frame
    private void FixedUpdate()
    {
        
        movement();
    }

    // Update is called once per frame
    private void Update()
    {
        myInputs();
        look();   
    }

    private void myInputs ()
    {

        
        this.x = Input.GetAxis("Horizontal");
        this.y = Input.GetAxis("Vertical");

        isMovingCheck();

        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            if (Physics.OverlapSphere(this.groundCheckTransform.position, 0.3f, this.whatIsGround).Length == 1)
            {
                jump();
            }
           
        }

    }

    
    private void look ()
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

    private void movement ()
    {
        if (this.isMoving)
        {
            this.friction.dynamicFriction = 0.0f;
        } else
        {
            this.friction.dynamicFriction = 1.8f;
        }

        this.rb.AddForce(this.orientation.forward * speed * y);
        this.rb.AddForce(this.orientation.right * speed * x);
        
    }

    private void jump ()
    {
        this.rb.AddForce(Vector3.up * this.jumpStrength);
        if (rb.velocity.magnitude < 0.5)
        {
            this.rb.velocity = new Vector3(this.rb.velocity.x, 0, this.rb.velocity.z);
        }
    }

    private void isMovingCheck ()
    {
        
        if (this.x != 0 && this.y != 0)
        {
            this.isMoving = true;
        } else
        {
            this.isMoving = false;
        }
       
    }


}
