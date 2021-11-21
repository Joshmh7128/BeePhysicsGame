using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLookAt : MonoBehaviour
{
    // script is a helper script used to help look at things
    [SerializeField] Transform target;

    // updates at the update speed
    private void Update()
    {
        // look at it every frame
        transform.LookAt(target);
    }
}
