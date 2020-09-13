using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    private Transform target;

    private Mover mover;

    [SerializeField] private float weaponRange = 2f;
    
    public void Attack(CombatTarget combatTarget)
    {
        Debug.Log("Hiyah!");
        target = combatTarget.transform;
    }


    private void Start()
    {
        mover = GetComponent<Mover>();
    }

    public void Cancel()
    {
        target = null;
    }

    private void Update()
    {
        if (target == null) return;
        
        bool isInRange = Vector3.Distance(transform.position, target.position) > weaponRange;
        if (isInRange)
        {
            mover.MoveTo(target.position);
        }
        else
        {
            mover.Stop();
        }
    
    }
}
