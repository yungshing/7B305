using UnityEngine;
using System.Collections;

using Sirenix.OdinInspector;
namespace Yungs.D305
{
    public class YungsMono : MonoBehaviour
    {
        [DisableInEditorMode, PropertyOrder(-100)]
        public string ID;
#if UNITY_EDITOR
        [OnInspectorGUI, PropertyOrder(-10)]
        private void DrawInfoAndAnimatingPointer()
        {
            ID = this.gameObject.GetInstanceID().ToString();
        }
#endif
    }
}