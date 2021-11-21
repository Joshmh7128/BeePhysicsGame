using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenManager : MonoBehaviour
{
    [SerializeField] List<RandomChildSelector> randomChildSelectors; // our list of child selectors
    [SerializeField] Transform targetOrbTransform; // the target orb transform that we want to more around the map
    [SerializeField] float xVariance, yVariance, zVariance; // the amount of randomization we want in our orb placement

    // generate the map at the start of the game
    private void Start()
    {
        RegenMap();
    }

    public void RegenMap()
    {
        // for each random child selector on the map, regen the map
        foreach(RandomChildSelector randomChildSelector in randomChildSelectors)
        {
            randomChildSelector.Regen();
        }

        // randomize the position of our target orb transform based on our randomization floats
        targetOrbTransform.position = new Vector3(Random.Range(-xVariance, xVariance), Random.Range(-yVariance, yVariance), Random.Range(-zVariance, zVariance));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(xVariance*2, yVariance*2, zVariance*2));
    }
}
