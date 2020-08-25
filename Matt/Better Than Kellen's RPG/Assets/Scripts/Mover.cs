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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("moving");
            MoveToCursor();
        }
        

    }

    private void UpdateAnimator()
    {
        velocity = nav.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        
    }

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // For ray-casting.
    void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if (hasHit)
        {
            nav.destination = hit.point;
            Debug.DrawRay(ray.origin, ray.direction * 100);
        }
    }
}
