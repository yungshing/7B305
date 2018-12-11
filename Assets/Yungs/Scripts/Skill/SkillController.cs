using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using Werewolf.StatusIndicators.Components;
using UnityEngine.AI;

namespace Yungs.D305
{
    public class SkillController : MonoBehaviour
    {
        public Animator playerAnim;
        public NavMeshAgent meshAgent;
        public Unit selfUnit;
        [LabelText("技能攻击")]
        public SkillItem[] skillItems;

        SkillItem currSkillItem = null;
        /// <summary>
        /// 技能指示器是否亮着
        /// </summary>
        bool isSplitShown = false;
        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < skillItems.Length; i++)
            {
                skillItems[i].skillMono.selfUnit = selfUnit;
            }
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < skillItems.Length; i++)
            {
                if (Input.GetKeyDown(skillItems[i].keyCode))
                {
                    if (currSkillItem != null && currSkillItem.splat != null)
                    {
                        currSkillItem.splat.OnHide();
                        isSplitShown = false;
                    }
                    currSkillItem = skillItems[i];
                    if (currSkillItem.skillMono.CheckCD())
                    {
                        return;
                    }
                    if (currSkillItem.splat != null)
                    {
                        currSkillItem.splat.OnShow();
                        isSplitShown = true;
                        Cursor.visible = false;
                    }
                    else ///没有指示器的技能，则为瞬发技能或者状态技能
                    {
                        currSkillItem.skillMono.Play();
                    }
                }
            }

            if (currSkillItem != null && Input.GetKeyUp(currSkillItem.keyCode))
            {
                if (currSkillItem.splat != null)
                {
                    currSkillItem.splat.OnHide();
                    isSplitShown = false;
                }
                Cursor.visible = true;
            }
            if (Input.GetMouseButtonDown(2) && isSplitShown)
            {
                if (currSkillItem.splat != null)
                {
                    currSkillItem.splat.OnHide();
                    isSplitShown = false;
                }
                Cursor.visible = true;
            }
            if (Input.GetMouseButtonDown(0) && currSkillItem != null && isSplitShown)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    currSkillItem.skillMono.selfUnit.transform.LookAt(hitInfo.point);
                    meshAgent.isStopped = true;
                    playerAnim.SetBool("isRun", false);
                    playerAnim.Play("Attack1");
                    YungsCharactorController.isMonster = false;
                    var tr = hitInfo.transform;
                    var pos = hitInfo.point;

                    if (currSkillItem.skillMono.isDirectivity)
                    {
                        if (hitInfo.transform.tag == "Monster")
                        {
                            GlobalEvent.playSkillEvent = () =>
                            {
                                if (currSkillItem != null)
                                {
                                    currSkillItem.skillMono.Play(tr);
                                }
                            };
                        }
                    }
                    else
                    {
                        GlobalEvent.playSkillEvent = () =>
                        {
                            if (currSkillItem != null)
                            {
                                currSkillItem.skillMono.Play(pos);
                            }
                        };
                    }
                    currSkillItem.splat.OnHide();
                    isSplitShown = false;
                }
                Cursor.visible = true;
            }
        }
        [System.Serializable]
        public class SkillItem
        {
            [HorizontalGroup,LabelText("快捷键"),LabelWidth(40)]
            public KeyCode keyCode;
            [HorizontalGroup,LabelText("技能特效"), LabelWidth(55)]
            public SkillMono skillMono;
            [HorizontalGroup,LabelText("指示器"), LabelWidth(40)]
            public Splat splat;
        }
    }
}