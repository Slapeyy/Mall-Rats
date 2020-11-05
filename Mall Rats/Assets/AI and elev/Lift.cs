using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Transform top;
    public Transform bottom;

    public int speed;
    public bool max;

    public float timeLeft = 1f;


    private void Update()
    {
        if (transform.position.y == top.position.y)
        {
            max = true;
        }
        if (transform.position.y == bottom.position.y)
        {
            max = false;
        }
        if (max == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, bottom.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, top.position, speed * Time.deltaTime);
        }
    }
}
