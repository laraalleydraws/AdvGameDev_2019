using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    // Use this for initialization
    public void changemenuscene(string SampleScene)
    {
        SceneManager.LoadScene (SampleScene);
    }
}
