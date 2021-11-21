using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOrbClass : MonoBehaviour
{
    [SerializeField] GenManager genManager; // our gen manager

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            genManager.RegenMap();
        }
    }
}
