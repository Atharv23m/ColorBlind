using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public LevelManager levelmanager;

    private Collider triggerc;

    public Color permit = new Color();

    public ColorManager clr;

    public Player player;

    private CubeColor cube;

        private void Awake()
    {
        cube = transform.parent.GetComponentInChildren<CubeColor>();
    }

    public void Start()
    {
        triggerc = GetComponent<CapsuleCollider>();
        //     transform.parent.GetComponentInChildren<CubeColor>().SetTrailColor(permit);
        cube.SetTrailColor(permit);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && player.currentColor != permit)
        {
            levelmanager.PlayerFoundbyTower();
            }
    }

    public void SetColor(Color color)
    {
        permit = color;
    }
}
