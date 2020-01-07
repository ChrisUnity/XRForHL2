using ShowNow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour {

    public Animator AUUanimator;//动画
    public GameObject Phone1;//电话1
    public GameObject Phone2;//电话2
    public GameObject Boshu;//波束
    int a = 0;
    Vector3 vector3last;//之前的方向
    bool isleft;


    bool isLvboqi=true;
    bool isPinsheban = true;
    bool isTianxian = true;
    bool isOpen = true;

    private void OnEnable()
    {
    }
    // Use this for initialization
    void Start () {
        NetHelper.Instance.RegistCmdHandler(this);
        JGZS();

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            a++;
            Display(a);
        }
      
    }
    public void OnClick_lvboqi()
    {
        lvboqi();
        NetHelper.Instance.SyncCMD("lvboqi", null);
    }
    public void lvboqi()
    {
        if (isLvboqi)
        {
            Display(6);
            isLvboqi = !isLvboqi;
        }
        else
        {
            Display(7);
            isLvboqi = !isLvboqi;
        }
    }

    public void OnClick_pinsheban()
    {
        pinshe();
        NetHelper.Instance.SyncCMD("pinshe", null);
    }
    public void pinshe()
    {
        if (isPinsheban)
        {
            Display(4);
            isPinsheban = !isPinsheban;
        }
        else
        {
            Display(5);
            isPinsheban = !isPinsheban;
        } 
    }
    public void OnClick_tianxian()
    {
        tianxian();
        NetHelper.Instance.SyncCMD("tianxian", null);
    }
    public void tianxian()
    {
        if (isTianxian)
        {
            Display(2);
            isTianxian = !isTianxian;
        }
        else
        {
            Display(3);
            isTianxian = !isTianxian;
        }
    }
    public void OnClick_OpenClse()
    {
        OpCl();
        NetHelper.Instance.SyncCMD("OpCl", null);
    }
    public void OpCl()
    {
        if (isOpen)
        {
            Display(1);
            isOpen = !isOpen;
        }
        else
        {
            Display(8);
            isOpen = !isOpen;
        }
    }
    public void JGZS()//第一个按钮
    {
        CMDJGZS();
        NetHelper.Instance.SyncCMD("CMDJGZS", new string[] { });
    }
    public void CMDJGZS()
    {
        Display(9);
        isLvboqi = true;
        isPinsheban = true;
        isTianxian = true;
        isOpen = true;
    }
    public void XHFG()//第二个按钮
    {
        CMDXHFG();
        NetHelper.Instance.SyncCMD("CMDXHFG", null);
    }
    public void CMDXHFG()//第二个按钮
    {
        Display(10);
        Phone1.SetActive(false);
        Phone2.SetActive(false);
        Boshu.SetActive(true);
    }
    public void BSGZ()//第三个按钮
    {
        CMDBSGZ();
        NetHelper.Instance.SyncCMD("CMDBSGZ", null);
    }
    public void CMDBSGZ()//第三个按钮
    {
        Display(11);
        Phone1.SetActive(true);
        Phone2.SetActive(true);
        Boshu.SetActive(false);
    }

    /// <summary>
    /// 结构展示test
    /// </summary>
    /// <param name="display">1拆分 2天线板出 3天线板回 4频射板出 5频射板回 6滤波器出 7滤波器回 8合起来 </param>
    public void Display(int display)
    {
       
        switch (display)
        {
            case 1:
                AUUanimator.SetTrigger("Structuredisplay");
                break;
            case 2:
                AUUanimator.SetTrigger("tianxiandispla");
                break;
            case 3:
                AUUanimator.SetTrigger("tianxiandisplayOff");
                break;
            case 4:
                AUUanimator.SetTrigger("pinshebandisplay");
                break;
            case 5:
                AUUanimator.SetTrigger("pinshebandisplayOff");
                break;
            case 6:
                AUUanimator.SetTrigger("lvboqidisplay");
                break;
            case 7:
                AUUanimator.SetTrigger("lvboqidisplayOff");
                break;
            case 8:
                AUUanimator.SetTrigger("merge");
                break;
            case 9:
                AUUanimator.SetTrigger("strat"); 
                     AUUanimator.SetTrigger("JGZS"); 
                break;
            case 10:
                AUUanimator.SetTrigger("xhfg");
                break;
            case 11:
                AUUanimator.SetTrigger("bsgz");
                break;

        }
        
    }
    private void OnDisable()
    {
       
    }
    private void OnDestroy()
    {
        NetHelper.Instance.UnRegistCmdHandler(this);
    }


}
