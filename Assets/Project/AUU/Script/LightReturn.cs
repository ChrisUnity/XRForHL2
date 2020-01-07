using ShowNow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReturn : MonoBehaviour {
    public GameObject Lights;
    private float origionY;                //记录当前y值
    private float origionX;                //记录当前x值
    private Quaternion targetRotation;    //目标角度
    public float RotateAngle = 15;       //左右每次旋转角度
    public float RotateAngle2 = 5;       //上下每次旋转角度
    private int count=1;
    private int count2 = 0;
    public GameObject Phone1;//电话
    float xNOW;
    float yNOW;
   // bool IsMove=true;

    public LineRenderer line; //第一个手机的line
    public Transform Begin; //第一个手机line的起始点
    public Transform End;//第一个手机line的终点

    public LineRenderer line2; //第2个手机的line
    public Transform Begin2; //第2个手机line的起始点
    public Transform End2;//第2个手机line的终点

    public Material LineMaterial; //LineRenderer的材质
   
    // Use this for initialization
    void Start () {
        NetHelper.Instance.RegistCmdHandler(this);
        origionY = Lights.transform.rotation.y;
        origionX = Lights.transform.rotation.x;
        xNOW = Lights.transform.rotation.x - 106.68f;
        yNOW = Lights.transform.rotation.y - 88.34f;

      //  line= Begin.gameObject.AddComponent<LineRenderer>();      
      //  line.SetWidth(0.1f, 0.1f);//设置直线宽度
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.material = LineMaterial;
        
        //line2.SetWidth(0.1f, 0.1f);//设置直线宽度
        line2.startWidth = 0.1f;
        line2.endWidth = 0.1f;
        line2.material = LineMaterial;   
    }
	
	// Update is called once per frame
	void Update () {
        Lights.transform.rotation = Quaternion.Slerp(Lights.transform.rotation, targetRotation, Time.deltaTime * 2);
        if (Quaternion.Angle(targetRotation, Lights.transform.rotation) < 0.1)//停
        {
            Lights.transform.rotation = targetRotation;
        }
        DrawLine();
    }
    public void Left()
    {
        LeftCMD();
        NetHelper.Instance.SyncCMD("LeftCMD", null);
    }
    public void LeftCMD()
    {
        count++;
        if (count > 3)
            count = 3;
        targetRotation = Quaternion.Euler(xNOW, RotateAngle * count + origionY - 103.19f, 0) * Quaternion.identity;
        yNOW = Lights.transform.rotation.y - 88.34f;
    }

    public void Right()
    {
        RightCMD();
        NetHelper.Instance.SyncCMD("RightCMD", null);
    }
    public void RightCMD()
    {
        count--;
        if (count < -3)
            count = -3;
        targetRotation = Quaternion.Euler(xNOW, RotateAngle * count + origionY - 103.19f, 0) * Quaternion.identity;
        yNOW = Lights.transform.rotation.y - 88.34f;

    }

    public void Up()
    {
        UpCMD();
        NetHelper.Instance.SyncCMD("UpCMD", null);
    }
    public void UpCMD()
    {
        count2++;
        if (count2 > 2)
            count2 = 2;
        targetRotation = Quaternion.Euler(RotateAngle2 * count2 + origionX - 106.68f, yNOW, 0) * Quaternion.identity;
        xNOW = Lights.transform.rotation.x - 106.68f;
    }

    public void Down()
    {
        DownCMD();
        NetHelper.Instance.SyncCMD("DownCMD", null);
    }
    public void DownCMD()
    {
        count2--;
        if (count2 < -2)
            count2 = -2;
        targetRotation = Quaternion.Euler(RotateAngle2 * count2 + origionX - 106.68f, yNOW, 0) * Quaternion.identity;
        xNOW = Lights.transform.rotation.x - 106.68f;
    }

    public void PhoneLeft()
    {
        PhoneLCDM();
        NetHelper.Instance.SyncCMD("PhoneLCDM", null);
    }
    public void PhoneLCDM()
    {
        if (count != 3)
        {
            Phone1.transform.Rotate(new Vector3(0, 1, 0), 20);
        }

        count++;
        if (count >= 3)
        {
            count = 3;
            Phone1.transform.Rotate(new Vector3(0, 1, 0), 0.01f);

        }

    }

    public void PhoneRight()
    {
        PhoneRCMD();
        NetHelper.Instance.SyncCMD("PhoneRCMD", null);
    }
    public void PhoneRCMD()
    {
        if (count != -3)
        {
            Phone1.transform.Rotate(new Vector3(0, 1, 0), -20);
        }
        count--;
        if (count <= -3)
        {
            count = -3;
            Phone1.transform.Rotate(new Vector3(0, 1, 0), 0.01f);
        }
    }

    public void DrawLine()
    {
        line.SetPositions(new Vector3[2] { Begin.position, End.position });
        // line.SetPosition(0, End.localPosition);
        line2.SetPositions(new Vector3[2] { Begin2.position, End2.position });
        
    }
    private void OnDestroy()
    {
        NetHelper.Instance.UnRegistCmdHandler(this);
    }
}
