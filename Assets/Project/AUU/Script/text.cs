using ShowNow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class text : MonoBehaviour {
    private float origionY;                //记录当前y值
    private Quaternion targetRotation;    //目标角度
    public float RotateAngle = 30;       //每次旋转角度
    private int count;
    public Transform[] Button;//按钮位置
    
    void Start () {
        origionY = transform.rotation.y;
        NetHelper.Instance.RegistCmdHandler(this);
    }
	
	// Update is called once per frame
	void Update () {     
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2);
            if (Quaternion.Angle(targetRotation, transform.rotation) < 0.1)//停
            {
                transform.rotation = targetRotation;                       
            }        
    }
    /// <summary>
    /// 左右旋转
    /// </summary>
    public void left()
    {
        leftCMD();
        NetHelper.Instance.SyncCMD("leftCMD", null);
    }
    public void leftCMD()
    {
        count++;
        targetRotation = Quaternion.Euler(-90, RotateAngle * count + origionY, 0) * Quaternion.identity;
    }

    public void right()
    {
        rightCMD();
        NetHelper.Instance.SyncCMD("rightCMD", null);
    }
    public void rightCMD()
    {
        count--;
        targetRotation = Quaternion.Euler(-90, RotateAngle * count + origionY, 0) * Quaternion.identity;
       
    }
    /// <summary>
    /// 按钮移动
    /// </summary>
    public void Bigger()
    {
        BiggerCMD();
        NetHelper.Instance.SyncCMD("BiggerCMD", null);
    }
    public void BiggerCMD()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        Button[0].position += new Vector3(-0.05f, 0, 0);
        Button[1].position += new Vector3(0.05f, 0, 0);
        Button[2].position += new Vector3(0, 0.05f, 0);
        Button[3].position += new Vector3(0, -0.05f, 0);
    }
    public void Smaller()
    {
        SmallerCMD();
        NetHelper.Instance.SyncCMD("SmallerCMD", null);
    }
    public void SmallerCMD()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        Button[0].position -= new Vector3(-0.05f, 0, 0);
        Button[1].position -= new Vector3(0.05f, 0, 0);
        Button[2].position -= new Vector3(0, 0.05f, 0);
        Button[3].position -= new Vector3(0, -0.05f, 0);
    }
  
    private void OnDestroy()
    {
       NetHelper.Instance.UnRegistCmdHandler(this);

    }
}
