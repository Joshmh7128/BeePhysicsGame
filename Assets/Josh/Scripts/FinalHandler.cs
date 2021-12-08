using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FinalHandler : MonoBehaviour
{
    [SerializeField] TimerScript timer;
    [SerializeField] ScoringScript scoringScript;
    [SerializeField] PlayerController playerController;
    Gamepad ourGamepad; // our gamepad
    [SerializeField] string targetScene; // the next scene we are loading from this
    bool canLoad; // can we load?

    private void Start()
    {
        ourGamepad = Gamepad.current;
        timer = GameObject.Find("Timer").GetComponent<TimerScript>();
        scoringScript = GameObject.Find("ScoringUI").GetComponent<ScoringScript>();
        playerController = GameObject.Find("Bee").GetComponent<PlayerController>();
        canLoad = false;
    }

    private void FixedUpdate()
    {
        // load a new scene
        if (ourGamepad.aButton.isPressed && canLoad)
        {
            SceneManager.LoadScene(targetScene);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        // if we finish the level we can no longer count
        timer.canCount = false;
        // show our score
        scoringScript.scoreCanvasGroup.alpha = 1;
        playerController.canMove = false;
        scoringScript.canTrack = false;
        canLoad = true;
    }
}
