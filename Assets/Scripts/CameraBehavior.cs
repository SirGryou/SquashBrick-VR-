using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Transform lookAt;
    private Transform camTransform;
    private GameObject raquette;
   
    [Range(-60,0)]
    public int Y_ANGLE_MIN = -60;
    [Range(-60,0)]
    public int X_ANGLE_MIN = -60;
    [Range(0,60)]
    public int Y_ANGLE_MAX = 60;
    [Range(0,60)]
    public int X_ANGLE_MAX = 60;
    public LayerMask panel;
    private const float DIST_MIN = 4.0f;
    private const float DIST_MAX = 10.0f;
   
    private Camera cam;

    [Range(0,25)]
    public int distance = 5;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camTransform = transform;
        cam = Camera.main;
        lookAt = GameObject.Find("Head").transform;
        raquette = GameObject.Find("Raquette");
    }

    private void Update()
    {
        //Faire un raycast
        //prendre la normal du panel
        //mettre la raquette
        //et voila
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 50f, panel))
        {
            var wantedPos = hit.point;
            wantedPos = Vector3.ClampMagnitude(wantedPos, 6f);
            raquette.transform.position = wantedPos + -hit.normal * 0.01f;
            Debug.Log("lol");
            Debug.DrawLine(transform.position, hit.point, Color.black);
        }
        //distance += -Input.GetAxis("Mouse ScrollWheel");
        currentY += -Input.GetAxis("Mouse Y");
        currentX += Input.GetAxis("Mouse X");
        //distance = Mathf.Clamp(distance, DIST_MIN, DIST_MAX);
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        currentX = Mathf.Clamp(currentX, X_ANGLE_MIN, X_ANGLE_MAX);
        
        Vector3 speed = cam.velocity; 
    }

    private void LateUpdate()
    {
        
        Quaternion toRotate = Quaternion.Euler(currentY, currentX, 0);

        Vector3 dir = new Vector3(0, 0, -distance);
       
        camTransform.position = lookAt.transform.position + toRotate * dir;

        camTransform.LookAt(lookAt.position);

        
    }
}