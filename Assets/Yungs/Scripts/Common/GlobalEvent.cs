using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Yungs.D305
{
    public class GlobalEvent
    {
        /// <summary>
        /// 显示伤害文字
        /// </summary>
        public static Action<IDamage, Vector3> showDamageFontEvent;
        /// <summary>
        /// 释放技能后，进入CD
        /// string:技能名字： Q W E　R
        /// float : cd
        /// </summary>
        public static Action<string, float> skillEnterCDEvent;

        /// <summary>
        /// 技能升级
        /// string:技能名字： Q W E　R
        /// int:等级(升级后的等级)
        /// </summary>
        public static Action<string, int> skillUpgradesEvent;

        /// <summary>
        /// 血量发生改变
        /// </summary>
        public static Action<float, float> hpChangeEvent;
        /// <summary>
        /// 蓝量发生变化
        /// </summary>
        public static Action<float, float> mpChangeEvent;
        /// <summary>
        /// 经验值发生变化
        /// 当前值   最大值  等级
        /// </summary>
        public static Action<float, float,int> expChangeEvent;
        /// <summary>
        /// 角色属性发生变化 
        /// </summary>
        public static Action<Unit> rolePropertyChangeEvent;

        /// <summary>
        /// 释放技能或者平A时调用 。
        /// 主要是 角色抬手动作做到指定位置时，技能效果在出去看起来比较协调
        /// </summary>
        public static Action playSkillEvent;
        /// <summary>
        /// 释放技能或者平A 前摇动作结束
        /// </summary>
        public static Action playSkillOverEvent;
        /// <summary>
        /// 挂了
        /// </summary>
        public static Action playDeadAniEvent;
    }
}
