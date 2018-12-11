using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
namespace Yungs.D305
{
    public class UIDamageFont : MonoBehaviour
    {

        public Transform panel;
        public Text yellowTxt;
        public Text redTxt;
        public Text whiteTxt;
        Tweener tweener = null;

        public void ShowTxt(string[] txt, Vector3 pos, float upVal = 150, float upTime = 0.7f)
        {
            if (tweener != null)
            {
                tweener.Kill(true);
            }
            panel.SetAsLastSibling();
            panel.gameObject.SetActive(true);
            panel.position = pos;
            yellowTxt.text = txt[0];
            redTxt.text = txt[1];
            whiteTxt.text = txt[2];
            tweener = panel.transform.DOMoveY(panel.transform.position.y + upVal, upTime).SetEase(Ease.Linear).OnComplete(() =>
              {
                  panel.gameObject.SetActive(false);
              });
        }

        public void ShowDamage(IDamage damage, Vector3 pos, float upVal = 150, float upTime = 2f)
        {
            var s = new string[3];
            s[0] = damage.AttackDamage.ToString();
            s[1] = damage.CriticalDamage <= 0 ? "" : damage.CriticalDamage.ToString();
            s[2] = damage.AttachDamage <= 0 ? "" : damage.AttachDamage.ToString();
            ShowTxt(s, pos, upVal, upTime);
        }
    }
}