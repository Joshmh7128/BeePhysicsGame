using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringScript : MonoBehaviour
{
    GameManager gameManager; // our game manager
    TimerScript timer; // our timer
    int score; // our score
    [SerializeField] Text scoreText; // our display score text
    public CanvasGroup scoreCanvasGroup; // our canvas group
    public bool canTrack;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        timer = GameObject.Find("Timer").GetComponent<TimerScript>();
        canTrack = true;
    }

    private void FixedUpdate()
    {
        if (canTrack)
        score = gameManager.itemClasses.Count * timer.remainingTime;
        scoreText.text = score.ToString();
    }
}
