using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    // our timer
    public int time, maxTime, remainingTime; // our time
    [SerializeField] Slider slider; // our slider
    [SerializeField] Text timeText; // time text
    public bool canCount;

    // Start is called before the first frame update
    void Start()
    {
        canCount = true;
        slider.maxValue = maxTime;
        time = maxTime;
        timeText.text = time.ToString();
        slider.value = time;
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        yield return new WaitForSeconds(1f);

        time--;

        // can we count down?
        if (time > 0 && canCount)
        {
            remainingTime = maxTime - time;
            timeText.text = time.ToString();
            slider.value = time;
            StartCoroutine(TimerRoutine());
        }

        // game over man!
        if (time <= 0)
        {   // reload
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
