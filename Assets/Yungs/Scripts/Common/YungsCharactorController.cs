using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Yungs.D305
{
    public class YungsCharactorController : MonoBehaviour
    {
        public NavMeshAgent meshAgent;
        public NormalAttack normalAttack;
        private Animator animator;
        public static bool isMonster = false;
        Transform monsterTr = null;
        bool isChangeTar = false;
        Unit selfUnit;
        RaycastHit hitInfo;
        private void Start()
        {
            animator = GetComponent<Animator>();
            selfUnit = GetComponent<Unit>();
        }
        // Update is called once per frame
        void Update()
        {
            if (selfUnit.isPlayer)
            {
                PlayerController();
            }
        }

        void PlayerController()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (meshAgent.isStopped)
                    {
                        meshAgent.isStopped = false;
                    }
                    meshAgent.SetDestination(hitInfo.point);
                    isMonster = hitInfo.transform.tag == "Monster";
                    if (isMonster)
                    {
                        monsterTr = hitInfo.transform;
                        isChangeTar = true;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                meshAgent.isStopped = true;
                isMonster = false;
                CharactorMoveAnimator(false);
            }

            if (isMonster && monsterTr.gameObject.activeSelf)
            {
                if ((meshAgent.transform.localPosition - monsterTr.localPosition).sqrMagnitude <= selfUnit.attackDistance * selfUnit.attackDistance)
                {
                    var tmp = monsterTr;
                    if (isChangeTar)
                    {
                        isChangeTar = false;
                        transform.LookAt(hitInfo.point);
                        meshAgent.isStopped = true;
                        GlobalEvent.playSkillEvent = () => normalAttack.Attack(tmp);
                    }
                    animator.Play("Attack1");
                }
            }
            CharactorMoveAnimator(meshAgent.remainingDistance > 1);
        }

        void CharactorMoveAnimator(bool isRun)
        {
            if (animator.GetBool("isRun") != isRun)
            {
                animator.SetBool("isRun", isRun);
            }
        }
        public void PlaySkill()
        {
            if (GlobalEvent.playSkillEvent != null)
            {
                GlobalEvent.playSkillEvent();
            }
        }

        public void AnimatorOver()
        {
            if (GlobalEvent.playSkillOverEvent != null)
            {
                GlobalEvent.playSkillOverEvent();
            }
        }

 
        void SkillControl()
        {

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hitInfo))
                {
                    transform.LookAt(hitInfo.point);
                }
            }
        }
    }
}