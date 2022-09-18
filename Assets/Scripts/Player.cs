using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Animator animator;

    public float velocity;

    private int speedHash;

    private bool walking;

    private NavMeshAgent agent;

    private GameObject finalOrb;

    public Color currentColor;

    private Dictionary<GameObject, bool> hierarchy = new Dictionary<GameObject, bool>();

    private List<GameObject> orbs = new List<GameObject>();

    private Orb orb;
    
    public ColorManager colorManager;

    public int maxD = 20;

    private Camera cam;

    private Transform initpos;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        speedHash = Animator.StringToHash("Speed");

        StartCoroutine("LookDown");

        StartCoroutine("FallDown");

        currentColor = colorManager.A;

        walking = true;

        cam = Camera.main;

        initpos = transform;
      
      //  agent.SetDestination(new Vector3(10, 0, 10));
    }

    IEnumerator LookDown()
    {
            while (agent.velocity.magnitude < 0.1)
            {
                if (Random.value > 0.8)
                {
                    animator.SetTrigger("Look Down");
                walking = false;
                }

                yield return new WaitForSeconds(Random.Range(4, 6));
            }
    }
    IEnumerator FallDown()
    {
        while (true)
        {
            if (Random.value < 0.1 && walking == true)
            {
                animator.SetTrigger("Fall");
                walking = false;
            }
            yield return new WaitForSeconds(Random.Range(5,10));
        }
    }

    IEnumerator ChangeCurrentCol()
    {
        GetComponentInChildren<Movement_orb>().SetTrailColor(colorManager.nextColor(GetComponentInChildren<Movement_orb>().GetTrailColor()));
         yield return new WaitForSeconds(1.5f);
        currentColor = GetComponentInChildren<Movement_orb>().GetTrailColor();
    }

    bool InSight(GameObject obj)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, obj.transform.position - transform.position , out hit , maxD))
        {
            if (hit.collider.gameObject == obj)
                return true;
            else
                return false;
        }
        else
            return false;
    }

    public void ResetT()
    {
        transform.position = initpos.position;
        transform.rotation = initpos.rotation;
        
    }
    public void SetOrbs(Transform[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            orbs.Add(points[i].gameObject);

        }
    }

    private void Traverse()
    {
        foreach(GameObject orb in orbs)
        {
            if(InSight(orb) && walking)
            {
                if(orb.GetComponent<Orb>().GetColor() == currentColor)
                {
                    agent.SetDestination(orb.transform.position);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(speedHash , agent.velocity.magnitude);
        if(walking)
            Traverse();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "Orb")
                {
                    hit.collider.GetComponent<Orb>().ChangeColor();
                    
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(ChangeCurrentCol());
        }

        if(!walking)
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
            walking = true;
            agent.isStopped = false;
        }
        else
        {
            walking = false;
        }
    }
}
