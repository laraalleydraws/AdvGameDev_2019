using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{

    void OnTriggerEnter(Collider ChangeScene) 
    {
        if (ChangeScene.gameObject.CompareTag("PiggyController"))
        {
            SceneManager.LoadScene ("endscene"); 
        }
    }

}

