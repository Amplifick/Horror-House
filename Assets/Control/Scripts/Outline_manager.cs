using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_manager : MonoBehaviour
{
    // Start is called before the first frame update

    private MeshRenderer mesh;
    public float maxOutlineWidth;
    public Color OutlineColor;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowOutLine()
    {
        mesh.material.SetFloat("_Outline", maxOutlineWidth);
        mesh.material.SetColor("_OutlineColor",OutlineColor);
    }

    public void HideOutLine()
    {
        mesh.material.SetFloat("_Outline", 0f);
    }

}
