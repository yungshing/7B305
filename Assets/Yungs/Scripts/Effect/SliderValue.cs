using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Yungs.D305
{
    public class SliderValue : MonoBehaviour
    {
        public Slider slider;
        public Text text;
        /// <summary>
        /// 设置slider的值和文字
        /// eg: hp mp --->  123/324
        /// exp ---->  等级:1
        /// </summary>
        /// <param name="curr"></param>
        /// <param name="max"></param>
        /// <param name="txt"></param>
        public void SetValue(float curr,float max,string txt)
        {
            slider.value = curr / max;
            text.text = txt;
        }
    }
}