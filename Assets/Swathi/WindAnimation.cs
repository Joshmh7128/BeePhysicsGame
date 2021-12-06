using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAnimation : MonoBehaviour
{
       public ParticleSystem ps;
    public float timer; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayParticles());
    }

    // Update is called once per frame
    void Update()
    {
        // ps = GetComponent<ParticleSystem>();
        // if (ps.time >= 10)
        // {
        //     ps.Stop();
        //     timer = 0; 
        //     timer += Time.deltaTime; 
        //     if (timer >= 10){
        //     ps.Play();

        //     }
        // }   
    }

    IEnumerator PlayParticles() {
        ps = GetComponent<ParticleSystem>();
        
        while (true) {
            
            yield return new WaitForSeconds(10.0f);
            // turn off particles
            ps.Stop();
            Debug.Log("StoppedParticles");
            yield return new WaitForSeconds(5.0f);
            // turn on ...
            ps.Play();
            Debug.Log("PlayingParticles");
        }
    }
}
