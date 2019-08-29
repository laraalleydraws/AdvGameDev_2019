using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    public GameObject piggyPlayer; // this is a reference to the player object
    public float strenth = 200;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        Vector3 mousePositionInWorldCoordinates = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = mousePositionInWorldCoordinates - transform.position;

        float alpha = Mathf.Acos(Vector3.Dot(Vector3.right, direction.normalized))*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, alpha));

        if (Input.GetMouseButtonUp(0))
        {
            piggyPlayer.transform.parent = null;
            piggyPlayer.GetComponent<Rigidbody2D>().gravityScale = 1;
            piggyPlayer.GetComponent<Rigidbody2D>().AddForce(direction.normalized * strenth);
        }

    }
    public void Run()
    {

    }
}
