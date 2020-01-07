using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GEpoweTest : MonoBehaviour
{
    //bool isMove = false;
    public GameObject[] StartPos;
    public GameObject[] EndPos;
    float Speed = 5;//吸附速度
    float Distance = 0.2f;//吸附距离
    public void Start()
    {
    }
    void Update()
    {      
        for (int i = 0; i < StartPos.Length; i++)
        {
            if (Vector3.Distance(StartPos[i].transform.position, EndPos[i].transform.position) < Distance)
            {
                StartPos[i].transform.position = Vector3.Lerp(StartPos[i].transform.position, EndPos[i].transform.position, Speed * Time.deltaTime * 2);
                StartPos[i].transform.rotation = new Quaternion(0, 1, 0, 0);
                if (Vector3.Distance(StartPos[i].transform.position, EndPos[i].transform.position) <= 0.001f)
                {
                    EndPos[i].SetActive(false);
                    StartPos[i].transform.localScale = Vector3.Lerp(StartPos[i].transform.localScale, new Vector3(3.5f, 3.5f, 3.5f), Speed * Time.deltaTime);
                }
                else
                {
                    EndPos[i].SetActive(true);
                }
            }
        }
    }
}
