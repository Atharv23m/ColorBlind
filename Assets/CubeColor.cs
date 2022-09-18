using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    MeshRenderer mesh;

    public Color color; 


    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    public void SetTrailColor(Color clr)
    {
        mesh.material.color = clr;
    }

    public Color GetTrailColor()
    {
        return mesh.material.color;
    }
}
