using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public class SkillMonoAni : StateMachineBehaviour {

    public Transform []skillTr;
    public Transform handTr;
    public static Transform targetTr;
    public float beginTime = 0.3f;
    bool isNew = false;
    int index = 0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isNew = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isNew)
        {
            if (stateInfo.normalizedTime > beginTime)
            {
                isNew = false;
                skillTr[index].gameObject.SetActive(true);
                skillTr[index].position = handTr.position;
                var c = index;
                skillTr[index].DOMove(targetTr.localPosition, Vector3.Distance(targetTr.localPosition, skillTr[index].position) / 5).SetEase(Ease.Linear).OnComplete(() => skillTr[c].gameObject.SetActive(false));
                if (++index >= skillTr.Length)
                {
                    index = 0;
                }
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
       
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
