using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass : MonoBehaviour
{
    public bool isReal, hasAdded; // is this item real or just an orb display item? has this item added itself to the gamemanager?

    private void FixedUpdate()
    {
        // find our gamemanager and add this to the list
        if (isReal && !hasAdded)
        {
            hasAdded = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().itemClasses.Add(this); 
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().itemClasses.Remove(this);
            Destroy(gameObject);
        }
    }
}
