using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneClass : MonoBehaviour
{
    [SerializeField] Vector3 windDirection;
    [SerializeField] Transform particleTransform;

    private void Start()
    {
        particleTransform.transform.localRotation = Quaternion.LookRotation(windDirection, Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.name == "Bee")
        {
            other.gameObject.GetComponent<PlayerController>().windMove = windDirection;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.name == "Bee")
        {
            other.gameObject.GetComponent<PlayerController>().windMove = Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
