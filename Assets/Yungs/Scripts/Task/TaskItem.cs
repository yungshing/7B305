using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using Yungs.D305;
using System.Collections.Generic;

public class TaskItem : YungsMono
{
    [SerializeField,LabelText("任务名字")]
    private string taskName;
    public string TaskName
    {
        get
        {
            return taskName;
        }
        set
        {
            taskName = value;
        }
    }
    [InfoBox("每一条为一段对话，玩家点击鼠标后，切换下一条")]
    [ShowInInspector, LabelText("对话")]
    private string[] contents = new string[0];
    public string[] Contents
    {
        get
        {
            return contents;
        }
        set
        {
            contents = value;
        }
    }
    [SerializeField, LabelText("任务需求")]
    private RequireItem require;
    public RequireItem Require {
        get
        {
            return require;
        }
    }
    [SerializeField, LabelText("任务奖励")]
    private RewardsItem rewards = new RewardsItem();
    public RewardsItem Rewards
    {
        get
        {
            return rewards;
        }
    }

    /// <summary>
    /// 获取材料
    /// </summary>
    private Dictionary<string, int> acquire;

    private void Start()
    {
        acquire = new Dictionary<string, int>();
        for (int i = 0; i < Require.requireGoods.Length; i++)
        {
            acquire.Add(Require.requireGoods[i].goodsItem.ID,0);
        }
        for (int i = 0; i < Require.requireUnits.Length; i++)
        {
            acquire.Add(Require.requireUnits[i].unit.ID,0);
        }
        for (int i = 0; i < Require.requireFindUnits.Length; i++)
        {
            acquire.Add(Require.requireFindUnits[i].unit.ID, 0);
        }
    }
    /// <summary>
    /// 获取任务道具
    /// </summary>
    /// <param name="goodsItem"></param>
    /// <returns></returns>
    public YungsResult Acquire(GoodsItem goodsItem)
    {
        var log = new YungsResult();
        if (acquire.ContainsKey(goodsItem.ID))
        {
            acquire[goodsItem.ID]++;
            log = new YungsResult(0, goodsItem.GoodsName + ":" + acquire[goodsItem.ID]);
        }
        else
        {
            log = new YungsResult(1,"不是任务需要材料");
        }
        return log;
    }

    /// <summary>
    /// 寻找任务NPC
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    public YungsResult Acquire(Unit unit)
    {
        var log = new YungsResult();
        if (acquire.ContainsKey(unit.ID))
        {
            acquire[unit.ID]++;
            log = new YungsResult(0, unit.UnitName + ":" + acquire[unit.ID]);
        }
        else
        {
            log = new YungsResult(1, "不是任务所找对象");
        }
        return log;
    }

    /// <summary>
    /// 清理任务所获取的道具数量
    /// 全部归零
    /// </summary>
    public void ClearTaskData()
    {
        foreach (var item in acquire)
        {
            acquire[item.Key] = 0;
        }
    }

    /// <summary>
    /// 判断完成任务
    /// </summary>
    /// <param name="goodsItems">获取材料</param>
    /// <param name="units">击杀单位</param>
    /// <param name="npcs">寻找单位</param>
    /// <returns></returns>
    public bool Finished()
    {
        var f = true;
        for (int i = 0; i < Require.requireGoods.Length; i++)
        {
            f &= acquire[Require.requireGoods[i].goodsItem.ID] >= Require.requireGoods[i].count;
        }
        for (int i = 0; i < Require.requireUnits.Length; i++)
        {
            f &= acquire[Require.requireUnits[i].unit.ID] >= Require.requireUnits[i].count;
        }
        for (int i = 0; i < Require.requireFindUnits.Length; i++)
        {
            f &= acquire[Require.requireFindUnits[i].unit.ID] >= Require.requireFindUnits[i].count;
        }
        return f;
    }
    [System.Serializable]
    public class RequireItem
    {
        [LabelText("获取材料")]
        public RequireGoods[] requireGoods;
        [LabelText("击杀单位")]
        public RequireUnit[] requireUnits;
        [LabelText("寻找单位")]
        public RequireFindUnit[] requireFindUnits;

        [System.Serializable]
        public class RequireGoods
        {
            [HorizontalGroup("RequireGoods"), LabelText("材料"), LabelWidth(30)]
            public GoodsItem goodsItem;
            [HorizontalGroup("RequireGoods"), LabelText("数量"), LabelWidth(30)]
            public int count;
        }
        [System.Serializable]
        public class RequireUnit
        {
            [HorizontalGroup("RequireUnit"), LabelText("单位"), LabelWidth(30)]
            public Unit unit;
            [HorizontalGroup("RequireUnit"), LabelText("数量"), LabelWidth(30)]
            public int count;
        }
        [System.Serializable]
        public class RequireFindUnit
        {
            [LabelText("单位"), LabelWidth(30)]
            public Unit unit;
            [LabelText("数量"), LabelWidth(30)]
            public int count = 1;
        }
    }

    [System.Serializable]
    public class RewardsItem
    {
        [LabelText("金币"),MinValue(0)]
        public int money;
        [LabelText("经验")]
        public Rewards_Exp rewards_Exp;
        [LabelText("物品奖励")]
        public Rewards_Goods[] rewards_Goods;
        [LabelText("属性奖励")]
        public Rewards_UnitProperty rewards_UnitProperty;
        [System.Serializable]
        public class Rewards_Goods
        {
            [HorizontalGroup("Rewards_Goods"), LabelText("物品"), LabelWidth(30)]
            public GoodsItem goodsItem;
            [HorizontalGroup("Rewards_Goods"), LabelText("数量"), LabelWidth(30)]
            public int count;
        }
        [System.Serializable]
        public class Rewards_UnitProperty
        {
            [HorizontalGroup("Rewards_UnitProperty"), LabelText("力量"), LabelWidth(30),MinValue(0)]
            public int strength;
            [HorizontalGroup("Rewards_UnitProperty"), LabelText("智力"), LabelWidth(30), MinValue(0)]
            public int intelligence;
            [HorizontalGroup("Rewards_UnitProperty2"), LabelText("体力"), LabelWidth(30), MinValue(0)]
            public int enargy;
            [HorizontalGroup("Rewards_UnitProperty2"), LabelText("精神"), LabelWidth(30), MinValue(0)]
            public int spirit;
        }
        [System.Serializable]
        public class Rewards_Exp
        {
            [ShowInInspector,HorizontalGroup("Rewards_Exp"),HideLabel]
            private GoodsParam.ValueType valueType;
            [ShowInInspector, HorizontalGroup("Rewards_Exp"), MinValue(0), HideLabel,ShowIf("valueType", GoodsParam.ValueType.Fixed)]
            private int fixedValue;
            [ShowInInspector, HorizontalGroup("Rewards_Exp"), ShowIf("valueType", GoodsParam.ValueType.Percent), LabelText("等级"),LabelWidth(30),MinValue(1)]
            private int level;
            [ShowInInspector, HorizontalGroup("Rewards_Exp"), ShowIf("valueType", GoodsParam.ValueType.Percent), LabelText("百分比"),LabelWidth(40),Range(0,1)]
            private float percentValue;
            public int Value
            {
                get
                {
                    if (valueType == GoodsParam.ValueType.Fixed)
                    {
                        return fixedValue;
                    }
                    else
                    {
                        return (int)(Experience.LevelNeedExp(level) * percentValue);
                    }
                }
            }
        }
    }
}
