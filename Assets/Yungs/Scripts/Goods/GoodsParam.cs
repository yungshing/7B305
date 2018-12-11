using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Yungs.D305
{
    [Serializable]
    public class GoodsParam
    {
        /// 属性列表
        /// </summary>
        [HorizontalGroup("Split"), HideLabel]
        public GoodsParamList paramList;
        [ShowInInspector, HorizontalGroup("Split"), HideLabel]
        private ValueType valueType;
        [ShowInInspector, HorizontalGroup("Split"), HideLabel, ShowIf("valueType", ValueType.Fixed), DisableIf("paramList", GoodsParamList.Critical), MinValue(0)]
        [DisableIf("paramList", GoodsParamList.DeBuff)]
        private float fixedValue;
        [ShowInInspector, HorizontalGroup("Split"), HideLabel, ShowIf("valueType", ValueType.Percent)]
        private float percentValue;
        public float ParamValue
        {
            get
            {
                if (valueType == ValueType.Fixed)
                {
                    return fixedValue;
                }
                return percentValue;
            }
        }
        public enum GoodsParamList
        {
            Null = 0,
            /// <summary>
            /// 物理攻击力
            /// </summary>
            [LabelText("物理攻击力")]
            Attack,
            /// <summary>
            /// 魔法攻击力
            /// </summary>
            [LabelText("魔法攻击力")]
            MagicAttack,
            [LabelText("附加伤害")]
            AttachDemage,
            /// <summary>
            /// 力量 
            /// </summary>
            [LabelText("力量")]
            Strength,
            /// <summary>
            /// 智力
            /// </summary>
            [LabelText("智力")]
            Intelligence,
            /// <summary>
            /// 体力
            /// </summary>
            [LabelText("体力")]
            Enargy,
            /// <summary>
            /// 精神
            /// </summary>
            [LabelText("精神")]
            Spirit,
            /// <summary>
            /// 物理防御
            /// </summary>
            [LabelText("物理防御")]
            Defensive,
            /// <summary>
            /// 魔法防御
            /// </summary>
            [LabelText("魔法防御")]
            MagicDefensive,
            [LabelText("无视伤害")]
            IgnoreDamage,
            /// <summary>
            /// 暴击机率
            /// </summary>
            [LabelText("暴击机率")]
            Critical,
            /// <summary>
            /// 暴击伤害
            /// </summary>
            [LabelText("暴击伤害")]
            CriticalDemage,
            /// <summary>
            /// 攻击速度
            /// </summary>
            [LabelText("攻击速度")]
            AttackSpeed,
            /// <summary>
            /// 释放速度
            /// </summary>
            [LabelText("释放速度")]
            MagicSpeed,
            /// <summary>
            /// 移动速度 
            /// </summary>
            [LabelText("移动速度")]
            MoveSpeed,
            /// <summary>
            /// 抗性
            /// </summary>
            [LabelText("抗性")]
            DeBuff,
            /// <summary>
            /// 增加血量
            /// </summary>
            [LabelText("增加血量")]
            HP,
            /// <summary>
            /// 增加蓝量
            /// </summary>
            [LabelText("增加蓝量")]
            MP,
            /// <summary>
            /// 增加血量上限
            /// </summary>
            [LabelText("增加血量上限")]
            HPMax,
            /// <summary>
            /// 增加蓝量上限
            /// </summary>
            [LabelText("增加蓝量上限")]
            MPMax,
            /// <summary>
            /// 增加经验
            /// </summary>
            [LabelText("增加经验")]
            Exp
        }
        public enum ValueType
        {
            [LabelText("固定值")]
            Fixed,
            [LabelText("百分比")]
            Percent
        }

#if UNITY_EDITOR
        [ShowInInspector,HorizontalGroup("Split"), HideLabel, ShowIf("valueType", ValueType.Percent)]
        string _per = "%";
#endif
    }
}
