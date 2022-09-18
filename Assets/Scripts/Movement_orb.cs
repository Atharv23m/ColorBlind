using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_orb : MonoBehaviour
{

    public float radius;

    public float height;

    public float speed = 1;

    public float phase = 1;

    private Transform parent;

    float x, y, z , angle = 0;

    ParticleSystem part;

    ParticleSystem.ColorOverLifetimeModule cmod;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<Transform>();

        part = GetComponent<ParticleSystem>();

        cmod = part.colorOverLifetime;

        cmod.color = new ParticleSystem.MinMaxGradient(Color.yellow , Color.yellow);

    }
    public void SetTrailColor(Color clr)
    {
        cmod.color = new ParticleSystem.MinMaxGradient( clr , clr);
    }

    public Color GetTrailColor()
    {
        return cmod.color.colorMin;
    }

    // Update is called once per frame
    void Update()
    {

        angle += 2 * Mathf.PI * Time.fixedDeltaTime * speed;
       x = radius * Mathf.Cos(angle);
       y = height + Mathf.Sin(angle/4);
       z = radius * Mathf.Sin(angle);

        if (angle > phase * Mathf.PI)
            angle = 0;
        transform.localPosition = new Vector3(x, y, z);

    }
}
