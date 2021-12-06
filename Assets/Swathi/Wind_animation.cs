using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windanimation : MonoBehaviour
{
    public ParticleSystem ps;
    public float timer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ps = GetComponent<ParticleSystem>();
        if (ps.time >= 10)
        {
            ps.Stop();
            timer = 0; 
            timer += Time.deltaTime; 
            if (timer >= 10){
            ps.Play();

            }
        }
        
    }
}
