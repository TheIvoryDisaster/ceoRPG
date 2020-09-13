using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator ant;
    private Vector3 velocity;
    [SerializeField] Transform target;

    // Udemy course movement
    void Update()
    {

        UpdateAnimator();

    }

    private void UpdateAnimator()
    {
        velocity = nav.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        ant.SetFloat("forwardSpeed", speed);
    }

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        ant = GetComponent<Animator>();
    }

    /// <summary>
    /// Gets the cursor position and sets its raycast hit as the new navmesh agent target
    /// </summary>
    void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if (hasHit)
        {
            MoveTo(hit.point);
            Debug.DrawRay(ray.origin, ray.direction * 100);
        }
    }

    /// <summary>
    /// Sets the navmesh destination
    /// </summary>
    /// <param name="hit">Navmesh destination target</param>
    public void MoveTo(Vector3 hit)
    {
        nav.destination = hit;
        nav.isStopped = false;
    }
    
    /// <summary>
    /// Sets the navmesh destination
    /// </summary>
    /// <param name="hit">Navmesh destination target</param>
    public void MoveTo(Vector3 hit, float stopRange)
    {
        nav.isStopped = false;
        nav.destination = hit;
        nav.stoppingDistance = stopRange;
    }

    public void Stop()
    {
        nav.isStopped = true;
    }

    public void StartMoveAction(Vector3 destination)
    {
        GetComponent<Fighter>().Cancel();
        MoveTo(destination);
    }
}
