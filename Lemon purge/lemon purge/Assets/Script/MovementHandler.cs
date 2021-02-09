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
    private float speed = 20f;

    //crouching
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale;

    [SerializeField] private Transform groundCheckTransform;
   
    //jumping
    private float jumpStrength = 550f;
    [SerializeField] private LayerMask whatIsGround;
    

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.playerScale = transform.localScale;
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
        //look();   
    }

    private void myInputs ()
    {


        this.x = Input.GetAxisRaw("Horizontal") * this.speed;
        this.y = Input.GetAxisRaw("Vertical") * this.speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.OverlapSphere(this.groundCheckTransform.position, 0.3f, this.whatIsGround).Length == 1)
            {
                jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            unCrounch();
        }

    }

    /**
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
    */
    private void movement ()
    {

        Vector3 move = transform.right * x + transform.forward * y;
        rb.velocity = new Vector3(move.x, this.rb.velocity.y, move.z);
        
    }

    private void jump ()
    {
        this.rb.AddForce(Vector3.up * this.jumpStrength);
        if (rb.velocity.magnitude < 0.5)
        {
            this.rb.velocity = new Vector3(this.rb.velocity.x, 0, this.rb.velocity.z);
        }
    }

    private void crouch ()
    {
        transform.localScale = this.crouchScale;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
    }

    private void unCrounch ()
    {
        transform.localScale = this.playerScale;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }


}
