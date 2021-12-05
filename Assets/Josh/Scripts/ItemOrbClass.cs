using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOrbClass : MonoBehaviour
{
    [SerializeField] GameObject dropItem; // what item are we dropping for the player?
    Transform itemDropTransform; // what is our player's transform?
    [SerializeField] Transform rotatingContainer; // the rotating container to signify what item spawns from this bubble
    bool hasContacted;

    private void Start()
    {
        if (dropItem == null)
        {
            Debug.LogError("Item Orb is Missing Drop Item. You need to assign one in the Inspector.");
        }
        else
        {
            // spawn our item underneath our animated container
            GameObject ourItem = Instantiate(dropItem, rotatingContainer);
            ourItem.GetComponent<Rigidbody>().useGravity = false;
            // find our dropping transform
            itemDropTransform = GameObject.Find("ItemDropPoint").GetComponent<Transform>();
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        // when the player touches the orb drop the dropitem into the players basket
        if (col.gameObject.tag == "Player" && !hasContacted)
        {
            hasContacted = true;
            GameObject ourItem = Instantiate(dropItem, itemDropTransform.position, Quaternion.identity, null);
            ourItem.GetComponent<ItemClass>().isReal = true;
            Destroy(gameObject);
        }
    }
}
