using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyController : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;
    Transform cannon;
    public ScoreManager scoreManager;
    const int WAIT_TIME = 4;
    public AudioSource tickSource;

    // Start is called before the first frame update
    void Start()
    {
        cannon = transform.parent;
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
        tickSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        scoreManager.updateScore(1);
        Invoke("ResetPiggy", 15f);
        tickSource.Play();
      
    }

    void ResetPiggy()
    {

        transform.parent = cannon;
        transform.localPosition = startPosition;
        transform.localRotation = startRotation;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        GetComponent<Rigidbody2D>().angularVelocity = 0;


    }
}