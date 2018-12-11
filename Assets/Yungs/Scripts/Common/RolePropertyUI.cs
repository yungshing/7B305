using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Yungs.D305
{
    public class RolePropertyUI : MonoBehaviour
    {
        public Text nameTxt;
        public Text attackTxt;
        public Text magicAttackTxt;
        public Text strengthTxt;
        public Text intelligenceTxt;
        public Text shieldTxt;
        public Text spellResistanceTxt;
         

        public void SetValue(Unit unit)
        {
            nameTxt.text = unit.UnitName;
            var t = (int)(unit.unitProperty.attack.CurrValue - unit.unitProperty.attack.SelfValue);
            attackTxt.text = ColorTxt("物攻: ", Color.yellow) + ColorTxt(((int)unit.unitProperty.attack.SelfValue).ToString(), Color.white) + "+" + ColorTxt(t.ToString(), Color.red);

            t = (int)(unit.unitProperty.magicAttack.CurrValue - unit.unitProperty.magicAttack.SelfValue);
            magicAttackTxt.text = ColorTxt("魔攻: ", Color.yellow) + ColorTxt(((int)unit.unitProperty.magicAttack.SelfValue).ToString(), Color.white) + "+" + ColorTxt(t.ToString(), Color.red);

            t = (int)(unit.unitProperty.strength.CurrValue - unit.unitProperty.strength.SelfValue);
            strengthTxt.text = ColorTxt("力量: ", Color.yellow) + ColorTxt(((int)unit.unitProperty.strength.SelfValue).ToString(), Color.white) + "+" + ColorTxt(t.ToString(), Color.red);

            t = (int)(unit.unitProperty.intelligence.CurrValue - unit.unitProperty.intelligence.SelfValue);
            intelligenceTxt.text = ColorTxt("智力: ", Color.yellow) + ColorTxt(((int)unit.unitProperty.intelligence.SelfValue).ToString(), Color.white) + "+" + ColorTxt(t.ToString(), Color.red);

            t = (int)(unit.unitProperty.shield.CurrValue - unit.unitProperty.shield.SelfValue);
            shieldTxt.text = ColorTxt("护甲: ", Color.yellow) + ColorTxt(((int)unit.unitProperty.shield.SelfValue).ToString(), Color.white) + "+" + ColorTxt(t.ToString(), Color.red);

            t = (int)(unit.unitProperty.spellResistance.CurrValue - unit.unitProperty.spellResistance.SelfValue);
            spellResistanceTxt.text = ColorTxt("魔抗: ", Color.yellow) + ColorTxt(((int)unit.unitProperty.spellResistance.SelfValue).ToString(), Color.white) + "+" + ColorTxt(t.ToString(), Color.red);

        }

        string ColorTxt(string txt,Color c)
        {
            var cStr = ColorUtility.ToHtmlStringRGB(c);
            return string.Format("<color=#{0}>{1}</color>", cStr, txt);
        }
    }
}