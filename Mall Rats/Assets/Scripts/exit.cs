using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    [SerializeField]
    private int score;
    public GameObject ratFollower;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            score++;
            ratFollower.SetActive(false);
        }
    }
}
