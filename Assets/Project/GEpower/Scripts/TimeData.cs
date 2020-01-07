using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeData : MonoBehaviour
{
    public Text[] texts;
    private float[] num;
    private bool isRandom=false;
    private float time_;

    public LineRenderer line;
    public Transform[] Tran;
    // Start is called before the first frame update
    void Start()
    {
        time_ = 0;
        num = new float[4];
    }

    // Update is called once per frame
    void Update()
    {
        time_ += Time.deltaTime;
       if(time_>=5)
        {
            isRandom = true;
        }
        if (isRandom)
        {
            num[0] = Random.Range(170, 190);
            texts[0].text = num[0] + "";
            num[1] = Random.Range(55, 62);
            texts[1].text = num[1] + "";
            num[2] = Random.Range(28, 35);
            texts[2].text = num[2] + "";
            num[3] = Random.Range(0, 2);
            texts[03].text = num[3] + "";
            time_ = 0;
            isRandom = !isRandom;
        }

        line.SetPosition(0, Tran[0].position);
        line.SetPosition(1, Tran[1].position);
    }
    private void OnDisable()
    {
        time_ = 0;
        isRandom = false;
    }
}
