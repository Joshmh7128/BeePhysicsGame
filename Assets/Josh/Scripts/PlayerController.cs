using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Main Control Values")]
    // player variable
    [SerializeField] CharacterController characterController; // our main character controller that we will be moving
    Vector3 move;  // our player movement vector
    [SerializeField] float speed;   // speed of our player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get our X and Z movement based off of our left stick
        float moveH = Input.GetAxis("Horizontal"); 
        float moveV = Input.GetAxis("Vertical"); 

        // total move 
        move = new Vector3();

        // apply to the character controller
        characterController.Move(move * Time.deltaTime * speed);
    }
}
