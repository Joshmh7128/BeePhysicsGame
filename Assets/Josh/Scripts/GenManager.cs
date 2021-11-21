using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GenManager : MonoBehaviour
{
    [SerializeField] List<RandomChildSelector> randomChildSelectors; // our list of child selectors
    [SerializeField] Transform targetOrbTransform; // the target orb transform that we want to more around the map
    [SerializeField] float xVariance, yVariance, zVariance; // the amount of randomization we want in our orb placement
    [SerializeField] bool multiGen; // do we want to generate multiple times in the same level?
    Gamepad ourGamepad;
    bool stickPressed = false;

    // generate the map at the start of the game
    private void Start()
    {
        // start the map off
        // for each random child selector on the map, regen the map
        foreach (RandomChildSelector randomChildSelector in randomChildSelectors)
        {
            randomChildSelector.Regen();
        }

        ourGamepad = Gamepad.current;
    }

    private void Update()
    {
        if (ourGamepad.rightStickButton.IsPressed() && !stickPressed)
        {
            stickPressed = true;
            multiGen = true;
            RegenMap();
            multiGen = false;
        }

        if (!ourGamepad.rightStickButton.isPressed)
        { stickPressed = false; }
    }

    public void RegenMap()
    {
        if (multiGen)
        {
            // for each random child selector on the map, regen the map
            foreach (RandomChildSelector randomChildSelector in randomChildSelectors)
            {
                randomChildSelector.Regen();
            }
        }

        // randomize the position of our target orb transform based on our randomization floats
        targetOrbTransform.position = transform.position + new Vector3(Random.Range(-xVariance, xVariance), Random.Range(-yVariance, yVariance), Random.Range(-zVariance, zVariance));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(xVariance*2, yVariance*2, zVariance*2));
    }
}
