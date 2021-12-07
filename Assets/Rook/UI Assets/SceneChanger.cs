using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        //Debug.Log("Pressed Button");
        SceneManager.LoadScene(sceneName); //go to scene 

    }
}
