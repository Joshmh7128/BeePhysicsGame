using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Main Control Values")]
    // player variable
    [SerializeField] CharacterController characterController;   // our main character controller that we will be moving
    Vector3 move;                                               // our player movement vector
    [SerializeField] float speed;                               // speed of our player
    Gamepad ourGamepad;                                         // our current gamepad

    void Start()
    {
        // make sure we set our current gamepad
        ourGamepad = Gamepad.current;
    }

    // Update is called once per frame
    void Update()
    {
        // get our X and Z movement based off of our left stick
        float moveHx = ourGamepad.leftStick.x.ReadValue();
        float moveHy = ourGamepad.leftStick.y.ReadValue();

        // total move 
        move = new Vector3(moveHx, 0, moveHy);

        // apply to the character controller
        characterController.Move(move * Time.deltaTime * speed);
    }
}
