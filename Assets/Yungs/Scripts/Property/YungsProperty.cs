
using System;
using UnityEngine;

namespace Yungs.D305
{
    /// <summary>
    /// 物理攻击力
    /// </summary>
    [System.Serializable]
    public class Attack : ItemValue
    {
        public override void UpdateValue(int level, Func<float> func)
        {
            SelfValue = func();
            CurrValue = MaxValue = (SelfValue + ExtraValue) * (1 + ExtraPercent);
        }
    }
    /// <summary>
    /// 魔法攻击力
    /// </summary>
    [System.Serializable]
    public class MagicAttack : ItemValue
    {
        public override void UpdateValue(int level, Func<float> func)
        {
            SelfValue = func();
            CurrValue = MaxValue = (SelfValue + ExtraValue) * (1 + ExtraPercent);
        }
    }
    /// <summary>
    /// 附加伤害
    /// </summary>
    [System.Serializable]
    public class AttachAttack : ItemValue
    {
        public override void UpdateValue(int level)
        {
            SelfValue = Original * Mathf.Pow(1 + Factor, level - 1);
            CurrValue = MaxValue = (SelfValue + ExtraValue) * (1 + ExtraPercent) * 0.01f;
        }
    }
    /// <summary>
    /// 力量
    /// </summary>
    [System.Serializable]
    public class Strength : ItemValue
    {

    }
    /// <summary>
    /// 智力
    /// </summary>
    [System.Serializable]
    public class Intelligence : ItemValue
    {

    }
    /// <summary>
    /// 体力
    /// </summary>
    [System.Serializable]
    public class Enargy : ItemValue
    {

    }
    /// <summary>
    /// 精神
    /// </summary>
    [System.Serializable]
    public class Spirit : ItemValue
    {

    }
    /// <summary>
    /// 护甲
    /// </summary>
    [System.Serializable]
    public class Shield : ItemValue
    {

    }
    /// <summary>
    /// 魔抗
    /// </summary>
    [System.Serializable]
    public class SpellResistance : ItemValue
    {

    }
    /// <summary>
    /// 物防
    /// </summary>
    [System.Serializable]
    public class Defensive : ItemValue
    {

    }
    /// <summary>
    /// 魔防
    /// </summary>
    [System.Serializable]
    public class MagicDefensive : ItemValue
    {

    }
    /// <summary>
    /// 无视伤害
    /// </summary>
    [System.Serializable]
    public class IgnoreDamage : ItemValue
    {
        public override void UpdateValue(int level)
        {
            base.UpdateValue(level);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }

        public override void UpdateValue(int level, Func<float> func)
        {
            base.UpdateValue(level, func);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }
    }
    /// <summary>
    /// 暴击机率
    /// </summary>
    [System.Serializable]
    public class Critical : ItemValue
    {
        
    }
    /// <summary>
    /// 暴击伤害增加量
    /// </summary>
    [System.Serializable]
    public class CriticalDemage : ItemValue
    {
        public override void UpdateValue(int level)
        {
            base.UpdateValue(level);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }

        public override void UpdateValue(int level, Func<float> func)
        {
            base.UpdateValue(level, func);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }
    }
    /// <summary>
    /// 攻击速度
    /// </summary>
    [System.Serializable]
    public class AttackSpeed : ItemValue
    {
        public override void UpdateValue(int level)
        {
            base.UpdateValue(level);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }

        public override void UpdateValue(int level, Func<float> func)
        {
            base.UpdateValue(level, func);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }
    }
    /// <summary>
    /// 释放速度
    /// </summary>
    [System.Serializable]
    public class MagicSpeed : ItemValue
    {
        public override void UpdateValue(int level)
        {
            base.UpdateValue(level);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }

        public override void UpdateValue(int level, Func<float> func)
        {
            base.UpdateValue(level, func);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }
    }
    /// <summary>
    /// 移动速度
    /// </summary>
    [System.Serializable]
    public class MoveSpeed : ItemValue
    {
        public override void UpdateValue(int level)
        {
            base.UpdateValue(level);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }

        public override void UpdateValue(int level, Func<float> func)
        {
            base.UpdateValue(level, func);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }
    }
    /// <summary>
    /// 抗性
    /// </summary>
    [System.Serializable]
    public class DeBuff : ItemValue
    {
        public override void UpdateValue(int level)
        {
            base.UpdateValue(level);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }

        public override void UpdateValue(int level, Func<float> func)
        {
            base.UpdateValue(level, func);
            MaxValue *= 0.01f;
            CurrValue *= 0.01f;
        }
    }
    /// <summary>
    /// 血量
    /// </summary>
    [System.Serializable]
    public class HP : ItemValue
    {
        /// <summary>
        /// 恢复每秒
        /// </summary>
        public float Recovery { get; set; }
    }
    /// <summary>
    /// 蓝量
    /// </summary>
    [System.Serializable]
    public class MP : ItemValue
    {
        /// <summary>
        /// 恢复每秒
        /// </summary>
        public float Recovery { get; set; }
    }
}
