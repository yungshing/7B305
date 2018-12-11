using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
namespace Yungs.D305
{
    [AddComponentMenu("Yungs/Skill/物理技能伤害"), TypeInfoBox("物理伤害：固定伤害 + 百分比 * 角色物理攻击力")]
    public class AttackSkillDemage : SkillItem
    {
        public override string Name
        {
            get
            {
                return "物理技能伤害";
            }
        }

        public override void TriggerEnter(Unit unit)
        {
            //if (skillMono.isDirectivity)
            //{
            //    if (skillMono.attackTarget == unit.transform)
            //    {
            //        unit.BeAttack(CalDamage(), unit);
            //        this.gameObject.SetActive(false);
            //    }
            //}
            //else
            //{
            //    unit.BeAttack(CalDamage(), unit);
            //    this.gameObject.SetActive(false);
            //}
            Debug.Log(skillMono.attackTarget.name+" " + unit.transform.name);
            if (!skillMono.isDirectivity || skillMono.attackTarget.name == unit.transform.name)
            {
                unit.BeAttack(CalDamage(), unit);
                this.gameObject.SetActive(false);
            }
        }
    }
}