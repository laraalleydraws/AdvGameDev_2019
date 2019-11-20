using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    [SerializeField] Vector3 openOffset = new Vector3(-5, 0, 0);
    Vector3 openPosition;
    Vector3 closedPosition;
    Vector3 targetPosition;
    [SerializeField] float speed = 2;
    [SerializeField] float delay = 2f;
    bool waiting = false;
    float waitElapsed = 0;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;
        targetPosition = openPosition;
    }

    void Update()
    {
        if (waiting)
        {
            waitElapsed += Time.deltaTime;
            if (waitElapsed >= delay)
            {
                waiting = false;
            }
            else
            {
                return;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPosition == openPosition) targetPosition = closedPosition; else targetPosition = openPosition;
            waiting = true;
            waitElapsed = 0;
        }
    }
}
