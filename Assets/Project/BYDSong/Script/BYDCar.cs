using ShowNow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BYDCar : MonoBehaviour
{
    public Animator CarAnima;//动画
    public GameObject[] Wheel;//轮胎
    public Material[] ShellColor;//车漆
    public Texture[] texture;//图片
    // Start is called before the first frame update
    void Start()
    {
        NetHelper.Instance.RegistCmdHandler(this);
        Wheel[0].SetActive(true);
        Wheel[1].SetActive(false);
        Wheel[2].SetActive(false);
        ShellColor[0].mainTexture = texture[0];
        ShellColor[1].mainTexture = texture[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 播放动画触发
    /// </summary>
    /// <param trigger="trigger"></param>
    public void PalyAnima(string trigger)
    {
        PalyCMD(trigger);
        NetHelper.Instance.SyncCMD("PalyCMD", new string[] { trigger });
    }
    public void PalyCMD(string trigger)
    {
        CarAnima.SetTrigger(trigger);       
    }

    public void ChangeColor(int num)
    {
        ColorCMD(num);
        NetHelper.Instance.SyncCMD("ColorCMD", new string[] { num.ToString() });
    }
    public void ColorCMD(int num)
    {
        ShellColor[0].mainTexture = texture[num];
        ShellColor[1].mainTexture = texture[num];       
    }
    /// <summary>
    /// 换轮胎
    /// </summary>
    public void ChangeWheelA()
    {
        WheelACMD();
        NetHelper.Instance.SyncCMD("WheelACMD", null);
    }
    public void WheelACMD()
    {
        Wheel[0].SetActive(true);
        Wheel[1].SetActive(false);
        Wheel[2].SetActive(false);
    }

    public void ChangeWheelB()
    {
        WheelBCMD();
        NetHelper.Instance.SyncCMD("WheelBCMD", null);
    }
    public void WheelBCMD()
    {
        Wheel[1].SetActive(true);
        Wheel[0].SetActive(false);
        Wheel[2].SetActive(false);
    }


    public void ChangeWheelC()
    {
        WheelCCMD();
        NetHelper.Instance.SyncCMD("WheelCCMD", null);
    }
    public void WheelCCMD()
    {
        Wheel[2].SetActive(true);
        Wheel[1].SetActive(false);
        Wheel[0].SetActive(false);
    }


    public void Opening()
    {
        OpeningCMD();
        NetHelper.Instance.SyncCMD("OpeningCMD", null);
    }
    public void OpeningCMD()
    {
        CarAnima.SetTrigger("Blow");      
    }

    public void Closing()
    {
        ClosingCMD();
        NetHelper.Instance.SyncCMD("ClosingCMD", null);
    }
    public void ClosingCMD()
    {
        CarAnima.SetTrigger("Appear");      
    }

    public void Bigger()
    {
        bigCMD();
        NetHelper.Instance.SyncCMD("bigCMD", null);
    }
    public void bigCMD()
    {
        gameObject.transform.localScale += new Vector3(0.1f,0.1f , 0.1f);
        if (gameObject.transform.localScale == new Vector3(1.5f, 1.5f, 1.5f))
        {
            return;
        }
    }
    public void Smaller()
    {
        smaCMD();
        NetHelper.Instance.SyncCMD("smaCMD", null);
    }
    public void smaCMD()
    {
        gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        if (gameObject.transform.localScale == new Vector3(0,0,0))
        {
            return;
        }
    }

    private void OnDisable()
    {
        ShellColor[0].mainTexture = texture[0];
        ShellColor[1].mainTexture = texture[0];
        Wheel[0].SetActive(true);
        Wheel[1].SetActive(false);
        Wheel[2].SetActive(false);
        CarAnima.SetTrigger("Appear");
    }
    private void OnDestroy()
    {
        NetHelper.Instance.UnRegistCmdHandler(this);
    }


}
