using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoMove : MonoBehaviour
{
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    public GameObject Target;


    void Update()
    {
        // Define a target position above and behind the target transform
       // Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, Target.transform.position, ref velocity, smoothTime);
    }

}

