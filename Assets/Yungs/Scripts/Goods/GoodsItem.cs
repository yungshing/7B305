using UnityEngine;
using System.Collections;
using Yungs.D305;
using Sirenix.OdinInspector;
public class GoodsItem : YungsMono
{
    [SerializeField,LabelText("物品名字")]
    private string goodsName;
    /// <summary>
    /// 物品名字
    /// </summary>
    public string GoodsName
    {
        get
        {
            return goodsName;
        }
        set
        {
            goodsName = value;
        }
    }
    /// <summary>
    /// 描述
    /// </summary>
    [ShowInInspector]
    [MultiLineProperty(3),LabelText("描述")]
    public string description;
    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
        }
    }

    [LabelText("属性")]
    public GoodsProperty goods;
    
    /// <summary>
    /// 装备后，产生的效果
    /// </summary>
    /// <param name="unit"></param>
    public void Equip(Unit unit)
    {
        goods.Equip(unit.unitProperty);
    }
    /// <summary>
    /// 卸下装备 
    /// </summary>
    /// <param name="unit"></param>
    public void Unwield(Unit unit)
    {
        goods.Unwield(unit.unitProperty);
    }

    /// <summary>
    /// 使用后。
    /// </summary>
    /// <param name="unit"></param>
    public void Use(Unit unit)
    {
        goods.Equip(unit.unitProperty);
    }
}
