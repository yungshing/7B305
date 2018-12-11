using UnityEngine;
using System.Collections;

public class YungsUT : MonoBehaviour
{
    private static YungsUT instance = null;
    public static YungsUT Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject g = new GameObject("YungsUT");
                instance = g.AddComponent<YungsUT>();
            }
            return instance;
        }
    }

    public void Delay(System.Action action,float time)
    {
        StartCoroutine(DelayIE(action,time));
    }

    IEnumerator DelayIE(System.Action action,float time)
    {
        var a = new System.Action(action);
        yield return new WaitForSeconds(time);
        a.Invoke();
    }
}
