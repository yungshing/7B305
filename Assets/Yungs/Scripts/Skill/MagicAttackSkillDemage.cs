using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;

namespace Yungs.D305
{
    [AddComponentMenu("Yungs/Skill/魔法技能伤害"), TypeInfoBox("魔法伤害：固定伤害 + 百分比 * 角色物理攻击力")]
    public class MagicAttackSkillDemage : SkillItem
    {

        public override string Name
        {
            get
            {
                return "魔法技能伤害";
            }
        }

        public override DamageStyle AttackStyle
        {
            get
            {
                return DamageStyle.MAGIC;
            }
        }

        public override void TriggerEnter(Unit unit)
        {
            unit.BeAttack(CalDamage(),unit);
        }
    }

}