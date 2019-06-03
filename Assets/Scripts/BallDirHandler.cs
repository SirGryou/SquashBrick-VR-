using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDirHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HaveCollided");
    }
}
