using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzParpadeante : MonoBehaviour
{

    public Light luzParpadea1, luzParpadea2, luzParpadea3;
    public float minEsperar, maxEsperar;
    public AudioSource source,source1,source2;
    
    
    // Start is called before the first frame update

    void Start()
    {
        luzParpadea1.GetComponent<Light>();
        luzParpadea2.GetComponent<Light>();
        luzParpadea3.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public IEnumerator Parpadeo()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minEsperar, maxEsperar));
            luzParpadea1.enabled = !luzParpadea1.enabled;
            luzParpadea2.enabled = !luzParpadea2.enabled;
            luzParpadea3.enabled = !luzParpadea3.enabled;
            source.Play();
            source1.Play();
            source2.Play();
        } 
    }

    public void parpadearLuz()
    {
        StartCoroutine(Parpadeo());
    }
}
