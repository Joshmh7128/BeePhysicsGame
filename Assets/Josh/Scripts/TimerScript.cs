using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    // our timer
    [SerializeField] int time, maxTime; // our time
    [SerializeField] Slider slider; // our slider
    [SerializeField] Text timeText; // time text

    // Start is called before the first frame update
    void Start()
    {
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

        if (time > 0)
        {
            timeText.text = time.ToString();
            slider.value = time;
            StartCoroutine(TimerRoutine());
        }
    }
}
