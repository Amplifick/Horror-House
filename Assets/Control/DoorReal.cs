using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReal : MonoBehaviour
{
    // Start is called before the first frame update
    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    private bool open;
    private bool enter;
    private Vector3 defaultRot,openRot;
    

    void Start()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            //door open
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);

        }
        else
        {
            //Close door
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);

        }

        if(Input.GetKeyDown("e") && enter)
        {
            open = !open;
        }

    }

    private void OnGUI()
    {
        if (enter)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Press [E] to open the door");
        }
    }

    //This activates the The main function (Its on Update) when player is near the door

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enter = false;
        }
    }
}
