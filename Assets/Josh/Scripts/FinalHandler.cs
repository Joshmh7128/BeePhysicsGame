using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalHandler : MonoBehaviour
{
    [SerializeField] TimerScript timer;
    [SerializeField] ScoringScript scoringScript;
    [SerializeField] PlayerController playerController;

    private void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<TimerScript>();
        scoringScript = GameObject.Find("ScoringUI").GetComponent<ScoringScript>();
        playerController = GameObject.Find("Bee").GetComponent<PlayerController>();
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
    }
}
