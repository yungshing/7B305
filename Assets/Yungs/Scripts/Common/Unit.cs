using UnityEngine;
using System.Collections;
using Yungs.D305;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Unit : YungsMono, IStyle
{
    public bool isPlayer = false;
    [SerializeField, LabelText("单位名字")]
    private string unitName;
    public string UnitName
    {
        get
        {
            return unitName;
        }
    }
    [SerializeField, LabelText("攻击类型")]
    private DamageStyle attackStyle;
    public DamageStyle AttackStyle
    {
        get { return attackStyle; }
        set { attackStyle = value; }
    }
    [SerializeField, LabelText("单位态度")]
    private Manner manner;
    public Manner Manner
    {
        get { return manner; }
        set { manner = value; }
    }
    [LabelText("自动攻击")]
    public bool autoAttack = false;
    [SerializeField, LabelText("无敌的")]
    private bool isInvincible = false;
    [LabelText("感应距离")]
    public float attackDistance = 3f;
    [LabelText("等级设定")]
    public Experience exp;
    public bool IsInvincible { get { return isInvincible; } set { isInvincible = value; } }
    [LabelText("属性")]
    public UnitProperty unitProperty;

    private List<TaskItem> taskItems;

    [HideInInspector]
    public Animator ani;
    private void Start()
    {
        unitProperty.Level = exp.CurrLevel;
        unitProperty.UpdateValue();
        if (isPlayer)
        {
            GlobalEvent.hpChangeEvent(unitProperty.hp.CurrValue, unitProperty.hp.MaxValue);
            GlobalEvent.mpChangeEvent(unitProperty.mp.CurrValue, unitProperty.mp.MaxValue);
            GlobalEvent.expChangeEvent(exp.CurrExp, exp.NextLevelNeedExp(), exp.CurrLevel);
            GlobalEvent.rolePropertyChangeEvent(this);
        }
        ani = GetComponent<Animator>();
        GlobalEvent.playDeadAniEvent = () => ani.Play("Death");
    }

    public void DeadAni(float f)
    {
        if (isPlayer)
        {
            YungsUT.Instance.StartCoroutine(DelayHide(f));
        }
        else
        {
            YungsUT.Instance.StartCoroutine(DelayHide(0.1f));
        }
    }

    IEnumerator DelayHide(float f)
    {
        yield return new WaitForSeconds(f);

        gameObject.SetActive(false);
    }
    /// <summary>
    /// 被攻击
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="unit">攻击者</param>
    /// <returns></returns>
    public IDamage BeAttack(IDamage damage, Unit unit)
    {
        if (unitProperty.hp.CurrValue <= 0)
        {
            return null;
        }
        int a = 0;
        int b = 0;
        int c = 0;
        if (!IsInvincible)
        {
            if (damage.DamageStyle == DamageStyle.PHYSICS)
            {
                a = (int)((damage.AttackDamage - this.unitProperty.defensive.CurrValue - this.unitProperty.ignoreDamage.ExtraValue) * (1 - this.unitProperty.ignoreDamage.ExtraPercent));
                b = (int)((damage.CriticalDamage - this.unitProperty.defensive.CurrValue - this.unitProperty.ignoreDamage.ExtraValue) * (1 - this.unitProperty.ignoreDamage.ExtraPercent));
            }
            else if (damage.DamageStyle == DamageStyle.MAGIC)
            {
                a = (int)((damage.AttackDamage - this.unitProperty.magicDefensive.CurrValue - this.unitProperty.ignoreDamage.ExtraValue) * (1 - this.unitProperty.ignoreDamage.ExtraPercent));
                b = (int)((damage.CriticalDamage - this.unitProperty.magicDefensive.CurrValue - this.unitProperty.ignoreDamage.ExtraValue) * (1 - this.unitProperty.ignoreDamage.ExtraPercent));
            }
            b = Mathf.Max(0, b);
            c = damage.AttachDamage;
            this.unitProperty.hp.CurrValue -= a + b + c;
        }
        var id = new DamageValue()
        {
            DamageStyle = damage.DamageStyle,
            AttackDamage = a,
            AttachDamage = c,
            CriticalDamage = b,
        };
        if (unitProperty.hp.CurrValue <= 0)
        {
            ani.Play("Death");
            unitProperty.hp.CurrValue = 0;
        }
        GlobalEvent.showDamageFontEvent(id, transform.position);
        if (isPlayer)
        {
            GlobalEvent.hpChangeEvent(this.unitProperty.hp.CurrValue, this.unitProperty.hp.MaxValue);
        }
        return id;
    }
}
