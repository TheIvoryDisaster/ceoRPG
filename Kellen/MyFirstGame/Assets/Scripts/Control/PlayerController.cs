using UnityEngine;
using RPG.Movement; //Dependency
using RPG.Combat; //Dependency

namespace RPG.Control 
{
    public class PlayerController : MonoBehaviour 
    {
        private void Update() 
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
            //print("Nothing to do.");
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                }
                return true; //This can only be reached if a CombatTarget was hit by the Raycast.
            }

            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    // GetComponent<Mover>().MoveTo(hit.point); //We are using StartMoveAction() for this instead of MoveTo(). This now allows the player to move away from its combat target.
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

    }
}