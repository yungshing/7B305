using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using DG.Tweening;
public class SkillEffectMove : MonoBehaviour
{

    [ShowInInspector, LabelText("技能移动速度（M/S）")]
    public float Speed { get; set; }
    [ShowInInspector, LabelText("技能距离")]
    public float Distance { get; set; }
    /// <summary>
    /// 技能沿着des方向移动
    /// </summary>
    /// <param name="des"></param>
    public void Play(Vector3 des)
    {
        var dir = (transform.position - des).normalized * Distance;
        transform.DOMove(dir, Distance / Speed).SetEase(Ease.Linear);
    }
    /// <summary>
    /// 技能跟随着tr移动，直到碰到tr
    /// </summary>
    /// <param name="tr"></param>
    public void Play(Transform tr)
    {
        StartCoroutine(MoveByTarget(tr));
    }

    IEnumerator MoveByTarget(Transform tar)
    {
        while(transform .gameObject .activeSelf)
        {
            transform.Translate(tar.position * Time.deltaTime * Speed);
            yield return null;
        }
    }
}