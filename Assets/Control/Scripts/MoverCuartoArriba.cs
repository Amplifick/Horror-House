using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCuartoArriba : MonoBehaviour
{
    public GameObject obj1, obj2, obj3, obj4, obj5, obj6;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoverObj()
    {
        obj1.transform.position = new Vector3(obj1.transform.position.x, obj1.transform.position.y, obj1.transform.position.z + 0.32f);
        obj2.transform.position = new Vector3(obj2.transform.position.x, obj2.transform.position.y, obj2.transform.position.z + 0.32f);
        obj3.transform.Translate(new Vector3(0, 0, 0.36f));
        obj4.transform.Translate(new Vector3(0, 0, 0.36f));
        obj5.transform.Translate(new Vector3(0, 0, 0.36f));
        obj6.transform.Translate(new Vector3(0, 0, 0.36f));



    }
}
