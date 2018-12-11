using Sirenix.OdinInspector;
using UnityEngine;

namespace Yungs.D305
{
    /// <summary>
    /// 物品
    /// </summary>
    [System.Serializable]
    public class GoodsProperty
    {
        public GoodsParam[] goodsParams;
        /// <summary>
        /// 角色带此物品后有什么效果
        /// </summary>
        /// <param name="unit">带此物品的角色</param>
        protected virtual void Efficacy(UnitProperty unit,bool isEquip)
        {
            float per, flo = 0;
            for (int i = 0; i < goodsParams.Length; i++)
            {
                if (goodsParams[i].ParamValue <= 1)
                {
                    per = goodsParams[i].ParamValue;
                    flo = 0;
                }
                else
                {
                    flo = goodsParams[i].ParamValue;
                    per = 0;
                }
                if (!isEquip)
                {
                    per = per * -1;
                    flo = flo * -1;
                }
                switch (goodsParams[i].paramList)
                {
                    case GoodsParam.GoodsParamList.Null:
                        break;
                    case GoodsParam.GoodsParamList.Attack:
                        unit.attack.ExtraValue += flo;
                        unit.attack.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.MagicAttack:
                        unit.magicAttack.ExtraValue += flo;
                        unit.magicAttack.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.AttachDemage:
                        unit.attachAttack.ExtraValue += flo;
                        unit.attachAttack.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.Strength:
                        unit.strength.ExtraValue += flo;
                        unit.strength.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.Intelligence:
                        unit.intelligence.ExtraValue += flo;
                        unit.intelligence.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.Spirit:
                        unit.spirit.ExtraValue += flo;
                        unit.spirit.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.Enargy:
                        unit.enargy.ExtraValue += flo;
                        unit.enargy.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.Defensive:
                        unit.defensive.ExtraValue += flo;
                        unit.defensive.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.MagicDefensive:
                        unit.magicDefensive.ExtraValue += flo;
                        unit.magicDefensive.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.IgnoreDamage:
                        unit.ignoreDamage.ExtraValue += flo;
                        unit.ignoreDamage.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.Critical:
                        unit.critical.ExtraValue += flo;
                        unit.critical.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.CriticalDemage:
                        unit.criticalDemage.ExtraValue += flo;
                        unit.criticalDemage.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.AttackSpeed:
                        unit.attackSpeed.ExtraValue += flo;
                        unit.attackSpeed.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.MagicSpeed:
                        unit.magicSpeed.ExtraValue += flo;
                        unit.magicSpeed.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.MoveSpeed:
                        unit.magicSpeed.ExtraValue += flo;
                        unit.magicSpeed.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.DeBuff:
                        unit.deBuff.ExtraValue += flo;
                        unit.deBuff.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.HP:
                        unit.hp.ExtraValue += flo;
                        unit.hp.ExtraPercent += per;
                        break;
                    case GoodsParam.GoodsParamList.MP:
                        unit.mp.ExtraValue += flo;
                        unit.mp.ExtraPercent += per;
                        break;
                }
            }
        }

        public void Equip(UnitProperty unit)
        {
            Efficacy(unit, true);
        }

        public void Unwield(UnitProperty unit)
        {
            Efficacy(unit,false);
        }
    }
}
