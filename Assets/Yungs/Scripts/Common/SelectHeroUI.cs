using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Yungs.D305
{
    public class SelectHeroUI : MonoBehaviour
    {
        public Button[] heroBtns;
        public Transform frame;
        public InputField nickName;
        public Button startBtn;
        // Use this for initialization
        void Start()
        {
            GameData.HeroName = "OuYang";
            for (int i = 0; i < heroBtns.Length; i++)
            {
                var c = i;
                heroBtns[i].onClick.AddListener(()=>
                {
                    GameData.HeroName = heroBtns[c].transform.parent.name;
                    frame.position = heroBtns[c].transform.position;
                });
            }

            startBtn.onClick.AddListener(()=>
            {
                GameData.NickName = nickName.text;
                var g = Instantiate(Resources.Load<GameObject>("Hero/" + GameData.HeroName));
                g.transform.localPosition = Vector3.zero;
                g.transform.localScale = Vector3.one;
                g.name = GameData.HeroName;
            });
        }    
    }

}