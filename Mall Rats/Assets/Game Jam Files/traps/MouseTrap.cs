using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    public GameObject trapClosed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("trap active");
            trapClosed.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
