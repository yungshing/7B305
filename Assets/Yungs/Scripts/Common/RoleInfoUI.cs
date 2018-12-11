using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;

namespace Yungs.D305
{
    public class RoleInfoUI : MonoBehaviour
    {
        //[LabelText("����״̬UI")]
        public SkillStateUI[] skillStateUIs;
        [LabelText("HP Slider")]
        public SliderValue hp;
        [LabelText("MP Slider")]
        public SliderValue mp;
        [LabelText("Exp Slider")]
        public SliderValue exp;
        //[LabelText("��ɫ����UI")]
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
        /// �ͷż��ܺ󣬽���CD
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
        /// ��������ʱ�ȼ�
        /// </summary>
        /// <param name="skillName"></param>
        /// <param name="level">��ǰ�ȼ�</param>
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
        /// ���� Slider
        /// </summary>
        /// <param name="val"></param>
        /// <param name="max"></param>
        /// <param name="level"></param>
        public void ExpUI(float val, float max, int level)
        {
            exp.SetValue(val, max, "�ȼ�:" + level);
        }
        /// <summary>
        /// ��ɫ����UI
        /// �������������﹥�� 
        /// </summary>
        /// <param name="unit"></param>
        public void SetRolePropertyUI(Unit unit)
        {
            rolePropertyUI.SetValue(unit);
        }
    }
}