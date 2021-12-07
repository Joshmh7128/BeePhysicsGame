using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAnimation : MonoBehaviour
{
    public ParticleSystem ps;
    public PlayerController bee;
    public float timer;
    public float WindPower;

    public bool SafeOrNo;

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

    IEnumerator PlayParticles()
    {
        ps = GetComponent<ParticleSystem>();

        while (true)
        {
            // turn on ...
            ps.Play();
            for (var time = 0f; time < timer; time += Time.deltaTime)
            {
                yield return new WaitForFixedUpdate();
                bee.AddForce(transform.forward * WindPower);
            }             
            
            Debug.Log("PlayingParticles");
            yield return new WaitForSeconds(timer);
            // turn off particles
            ps.Stop();
            Debug.Log("StoppedParticles");
          
        }
    }
    
}