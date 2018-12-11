using UnityEngine;
using System.Collections;
namespace Yungs.D305
{
    public class HideByTime : MonoBehaviour
    {
        public float time = 2f;
        public bool isOnEnable = true;


        float tmp = 0;
        bool isRun = false;
        private void OnEnable()
        {
            if (isOnEnable)
            {
                Hide();
            }
        }
        public void Hide()
        {
            tmp = 0;
            isRun = true;
        }
        void SelfHide()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (isRun)
            {
                if (tmp >= time)
                {
                    gameObject.SetActive(false);
                    isRun = false;
                }
                tmp += Time.deltaTime;
            }
        }
    }
}