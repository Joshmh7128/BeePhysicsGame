using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Main Control Values")]
    // player variable
    [SerializeField] CharacterController characterController;   // our main character controller that we will be moving
    Vector3 move;                                               // our player movement vector
    [SerializeField] float speed, lowSpeed, highSpeed;                               // speed of our player
    [SerializeField] float rotationSpeed;                            // rotation speed
    float currentRot;                                           // our current rotation on the Y axis
    Gamepad ourGamepad;                                         // our current gamepad
    [SerializeField] LineRenderer renderer1, renderer2, renderer3, renderer4; // our line renderers
    [SerializeField] Transform lineOrigin, lineTarget1, lineTarget2, lineTarget3, lineTarget4; // our line renderer target
    [SerializeField] Transform movementArrow; // cosmetic arrow representing our movement
    bool startPressed = false;
    [SerializeField] float flightEnergy, maxEnergy; // how much energy we have left to fly?

    void Start()
    {
        // make sure we set our current gamepad
        ourGamepad = Gamepad.current;
        // get our current rotation
        currentRot = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        // get our X and Z movement based off of our left stick
        float moveHx = ourGamepad.leftStick.x.ReadValue();
        float moveHy = ourGamepad.leftStick.y.ReadValue();
        // get our triggers and use them for vertical movement
        float moveYr = ourGamepad.rightTrigger.ReadValue(); 
        float moveYl = ourGamepad.leftTrigger.ReadValue();

        // expend energy to go up
        if (ourGamepad.leftTrigger.ReadValue() < 0.5f && ourGamepad.rightTrigger.ReadValue() > 0.5f)
        {
            if (flightEnergy > 0) { flightEnergy--; }
        }

        if (ourGamepad.leftTrigger.ReadValue() > 0.5f && ourGamepad.rightTrigger.ReadValue() > 0.5f)
        {
            speed = highSpeed;
        }

        if (ourGamepad.leftTrigger.ReadValue() < 0.5f && ourGamepad.rightTrigger.ReadValue() < 0.5f)
        {
            speed = lowSpeed;
        }

        // turn those values in to a movement vector
        move = transform.right * moveHx + transform.forward * moveHy + new Vector3(0, moveYr + -moveYl, 0);
        // apply to the character controller
        characterController.Move(move * Time.deltaTime * speed);
        // lets rotate the bee using the right stick
        float rotX = ourGamepad.rightStick.x.ReadValue();
        currentRot += rotX; // apply as an addition to turn our bee
        // add our rotation to the transform rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, currentRot * rotationSpeed, 0));
        // update the positions of our line renderers
        renderer1.SetPosition(0, lineOrigin.position); renderer2.SetPosition(0, lineOrigin.position); renderer3.SetPosition(0, lineOrigin.position); renderer4.SetPosition(0, lineOrigin.position);
        renderer1.SetPosition(1, lineTarget1.position); renderer2.SetPosition(1, lineTarget2.position); renderer3.SetPosition(1, lineTarget3.position); renderer4.SetPosition(1, lineTarget4.position);
        // update our movement arrow
        movementArrow.transform.LookAt(movementArrow.transform.position + move);
        // click to restart game
        if (ourGamepad.startButton.IsPressed() && !startPressed)
        {
            startPressed = true;
            SceneManager.LoadScene("PlaytestCompile");
        }        
        
        if (!ourGamepad.startButton.IsPressed())
        {
            startPressed = false;
        }
    }

    RaycastHit hit;
    private void FixedUpdate()
    {
        // if we hit the ground,
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, Physics.AllLayers))
        {
            if (!(hit.transform.tag == "Player"))
            // reset our energy
            flightEnergy = maxEnergy;   
        }
    }
}
