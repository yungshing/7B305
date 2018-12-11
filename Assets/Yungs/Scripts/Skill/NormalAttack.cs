using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;

namespace Yungs.D305
{
    public class NormalAttack : YungsMono
    {
        public AttackSkillDemage[] attackSkillDemages;
        [LabelText("坨子移动速度")]
        public float speed;
        public Unit selfUnit;
        int index = 0;

        private void Start()
        {
            for (int i = 0; i < attackSkillDemages.Length; i++)
            {
                attackSkillDemages[i].skillMono.Speed = speed;
                attackSkillDemages[i].skillMono.Level = 1;
                attackSkillDemages[i].skillMono.selfUnit = selfUnit;
            }
        }
        public void Attack(Transform tar)
        {
            transform.gameObject.SetActive(true);
            attackSkillDemages[index].skillMono.Play(tar);
            if (++index >= attackSkillDemages.Length)
            {
                index = 0;
            }
        }
    }
}