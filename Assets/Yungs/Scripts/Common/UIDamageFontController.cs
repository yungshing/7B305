using UnityEngine;
using System.Collections;
namespace Yungs.D305
{
    public class UIDamageFontController : MonoBehaviour
    {
        UIDamageFont[] uIDamageFonts;
        int index = 0;
        // Use this for initialization
        void Start()
        {
            uIDamageFonts = transform.GetComponentsInChildren<UIDamageFont>(true);
            index = 0;
            GlobalEvent.showDamageFontEvent = ShowDamageTxt;
        }

        public void ShowDamageTxt(IDamage damage,Vector3 pos)
        {
            uIDamageFonts[index].ShowDamage(damage, Camera.main.WorldToScreenPoint(pos), 240, 0.7f);
            if (++index >= uIDamageFonts.Length)
            {
                index = 0;
            }
        }
    }
}