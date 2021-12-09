using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringScript : MonoBehaviour
{
    GameManager gameManager; // our game manager
    TimerScript timer; // our timer
    public int score, oneStarThreshold, twoStarThreshold, threeStarThreshold; // our score and star thresholds
    [SerializeField] GameObject oneStar, twoStar, threeStar; // all three of the stars
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
        {
            score = gameManager.itemClasses.Count * timer.remainingTime;
            scoreText.text = score.ToString();
        }

        // setup our stars
        if (score > oneStarThreshold)
        { oneStar.SetActive(true);  }
        else { oneStar.SetActive(false); }

        if (score > twoStarThreshold)
        { twoStar.SetActive(true); }
        else { twoStar.SetActive(false); }

        if (score > threeStarThreshold)
        { threeStar.SetActive(true);  }
        else { threeStar.SetActive(false); }
    }
}
