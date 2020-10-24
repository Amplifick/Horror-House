using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject light;
    private bool on = false;
    public AudioSource source;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerStay(Collider plyr)
    {
        if (plyr.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !on)
        {
            light.SetActive(true);
            on = true;
            source.Play();
        }
        else if (plyr.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && on)
        {
            light.SetActive(false);
            on = false;
            source.Play();
        }
    }
}
