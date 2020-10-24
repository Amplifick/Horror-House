using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeSusto : MonoBehaviour
{

    public Transform target;
    public float speed;
    public bool _active;


    // Start is called before the first frame update

    void Start()
    {
        speed = 1.4f;
        _active = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_active==true)
        {
            PrimerMovimiento();

        }
    }

    public void PrimerMovimiento()
    {
        Debug.Log("Aqui");
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,target.position,step);
        
        
    }
}
