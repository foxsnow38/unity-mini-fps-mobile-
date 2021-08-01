using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public float speed;
    private Rigidbody rig;
    public float sprintModifierX;
    public Camera normalCam;
    public float baseFov;
   private float sprintModifierFov = 1.5f;
    public float jumpspeed;
    //public Transform Groundsearch;
    //public LayerMask ground;


    void Start()
    {
        baseFov = normalCam.fieldOfView;

        Camera.main.enabled = false;

        rig = GetComponent<Rigidbody>();
        

    }


    void FixedUpdate()
    {
        float t_hmove = Input.GetAxisRaw("Horizontal");
        float t_vmove = Input.GetAxisRaw("Vertical");
        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isSpringting = sprint && t_vmove > 0 ;
        
float t_adjustedspeed = speed;

        

       // bool isGrounded = Physics.Raycast(Groundsearch.position,Vector3.down,1,ground);
        bool jump = Input.GetKeyDown(KeyCode.Space);
        bool isjumping = jump /*&& isGrounded*/;
        if (isjumping) { rig.AddForce(Vector3.up*jumpspeed , ForceMode.Impulse);
           
        }

        if (isSpringting) { t_adjustedspeed *= sprintModifierX;
            normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFov * sprintModifierFov, Time.deltaTime* 8f); }
        
        else {
            
            normalCam.fieldOfView = baseFov;
        }

        Vector3 t_direct = new Vector3 ( t_hmove,0, t_vmove);
        t_direct.Normalize();

        Vector3 targetvelocity = transform.TransformDirection(t_direct) * t_adjustedspeed * Time.deltaTime;

        targetvelocity.y = rig.velocity.y;
        rig.velocity = targetvelocity;
    
    }
}
    

