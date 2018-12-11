using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yungs.D305
{
    public class PropertyConstParam
    {
        /// <summary>
        /// 1点护甲 = 50 物理防御
        /// </summary>
        public const float ShieldToDefen = 50;
        /// <summary>
        /// 1 魔抗 = 56 物防
        /// </summary>
        public const float SpellResToMDefen = 56;
        /// <summary>
        /// 1 体力 = 90 HP
        /// </summary>
        public const float EnargyToHP = 90;
        /// <summary>
        /// 1 体力 = 0.1 HP回复
        /// </summary>
        public const float EnartyToHPRec = 0.1f;
        /// <summary>
        /// 1 精神 = 1.5 MP
        /// </summary>
        public const float SpiritToMP = 1.5f;
        /// <summary>
        /// 1精神 = 0.001 MP 回复
        /// </summary>
        public const float SpiritToMPRec = 0.001f;
        /// <summary>
        /// 默认为100秒回满HP
        /// </summary>
        public const float LimitHPRecSec = 100;
        /// <summary>
        /// 默认为60秒回满MP
        /// </summary>
        public const float LimitMPRecSec = 60;

        /// <summary>
        /// 1点物理攻击力 = 10点伤害
        /// </summary>
        public const float AttackToDemage = 10;
        /// <summary>
        /// 1 点魔法攻击力=9.8魔法伤害
        /// </summary>
        public const float MagicToDemage = 9.8f;
        /// <summary>
        /// 1力量 = 10物理攻击力
        /// </summary>
        public const float StrengthToAttack = 10;
        /// <summary>
        /// 1智力 = 11点物理攻击力
        /// </summary>
        public const float IntelligenceToAttack = 11;
    }
}
