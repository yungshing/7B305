using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
namespace Yungs.D305
{
    public class SkillStateUI : MonoBehaviour
    {
        public Image image;
        public Text cdTxt;
        public Text levelTxt;
        float tmp = 0;
        /// <summary>
        /// 释放技能后，进入CD状态
        /// </summary>
        /// <param name="cd"></param>
        public void EnterCD(float cd)
        {
            image.fillAmount = 0;
            tmp = 0;
            image.DOFillAmount(1, cd - 0.3f).OnUpdate(() => TweenUpdate(cd)).OnComplete(() =>
                {
                    cdTxt.text = "";
                    image.DOColor(new Color(0.36f, 0.36f, 0.36f, 1), 0.25f).OnComplete(() =>
                    {
                        image.DOColor(new Color(1, 1, 1, 1), 0.3f);
                    });
                });
        }
        /// <summary>
        /// 还没有学此技能
        /// </summary>
        public void NotLearn()
        {
            image.fillAmount = 0;
            levelTxt.text = "0";
            cdTxt.text = "";
        }
        void TweenUpdate(float cd)
        {
            cdTxt.text = (cd - (tmp += Time.deltaTime)).ToString("0");
        }
        /// <summary>
        /// 升级
        /// </summary>
        /// <param name="level"></param>
        public void Upgrades(int level)
        {
            levelTxt.text = level.ToString();
            if (level <= 0)
            {
                NotLearn();
            }
        }
    }
}