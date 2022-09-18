using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    // Start is called before the first frame update
    public Color current;

    private MeshRenderer mRenderer;

    public ColorManager colorManager;

    float timer = 0f;

    void Start()
    {
 
        mRenderer = GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mRenderer.material.color = current;
        if(timer >= 0)
          timer -= Time.deltaTime;
    }

    public void ChangeColor()
    {
        if(timer <= 0)
        {
            current = colorManager.nextColor(current);
            // timer to change orb color
            timer = 0.3f;
        }
      
    }

    public Color GetColor()
    {
        return current;
    }
}
