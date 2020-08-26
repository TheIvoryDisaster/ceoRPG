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
    private bool clicking = false;
    [SerializeField] Transform target;

    // Udemy course movement
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || clicking)
        {
            clicking = true;
            Debug.Log("moving");
            MoveToCursor();
        }

        if (Input.GetMouseButtonUp(0))
        {
            clicking = false;
        }

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
