using UnityEngine;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour 
    {
        [SerializeField] float weaponRange = 2f; //arbitrary value

        Transform target;
        Mover mover;


        private void Start() 
        {
            mover = GetComponent<Mover>();
        }

        private void Update() 
        {
            if (target == null) return;

            if (GetIsInRange())
            {
                mover.MoveTo(target.position);
            }
            else
            {
                mover.Stop();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) > weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            print("Die fool!!");
        }

        public void Cancel()
        {
            target = null;
        }
    }
}