using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;

namespace Yungs.D305
{
    public class RoleInfoUI : MonoBehaviour
    {
        //[LabelText("技能状态UI")]
        public SkillStateUI[] skillStateUIs;
        [LabelText("HP Slider")]
        public SliderValue hp;
        [LabelText("MP Slider")]
        public SliderValue mp;
        [LabelText("Exp Slider")]
        public SliderValue exp;
        //[LabelText("角色属性UI")]
        public RolePropertyUI rolePropertyUI;

        private void Awake()
        {
            UpdateEvent();
        }

        private void UpdateEvent()
        {
            GlobalEvent.skillEnterCDEvent = SkillEnterCD;
            GlobalEvent.skillUpgradesEvent = SkillUpgrades;
            GlobalEvent.hpChangeEvent = HPUI;
            GlobalEvent.mpChangeEvent = MPUI;
            GlobalEvent.expChangeEvent = ExpUI;
            GlobalEvent.rolePropertyChangeEvent = SetRolePropertyUI;
        }

        /// <summary>
        /// 释放技能后，进入CD
        /// </summary>
        /// <param name="skillName">Q W E R D F</param>
        /// <param name="cd"></param>
        public void SkillEnterCD(string skillName, float cd)
        {
            for (int i = 0; i < skillStateUIs.Length; i++)
            {
                if (skillStateUIs[i].transform.name.ToLower() == skillName.ToLower())
                {
                    skillStateUIs[i].EnterCD(cd);
                    break;
                }
            }
        }
        /// <summary>
        /// 技能升级时等级
        /// </summary>
        /// <param name="skillName"></param>
        /// <param name="level">当前等级</param>
        public void SkillUpgrades(string skillName, int level)
        {
            for (int i = 0; i < skillStateUIs.Length; i++)
            {
                if (skillStateUIs[i].transform.name.ToLower() == skillName.ToLower())
                {
                    skillStateUIs[i].Upgrades(level);
                    break;
                }
            }
        }
        /// <summary>
        /// HP Slider
        /// </summary>
        /// <param name="val"></param>
        /// <param name="max"></param>
        public void HPUI(float val, float max)
        {
            var str = val.ToString("#") + "/" + max.ToString("#");
            hp.SetValue(val, max, str);
        }
        /// <summary>
        /// MP Slider
        /// </summary>
        /// <param name="val"></param>
        /// <param name="max"></param>
        public void MPUI(float val, float max)
        {
            var str = val.ToString("#") + "/" + max.ToString("#");
            mp.SetValue(val, max, str);
        }
        /// <summary>
        /// 经验 Slider
        /// </summary>
        /// <param name="val"></param>
        /// <param name="max"></param>
        /// <param name="level"></param>
        public void ExpUI(float val, float max, int level)
        {
            exp.SetValue(val, max, "等级:" + level);
        }
        /// <summary>
        /// 角色属性UI
        /// 力量，智力，物攻等 
        /// </summary>
        /// <param name="unit"></param>
        public void SetRolePropertyUI(Unit unit)
        {
            rolePropertyUI.SetValue(unit);
        }
    }
}