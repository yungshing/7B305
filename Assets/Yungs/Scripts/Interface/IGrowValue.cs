using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
namespace Yungs.D305
{
    public interface IGrowValue
    {
        /// <summary>
        /// 初始值
        /// </summary>
        float Original { get; set; }
        /// <summary>
        /// 增长因子
        /// </summary>
        float Factor { get; set; }
    }
    [System.Serializable]
    public class ItemValue : IGrowValue
    {
        [HorizontalGroup, SerializeField, LabelText("初始值"), LabelWidth(50)]
        private float original = 0;
        /// <summary>
        /// 初始值
        /// </summary>
        public float Original
        {
            get { return original; }
            set { original = value; }
        }
        [HorizontalGroup, SerializeField, LabelText("成长因子"), LabelWidth(50)]
        private float factor = 0;
        /// <summary>
        /// 成长因子
        /// </summary>
        public float Factor
        {
            get { return factor; }
            set { factor = value; }
        }
        private float maxValue = 0;
        /// <summary>
        /// 上限值
        /// </summary>
        public float MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
            }
        }

        private float currValue = 0;
        /// <summary>
        /// 当前值
        /// </summary>
        public float CurrValue
        {
            get
            {
                return currValue;
            }
            set
            {
                currValue = value;
            }
        }

        private float extraPercent = 0;
        /// <summary>
        /// 额外增加数值（按百分比）
        /// </summary>
        public float ExtraPercent
        {
            get
            {
                return extraPercent * 0.01f;
            }
            set
            {
                extraPercent = value;
            }
        }
        private float extraValue = 0;
        /// <summary>
        /// 额外增加数值
        /// </summary>
        public float ExtraValue
        {
            get
            {
                return extraValue;
            }
            set
            {
                extraValue = value;
            }
        }
        /// <summary>
        /// 自身的数值，不包括额外获得的值
        /// </summary>
        public float SelfValue { get; set; }
        public virtual void UpdateValue(int level)
        {
            SelfValue = Original * Mathf.Pow(Factor, level - 1);
            CurrValue = MaxValue = (SelfValue + ExtraValue) * (1 + ExtraPercent);
        }

        public virtual void UpdateValue(int level,System.Func<float> func)
        {
            UpdateValue(level);
            MaxValue = CurrValue += func();
        }
    }
}