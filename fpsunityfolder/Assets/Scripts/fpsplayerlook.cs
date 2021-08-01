using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Settings_Ui { 
public class fpsplayerlook : MonoBehaviour
{
    public static bool cursorLocked = true;

    public Transform player;
    public Transform cams;
    public Transform weapon;
    private float xSensitivity  ;
    private float ySensitivity;
    public float MaxAngle;
    private Quaternion camCenter;
          public static float sens;
        public float sensivity;
        void Start()
    { 
            sensivity = sens;
        camCenter = cams.localRotation;

    }

    // Update is called once per frame
    void Update()
    {
        SetX();
        SetY();
            UpdateCursorLock();
            Senss();
    }
    void SetY()
    {
        float t_input = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
        Quaternion t_adj = Quaternion.AngleAxis(t_input, -Vector3.right);
        Quaternion t_delta = cams.localRotation * t_adj;

        if (Quaternion.Angle(camCenter, t_delta) < MaxAngle)
        { cams.localRotation = t_delta;
            weapon.localRotation = t_delta;
        } weapon.localRotation = cams.localRotation;


    }
    void SetX()
    {
        float t_input = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        Quaternion t_adj = Quaternion.AngleAxis(t_input, Vector3.up);
        Quaternion t_delta = player.rotation * t_adj;
        player.rotation = t_delta;
    }
    private void UpdateCursorLock()
    {

            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            { cursorLocked = false; }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                if (Input.GetKeyDown(KeyCode.Escape))
                { cursorLocked = true; }
            }
        }

        public void Senss()
        {
           
        xSensitivity = sensivity;
        ySensitivity = sensivity;
    }

    //public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    //public RotationAxes axes = RotationAxes.MouseXAndY;
    //public float sensitivityX = 15F;
    //public float sensitivityY = 15F;

    //public float minimumX = -360F;
    //public float maximumX = 360F;

    //public float minimumY = -60F;
    //public float maximumY = 60F;

    //float rotationY = 0F;

    //void Update()
    //{
    //    if (axes == RotationAxes.MouseXAndY)
    //    {
    //        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

    //        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
    //        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

    //        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    //    }
    //    else if (axes == RotationAxes.MouseX)
    //    {
    //        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
    //    }
    //    else
    //    {
    //        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
    //        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

    //        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
    //    }
    //}

    //void Start()
    //{
    //    // Make the rigid body not change rotation
    //    //if (rigidbody)
    //    //    rigidbody.freezeRotation = true;
    //}

} }




