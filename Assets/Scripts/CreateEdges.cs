using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEdges : MonoBehaviour
{

    public GameObject TopRightCorner;
    public GameObject BottomLeftCorner;

    void Start()
    {
        SetUpEdges();
    }

    void SetUpEdges()
    {
        Vector3 point = new Vector3();
        point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, Camera.main.nearClipPlane));
        TopRightCorner.transform.position = point;

        point = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        BottomLeftCorner.transform.position = point;

    }
}
