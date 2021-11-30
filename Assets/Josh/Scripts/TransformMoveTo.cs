using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMoveTo : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed; // this is the speed of our object

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
