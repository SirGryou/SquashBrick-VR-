using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWay : MonoBehaviour
{
    private GameObject trail;
    private GameObject predict;
    public LayerMask ground;
    public LayerMask panel;
    private Vector3 prevLoc;
    private Vector3 wantedPos;
    private float dist;
    private GameObject panelR;
    // Start is called before the first frame update
    void Start()
    {
        prevLoc = transform.position;
        trail = GameObject.Find("Trail");
        predict = GameObject.Find("Predict");
        panelR = GameObject.Find("Panel");
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.Find("Panel").GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        trajectoryTrail();

        dist = Vector3.Distance(transform.position, panelR.transform.position);
        if(dist < 10f)
        {
            predictTraject();
        }
    }

    void trajectoryTrail()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, ground))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.white);
            trail.transform.position = hit.point + hit.normal * 0.01f;
        }
    }
    void predictTraject()
    {
        var balleDir = transform.position - prevLoc;
        prevLoc = transform.position;
        Ray rayPanel = new Ray(transform.position, -transform.forward);
        RaycastHit hitPanel;
        if (Physics.Raycast(rayPanel, out hitPanel, 10f, panel))
        {
            Debug.DrawLine(rayPanel.origin, hitPanel.point, Color.green);
            predict.transform.position = hitPanel.point + -hitPanel.normal * 0.01f;
            predict.transform.localScale = new Vector3((transform.localScale.x * (1-(dist / 10))), 0.001f, (transform.localScale.z * (1 - (dist / 10))));
            
        }
        //else if (Physics.Raycast(rayPanel, out hitPanel, 10f))
        //{
            Debug.DrawLine(rayPanel.origin, balleDir * 10f, Color.red);
            //reflectRayCast(hitPanel.normal, balleDir, hitPanel.point, panel);
        //}
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.gameObject.name == "")
    //}

    //void reflectRayCast(Vector3 normal, Vector3 dir, Vector3 point, LayerMask panel)
    //{
    //    Vector3 newDir = Vector3.Reflect(dir, normal);
    //    Ray ray = new Ray(point, newDir);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit, 3f, panel))
    //    {
    //        Debug.DrawLine(ray.origin, hit.point, Color.cyan);
    //        predict.transform.position = hit.point + hit.normal * 0.1f;

    //    }
    //    if (Physics.Raycast(ray, out hit, 10f))
    //    {
    //        Debug.DrawLine(ray.origin, hit.point, Color.yellow);
    //        if (dist < 5f && hit.collider.name == "Panel")
    //        {

    //        }
    //    }
    //}
}
