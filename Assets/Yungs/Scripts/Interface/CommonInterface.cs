using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirenix.OdinInspector;
namespace Yungs.D305
{
    public interface IStyle
    {
        /// <summary>
        /// 攻击类型 物理  魔法
        /// </summary>
        DamageStyle AttackStyle { get; set; }
        Manner Manner { get; set; }
    }
    public enum DamageStyle
    {
        [LabelText("物理")]
        PHYSICS,
        [LabelText("魔法")]
        MAGIC
    }
    /// <summary>
    /// 态度
    /// </summary>
    public enum Manner
    {
        [LabelText("友好")]
        FRIEND,
        [LabelText("敌意")]
        ENEMY,
        [LabelText("中立")]
        NEUTRAL,
    }

    public interface IDamage
    {
        /// <summary>
        /// 伤害类型
        /// </summary>
        DamageStyle DamageStyle { get; set; }
        /// <summary>
        /// 普通伤害
        /// </summary>
        int AttackDamage { get; set; }
        /// <summary>
        /// 暴击伤害
        /// </summary>
        int CriticalDamage { get; set; }
        /// <summary>
        /// 附加伤害
        /// </summary>
        int AttachDamage { get; set; }
    }
}
