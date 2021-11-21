using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChildSelector : MonoBehaviour
{
    [SerializeField] bool chunk;
    [SerializeField] bool obstacle;
    [SerializeField] bool devMode;
    bool hasEnabled; // have we enabled?
    int choice;

    private void Start()
    {
        Regen();
    }

    public void Regen()
    {
        transform.GetChild(choice).gameObject.SetActive(false);
        choice = Random.Range(0, transform.childCount);
        transform.GetChild(choice).gameObject.SetActive(true);
    }
}
