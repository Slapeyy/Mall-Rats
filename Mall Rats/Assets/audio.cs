using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    AudioSource Darkwood;

        bool Play;
    bool ToggleChange;

    // Start is called before the first frame update
    void Start()
    {
        Darkwood = GetComponent<AudioSource> ();
        Play = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Play == false && ToggleChange == true)
        {
            Darkwood.Play();
            ToggleChange = false;
        }

        if (Play == false && ToggleChange == true)
        {
            Darkwood.Stop();
            ToggleChange = false;
        }
    }

}
