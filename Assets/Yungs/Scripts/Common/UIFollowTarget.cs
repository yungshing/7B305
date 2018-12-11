using UnityEngine;
using System.Collections;

public class UIFollowTarget : MonoBehaviour
{
    public Transform tar;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(tar.position);
    }
}
