using System;
using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        public Mover mover;
        private bool clicking = false;

        private void Start()
        {
            mover = GetComponent<Mover>();
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) || clicking)
            {
                clicking = true;
                MoveToCursor();
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                clicking = false;
            }
        }

        void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                mover.MoveTo(hit.point);
                Debug.DrawRay(ray.origin, ray.direction * 100);
            }
        }
    }