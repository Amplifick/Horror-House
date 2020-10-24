using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_RayCast : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camara;
    public float dist;

    private Outline_manager prevController;
    private Outline_manager currentController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleLookAtRay();
    }

    private void HandleLookAtRay()
    {
        Ray ray = camara.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, dist))
        {
            if (hit.collider.CompareTag("Interactuar"))
            {
                currentController = hit.collider.GetComponent<Outline_manager>();

                if(prevController != currentController)
                {
                    HideOutLine();
                    ShowOutline();
                }

                prevController = currentController;
            }
            else
            {
                HideOutLine();
            }
        }
        else
        {
            HideOutLine();
        }


    }

    private void ShowOutline()
    {
        if(currentController != null)
        {
            currentController.ShowOutLine();
        }
    }

    private void HideOutLine()
    {
        if(prevController != null)
        {
            prevController.HideOutLine();
            prevController = null;
        }
    }
}
