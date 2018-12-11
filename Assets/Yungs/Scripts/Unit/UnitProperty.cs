using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Sirenix.OdinInspector;
namespace Yungs.D305
{

    [System.Serializable]
    public class UnitProperty
    {
        public int Level { get; set; }
        /// <summary>
        /// 物理攻击力
        /// </summary>
        [LabelText("物理攻击力")]
        public Attack attack;
        /// <summary>
        /// 魔法攻击力
        /// </summary>
        [LabelText("魔法攻击力")]
        public MagicAttack magicAttack;
        [LabelText("附加伤害(百分比)")]
        public AttachAttack attachAttack;
        /// <summary>
        /// 力量
        /// </summary>
        [LabelText("力量")]
        public Strength strength;
        /// <summary>
        /// 智力
        /// </summary>
        [LabelText("智力")]
        public Intelligence intelligence;
        /// <summary>
        /// 体力
        /// </summary>
        [LabelText("体力")]
        public Enargy enargy;
        /// <summary>
        /// 精神
        /// </summary>
        [LabelText("精神")]
        public Spirit spirit;
        /// <summary>
        /// 护甲
        /// </summary>
        [LabelText("护甲")]
        public Shield shield;
        /// <summary>
        /// 魔抗
        /// </summary>
        [LabelText("魔抗")]
        public SpellResistance spellResistance;
        /// <summary>
        /// 防御力
        /// </summary>
        [LabelText("物理防御力")]
        public Defensive defensive;
        /// <summary>
        /// 魔法防御力
        /// </summary>
        [LabelText("魔法防御力")]
        public MagicDefensive magicDefensive;
        [LabelText("无视伤害")]
        public IgnoreDamage ignoreDamage;
        /// <summary>
        /// 暴击机率
        /// </summary>
        [LabelText("暴击机率")]
        public Critical critical;
        /// <summary>
        /// 暴击伤害增加量（百分比）
        /// </summary>
        [LabelText("暴击伤害增加量（百分比）")]
        public CriticalDemage criticalDemage;
        /// <summary>
        /// 攻击速度
        /// </summary>
        [LabelText("攻击速度(次/秒)")]
        public AttackSpeed attackSpeed;
        /// <summary>
        /// 释放速度
        /// </summary>
        [LabelText("释放速度"),InfoBox("放技能所需要时间减少百分比,10为10%")]
        public MagicSpeed magicSpeed;
        /// <summary>
        /// 移动速度
        /// </summary>
        [LabelText("移动速度,默认设置300")]
        public MoveSpeed moveSpeed;
        /// <summary>
        /// 抗性
        /// </summary>
        [LabelText("抗性"),InfoBox("负面影响持续时间减少量百分比,10为10%")]
        public DeBuff deBuff;
        /// <summary>
        /// 血量
        /// </summary>
        [LabelText("血量")]
        public HP hp;
        /// <summary>
        /// 蓝量
        /// </summary>
        [LabelText("蓝量")]
        public MP mp;

        /// <summary>
        /// 更新属性数据
        /// 升级 或者 换装时调用 。或者 有任务属性变动时 调用
        /// </summary>
        public void UpdateValue()
        {
            attachAttack.UpdateValue(Level);
            strength.UpdateValue(Level);
            intelligence.UpdateValue(Level);
            enargy.UpdateValue(Level);
            spirit.UpdateValue(Level);
            shield.UpdateValue(Level);
            spellResistance.UpdateValue(Level);
            ignoreDamage.UpdateValue(Level);
            defensive.UpdateValue(Level,()=> shield.CurrValue * PropertyConstParam.ShieldToDefen);
            magicDefensive.UpdateValue(Level,()=> spellResistance.CurrValue * PropertyConstParam.SpellResToMDefen);

            critical.UpdateValue(Level);
            criticalDemage.UpdateValue(Level);
            attackSpeed.UpdateValue(Level);
            magicSpeed.UpdateValue(Level);
            moveSpeed.UpdateValue(Level);
            deBuff.UpdateValue(Level);

            hp.UpdateValue(Level, () => enargy.MaxValue * PropertyConstParam.EnargyToHP);
            hp.Recovery = hp.MaxValue / PropertyConstParam.LimitHPRecSec + enargy.MaxValue * PropertyConstParam.EnartyToHPRec;

            mp.UpdateValue(Level, () => spirit.MaxValue * PropertyConstParam.SpiritToMP);
            mp.Recovery = mp.MaxValue / PropertyConstParam.LimitMPRecSec + spirit.MaxValue * PropertyConstParam.SpiritToMPRec;


            attack.UpdateValue(Level,()=>strength.MaxValue * PropertyConstParam.StrengthToAttack);
            magicAttack.UpdateValue(Level, () => intelligence.MaxValue * PropertyConstParam.IntelligenceToAttack);
        }
    }
}
