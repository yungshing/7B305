using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
namespace Yungs.D305
{
    [System.Serializable]
    public class Experience
    {
        /// <summary>
        /// 升到level等级所需要经验
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static int LevelNeedExp(int level)
        {
            return (level - 1) * (level - 1) * (level - 1);
        }
        /// <summary>
        /// 根据等级计算单位经验
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static int CalUnitExp(int level)
        {
            return (int)(0.025f * level * level + level);
        }
        /// <summary>
        /// 当前等级
        /// </summary>
        [SerializeField, HorizontalGroup("Experience"), LabelText("当前等级"), MinValue(1), LabelWidth(50)]
        private int currLevel;
        public int CurrLevel
        {
            get
            {
                return currLevel;
            }
            set
            {
                currLevel = value;
            }
        }
        /// <summary>
        /// 当前经验
        /// </summary>
        [SerializeField, HorizontalGroup("Experience"), LabelText("当前经验"), MinValue(0), LabelWidth(50)]
        private int currExp;
        public int CurrExp
        {
            get
            {
                return currExp;
            }
            set
            {
                currExp = value;
            }
        }

        /// <summary>
        /// 升到下一级所需要经验
        /// </summary>
        /// <param name="nextLevel">下一等级</param>
        /// <returns></returns>
        public int NextLevelNeedExp()
        {
            return LevelNeedExp(CurrLevel - 1);
        }
        /// <summary>
        /// 被击杀后，价值多少经验
        /// </summary>
        /// <param name="currLevel">被击杀者当前等级</param>
        /// <returns></returns>
        public int SelfExp()
        {
            return CalUnitExp(CurrLevel);
        }

        /// <summary>
        /// 获得经验
        /// </summary>
        /// <param name="exp"></param>
        /// <returns>当前等级</returns>
        public int AddExp(int exp)
        {
            if (CurrExp < 0)
            {
                CurrExp = 0;
            }
            if ((CurrExp += exp) < NextLevelNeedExp())
            {
                return CurrLevel;
            }
            else
            {
                CurrExp -= NextLevelNeedExp();
                CurrLevel++;
                return AddExp(0);
            }
        }

        public int AddExp(float per)
        {
            var exp = (int)(NextLevelNeedExp() * per);
            return AddExp(exp);
        }
    }
}