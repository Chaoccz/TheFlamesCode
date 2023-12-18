using UnityEngine;

namespace Assets.Scripts
{
    public class PatrolBehaviour : StateMachineBehaviour
    {
        private GameObject[] patrolPoints;

        public float speed;

        private int randomPoint;
        //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            patrolPoints = GameObject.FindGameObjectsWithTag("patrolPoints");
            randomPoint = Random.Range(0, patrolPoints.Length);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position,
                patrolPoints[randomPoint].transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(animator.transform.position, patrolPoints[randomPoint].transform.position) < 0.1f)
            {
                randomPoint = Random.Range(0, patrolPoints.Length);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

    }
}
