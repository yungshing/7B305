using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

namespace Yungs.D305
{
    public class SkillMono : YungsMono
    {
        [SerializeField, LabelText("技能CD")]
        private float cd;
        public float CD
        {
            get
            {
                return cd;
            }
            set
            {
                cd = value;
            }
        }
        [LabelText("技能拥有者")]
        public Unit selfUnit;
        private SkillItem[] skillProperties;

        [LabelText("是否为指向性技能")]
        public bool isDirectivity = false;
        [SerializeField, LabelText("技能距离"), InfoBox("若技能不需要像坨子那样飞，直接出现在角色周围，把距离设为小于0的数")]
        private float distance;
        public float Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
            }
        }
        [SerializeField, LabelText("技能移动速度（M/S）")]
        private float speed;
        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        [LabelText("出现的起始位置")]
        public Transform startPosTr;
        [LabelText("蓝量消耗")]
        public ItemValue mpSpend;
        [SerializeField,LabelText("技能等级")]
        private int level;
        float cd_tmp = 0;
        /// <summary>
        /// 攻击的目标，
        /// 指向性时用到
        /// 不然技能在飞行过程中，碰到其他怪，也会掉血
        /// </summary>
        [HideInInspector]
        public Transform attackTarget;
        private void Start()
        {
            skillProperties = GetComponents<SkillItem>();
            for (int i = 0; i < skillProperties.Length; i++)
            {
                skillProperties[i].Level = Level;
                skillProperties[i].selfUnit = selfUnit;
            }
            if (selfUnit.isPlayer)
            {
                GlobalEvent.skillUpgradesEvent(transform.name, Level);
            }
            transform.gameObject.SetActive(false);
        }
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerComm(other, SkillTriggerStyle.Enter);
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerComm(other, SkillTriggerStyle.Stay);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerComm(other, SkillTriggerStyle.Exit);
        }
        private void OnTriggerComm(Collider other, SkillTriggerStyle skillTriggerStyle)
        {
            if (other.tag == "Monster" && skillProperties != null && skillProperties.Length > 0)
            {
                for (int i = 0; i < skillProperties.Length; i++)
                {
                    if (skillProperties[i].skillTriggerStyle == skillTriggerStyle)
                    {
                        skillProperties[i].TriggerEnter(other.GetComponent<Unit>());
                    }
                }
            }
        }
        public virtual void End()
        {
            transform.gameObject.SetActive(false);
        }
        /// <summary>
        /// 技能跟随着tr移动，直到碰到tr
        /// </summary>
        /// <param name="tr"></param>
        public void Play(Transform tr)
        {
            if (CheckCD())
            {
                return;
            }
            ResetSkillState();
            transform.gameObject.SetActive(true);
            SkillCDUI();
            YungsUT.Instance.StartCoroutine(SkillCD());
            if (isDirectivity && Distance > 0)
            {
                attackTarget = tr;
                YungsUT.Instance.StartCoroutine(MoveByTarget(tr));
            }
        }
        public YungsResult Play(Vector3 point)
        {
            if (CheckCD())
            {
                return new YungsResult(1,"技能CD中");
            }
            if (selfUnit.unitProperty.mp.CurrValue < mpSpend.MaxValue)
            {
                return new YungsResult(1,"MP不足");
            }
            ResetSkillState();
            transform.gameObject.SetActive(true);
            SkillCDUI();
            YungsUT.Instance.StartCoroutine(SkillCD());
            if (!isDirectivity && Distance > 0)
            {
                var dir = transform.position + (point - transform.position).normalized * Distance;
                dir = new Vector3(dir.x, 1, dir.z);
                transform.DOMove(dir, Distance / Speed).SetEase(Ease.Linear).OnComplete(() => transform.gameObject.SetActive(false));
            }
            return new YungsResult(0, "success");
        }
        public void Play()
        {
            if (CheckCD())
            {
                return;
            }
            SkillCDUI();
            transform.gameObject.SetActive(true);
        }

        void SkillCDUI()
        {
            selfUnit.unitProperty.mp.CurrValue -= mpSpend.MaxValue;
            GlobalEvent.skillEnterCDEvent(transform.name,CD);
            GlobalEvent.mpChangeEvent(selfUnit.unitProperty.mp.CurrValue, selfUnit.unitProperty.mp.MaxValue);
        }
        IEnumerator MoveByTarget(Transform tar)
        {
            while (transform.gameObject.activeSelf)
            {
                var dis = tar.position - transform.position;
                transform.position += dis.normalized * Time.deltaTime * Speed;
                if (!tar.gameObject.activeSelf)
                {
                    transform.gameObject.SetActive(false);
                }
                yield return null;
            }
        }
        IEnumerator SkillCD()
        {
            selfUnit.unitProperty.mp.CurrValue -= mpSpend.CurrValue;
            cd_tmp = CD;
            while (cd_tmp > 0)
            {
                yield return new WaitForSeconds(0.1f);
                cd_tmp -= 0.1f;
            }
        }
        /// <summary>
        /// 检测是否在CD之中
        /// true:正在CD 
        /// false:未CD
        /// </summary>
        /// <returns></returns>
        public bool CheckCD()
        {
            if (Level <=0)
            {
                return true;
            }
            return cd_tmp > 0;
        }

        void ResetSkillState()
        {
            transform.position = startPosTr.position;
            transform.eulerAngles = startPosTr.eulerAngles;
        }
        public static KeyCode GetKeycodeBySkillKey(SkillKeyCode skillKeyCode)
        {
            switch (skillKeyCode)
            {
                case SkillKeyCode.Q: return KeyCode.Q;
                case SkillKeyCode.W: return KeyCode.W;
                case SkillKeyCode.E: return KeyCode.E;
                case SkillKeyCode.R: return KeyCode.R;
                case SkillKeyCode.D: return KeyCode.D;
                case SkillKeyCode.F: return KeyCode.F;
                default: return KeyCode.RightShift;
            }
        }
        public enum SkillKeyCode
        {
            A,
            Q,
            W,
            E,
            R,
            D,
            F
        }

        public enum SkillTriggerStyle
        {
            Enter,
            Stay,
            Exit
        }
    }
}