using UnityEngine;
using System.Collections;
using Yungs.D305;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    public Transform camTr;
    public Vector2 limit_X;
    public Vector2 limit_Y;
    public float moveSpeed = 1;
    Vector3 tmpVec;
    // Use this for initialization
    void Start()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            var t = Object.FindObjectOfType<YungsCharactorController>();
            if (t != null)
            {
                target = t.transform;
                tmpVec = target.localPosition - camTr.localPosition;
            }
            return;
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.F1))
        {
            CameraFollowCharactor();
        }

        MoveCamera();
    }
    private void CameraFollowCharactor()
    {
        camTr.localPosition = target.localPosition - tmpVec;
    }

    private void MoveCamera()
    {
        var v = Input.mousePosition;
        if (v.x < 10)  ///相机向左移动
        {
            if (camTr.localPosition.x > limit_X.x)
            {
                Move(Vector3.left);
            }
        }
        else if (v.x > Screen.width - 10) ///相机向右移动
        {
            if (camTr.localPosition.x < limit_X.y)
            {
                Move(Vector3.right);
            }
        }
        else if (v.y < 10) ///向下移动
        {
            if (camTr.localPosition.z > limit_Y.x)
            {
                Move(Vector3.back);
            }
        }
        else if (v.y > Screen .height - 10) ///向上移动 
        {
            if (camTr.localPosition.z < limit_Y.y)
            {
                Move(Vector3.forward);
            }
        }
    }

    private void Move(Vector3 dir)
    {
        camTr.transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
}
