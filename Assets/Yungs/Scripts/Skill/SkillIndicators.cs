using UnityEngine;
using System.Collections;
using Werewolf.StatusIndicators.Components;
namespace Yungs.D305
{
    public class SkillIndicators : MonoBehaviour
    {
        public IndicatorsItem[] indicatorsItems;
        private void Start()
        {
            for (int i = 0; i < indicatorsItems.Length; i++)
            {
                //indicatorsItems[i].spellIndicator.gameObject.SetActive(false);
            }
        }
        private void Update()
        {

            GetKey(KeyCode.Q);
            GetKey(KeyCode.W);
            GetKey(KeyCode.E);
            GetKey(KeyCode.R);
            GetKey(KeyCode.D);
            GetKey(KeyCode.F);

            if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.R) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.F) || Input.GetMouseButtonDown(1))
            {
                for (int i = 0; i < indicatorsItems.Length; i++)
                {
                    if (indicatorsItems[i].spellIndicator.gameObject.activeSelf)
                    {
                        indicatorsItems[i].spellIndicator.gameObject.SetActive(false);
                        indicatorsItems[i].spellIndicator.OnHide();
                    }
                }
                if (!Cursor.visible)
                {
                    Cursor.visible = true;
                }
            }
        }

        void GetKey(KeyCode keyCode)
        {
            if (Input.GetKeyDown(keyCode))
            {
                for (int i = 0; i < indicatorsItems.Length; i++)
                {
                    if (indicatorsItems[i].keyCode.ToString().ToLower() == keyCode.ToString().ToLower())
                    {
                        if (!indicatorsItems[i].spellIndicator.gameObject.activeSelf)
                        {
                            indicatorsItems[i].spellIndicator.gameObject.SetActive(true);
                            indicatorsItems[i].spellIndicator.OnShow();
                            if (Cursor.visible)
                            {
                                Cursor.visible = false;
                            }
                        }
                        break;
                    }
                }
            }
        }

        [System.Serializable]
        public class IndicatorsItem
        {
            public Splat spellIndicator;
            public SkillMono.SkillKeyCode keyCode;
        }
    }
}