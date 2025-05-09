using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour  
{
    //chat gpt ignore comments
    //need to set up  a controller input
    //stamaina system
    // clean up the code
      
    public float horizontalInput,verticalInput,speed,jumpspeed,JumpDistance; 
    private bool OnGround;
    [SerializeField] Transform cam;
    [SerializeField] PlayerAttriibues playerattributes;
    private Rigidbody rb;
    
    private void GroundCheck()
    {
        var direction = new Vector3(0,-1,0);
        Ray ray = new Ray(transform.position,transform.TransformDirection(direction * JumpDistance ));
        Debug.DrawRay(transform.position,transform.TransformDirection(direction * JumpDistance ));

        if(Physics.Raycast(ray,out RaycastHit hit, JumpDistance ))
        {
            if(hit.collider.tag == "ground")
            {
                
                
                OnGround = true;

            }
            else if(hit.collider.tag != "ground")
            {
                
               
                OnGround = false;
            }
           


        }


    }
  
   void Movement()
   {    
        if(!playerattributes.PlayerDiedMethod())
        {
            horizontalInput = Input.GetAxis("Horizontal"); 
         verticalInput = Input.GetAxis("Vertical");  
        
         //cam dir
         Vector3 camFoward = cam.forward; // grabbing cameras z axis
            Vector3 camRight = cam.right; // grabbing cameras x axis 
       

         //setting the cameras y to 0
            camFoward.y = 0;
         camRight.y = 0;
         //creating relate cam direction 
         // multiplying the verticalInput the WASD * the cameras z axis to make forwardRelative
            // multiplu the horizontalInput * the cameras x axis to make right relative 
        
       
            Vector3 forwardRelative = verticalInput * camFoward;
            Vector3 rightRelative = horizontalInput * camRight;

            Vector3 moveDir = forwardRelative + rightRelative;
       
        
        
       
        
            
                 

            // checks which key is pressed and does different math based on the key

             if (Input.GetKey(KeyCode.W))
             {
           
             transform.Translate(forwardRelative * speed * verticalInput);
            }
            if(Input.GetKey(KeyCode.S))
             {
                 transform.Translate(forwardRelative * speed * -verticalInput);

             }
            if(Input.GetKey(KeyCode.D))
            {
                 transform.Translate(rightRelative * speed * horizontalInput);

            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(rightRelative * speed * -horizontalInput);
            }

        
        
            if(Input.GetKey(KeyCode.Space))  
            {
                GroundCheck();
        
                if(Input.GetKey(KeyCode.Space) && OnGround == true)
                {
                rb.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
                 OnGround = false;
                 }    
        
            }
        }
   }
    
    
    
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Movement();
        playerattributes = GetComponent<PlayerAttriibues>();
       
        

    }
}