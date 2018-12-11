using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Sirenix.OdinInspector;
namespace Yungs.D305
{
    [RequireComponent(typeof(SkillMono))]
    public class SkillItem : YungsMono
    {
        [ShowInInspector,LabelText("名字"),PropertyOrder(-99)]
        public virtual string Name
        {
            get
            {
                return "";
            }
        }
        [HideInInspector]
        public Unit selfUnit;
        [ShowInInspector,LabelText("攻击类型"), PropertyOrder(-98)]
        public virtual DamageStyle AttackStyle
        {
           get
            {
                return DamageStyle.PHYSICS;
            }
        }
        /// <summary>
        /// 技能等级
        /// </summary>
        public int Level { get; set; }
        [LabelText("触发类型")]
        public SkillMono.SkillTriggerStyle skillTriggerStyle;
        [LabelText("固定值")]
        public ItemValue fixedValue;
        [LabelText("百分比")]
        public ItemValue percentValue;
        [HideInInspector]
        public SkillMono skillMono;

        private void Awake()
        {
            skillMono = GetComponent<SkillMono>();
        }
        /// <summary>
        /// 计算伤害
        /// </summary>
        /// <returns></returns>
        public virtual IDamage CalDamage()
        {
            float a = 0;
            float b = 0;
            percentValue.UpdateValue(Level);
            fixedValue.UpdateValue(Level);
            if (AttackStyle == DamageStyle.MAGIC)
            {
                a = selfUnit.unitProperty.magicAttack.CurrValue * PropertyConstParam.MagicToDemage * (1 + percentValue.CurrValue * 0.01f) + fixedValue.CurrValue;
            }
            else if (AttackStyle == DamageStyle.PHYSICS)
            {
                a = selfUnit.unitProperty.attack.CurrValue * PropertyConstParam.AttackToDemage * (1 + percentValue.CurrValue * 0.01f) + fixedValue.CurrValue;
            }
            if (UnityEngine.Random.Range(0, 100) < selfUnit.unitProperty.critical.CurrValue)
            {
                b = a * 2.5f * (1 + selfUnit.unitProperty.criticalDemage.ExtraPercent);
            }
            else
            {
                b = 0;
            }
            return new DamageValue()
            {
                DamageStyle = AttackStyle,
                AttackDamage = (int)a,
                AttachDamage = (int)(a * selfUnit.unitProperty.attachAttack.CurrValue),
                CriticalDamage = (int)b
            };
        }
        public virtual void TriggerEnter(Unit unit) { }
        public virtual void TriggerStay(Unit unit) { }
        public virtual void TriggerExit(Unit unit) { }
    }
}
