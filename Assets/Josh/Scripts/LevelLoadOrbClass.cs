using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadOrbClass : MonoBehaviour
{
    [SerializeField] string targetScene; // which scene do we want to move to?

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(targetScene);
        }
    }

    private void FixedUpdate()
    {
        if (targetScene == "Default")
        {
            Debug.LogError("Level Load Orb Not Set. You need to Set the Target Scene in the Editor.");
        }
    }
}
