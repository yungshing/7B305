using UnityEngine;
using System.Collections;
using Yungs.D305;
using UnityEngine.AI;
using DG.Tweening;
public class Test : MonoBehaviour
{
    public AgentTest agentTest;
    public UIDamageFontController damageFont;

    public Transform tar;

    TestA ta;
    // Use this for initialization
    void Start()
    {
        ta = new TestA();
        ta.a = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            var t = ta;
            Debug.Log(t.a);
            ta.a = 11;
            Debug.Log(t.a);
            t.a = 12;
            Debug.Log(ta.a);
            var t1 = t;
            t = ta;
            ta.a = 13;
            Debug.Log(t.a + "  :  " + t1.a);
        }
    }

    IEnumerator T()
    {
        for (int i = 0; i < 6; i++)
        {

            //damageFont.ShowTxt("99999", Camera.main.WorldToScreenPoint(transform.position));
            yield return new WaitForSeconds(0.1f);
        }
    }

    [System.Serializable]
    public class AgentTest
    {
        public NavMeshAgent meshAgent;
        public void Update()
        {
            RaycastHit hitInfo;

            if (Input.GetMouseButtonDown(1))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hitInfo))
                {

                    meshAgent.SetDestination(hitInfo.point);

                }

            }
        }
    }
    [System.Serializable]
    public class MoveTest
    {
        public Vector3 startPos;
        public Vector3 endPos;
        public float speed;
        bool isMove = false;
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                isMove = !isMove;
            }
        }
        public void FixedUpdate()
        {
            if (isMove)
            {

            }
        }
    }

    public class TestA
    {
        public int a = 0;
    }
}
