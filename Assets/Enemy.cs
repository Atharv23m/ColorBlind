using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Color color;

    public float wooble , height;

    private MeshRenderer plane;

    private NavMeshAgent agent;

    public Player player;

    private Vector3 initloc;

    private float y;

    private bool searching = false;

    public LevelManager lvlmanager;

    private void Awake()
    {
        plane = GetComponentInChildren<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
        initloc = transform.position;
    }
    private void Start()
    {
        plane.material.color = color;
    }

    public void SetDestination()
    {
        searching = true;
    }

    public void ResetT()
    {
        transform.position = initloc;
    }

    IEnumerator Attack()
    {

        agent.SetDestination(player.transform.position);
            yield return new WaitForSeconds(4f);
        
        lvlmanager.Defeat();
    }

    private void Update()
    {
        if(searching)
        {
            agent.SetDestination(player.transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (player.currentColor != color)
            {
                StartCoroutine(Attack());
            
            }
            else
            {
                searching = false;
                agent.SetDestination(initloc);
            } 
        }
    }
}
