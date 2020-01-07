using ShowNow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DMControl : MonoBehaviour
{
    public Animator a;
    public enum DigitalManState
    {
        walk,
        squat,
        stand,
        greet,
        idle
    }
     Vector2 InitTransform;
     Vector2 CurrentTransform;
     Vector2 LastTransform;
    public DigitalManState State = DigitalManState.idle;

    #region 动作检测
    float lastY;
    float currentsY;
    void MotionDetection()
    {
        CurrentTransform = new Vector2(ResourceManager.Instance.HololensCamera.transform.position.x, ResourceManager.Instance.HololensCamera.transform.position.z);
        // LogManager.Instance.Logs.Enqueue(CurrentTransform.ToString());
        currentsY = ResourceManager.Instance.HololensCamera.transform.position.y;
        if (Vector2.Distance(LastTransform,CurrentTransform) > 0.1f)
        {
            //DMWalk(CurrentTransform.x.ToString(), CurrentTransform.y.ToString());
            //正在行走
            //DMWalk(CurrentTransform.x.ToString(), CurrentTransform.y.ToString(), CurrentTransform.z.ToString());
            NetHelper.Instance.SyncCMD("DMWalk", new string[] { CurrentTransform.x.ToString(), CurrentTransform.y.ToString() });
           // DMWalk(CurrentTransform.x.ToString(), InitTransform.y.ToString(), CurrentTransform.z.ToString());
        }
        else
        {
            //站立
           // NetHelper.Instance.SyncCMD("DMIdle", new string[] { });
        }
        LastTransform = new Vector2(ResourceManager.Instance.HololensCamera.transform.position.x,ResourceManager.Instance.HololensCamera.transform.position.z);
    }
    public void SquatDetection()
    {
        currentsY = ResourceManager.Instance.HololensCamera.transform.position.y;
         if ((lastY - currentsY) > 0.15f)
        {
            //正在蹲下
            NetHelper.Instance.SyncCMD("DMSquat", new string[] { });
            // DMSquat();
            //Debug.Log("蹲下");
            //LogManager.Instance.Logs.Enqueue("蹲下");
        }
        else if ((lastY - currentsY) < -0.15f)
        {
            //正在站起来
            NetHelper.Instance.SyncCMD("DMStand", new string[] { });
            //Debug.Log("站起来");
            //DMStand();
            //LogManager.Instance.Logs.Enqueue("站起来");
        }
        lastY = ResourceManager.Instance.HololensCamera.transform.position.y;
    }


    public void DMWalk(string x,  string z)
    {
        transform.LookAt(new Vector3(float.Parse(x), ResourceManager.Instance.World.transform.position.y - 1.7f, float.Parse(z)));
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
        //Debug.Log("walk");
        transform.DOMove(new Vector3(float.Parse(x), ResourceManager.Instance.World.transform.position.y - 1.7f, float.Parse(z)), 0.7f).OnComplete(()=> { State = DigitalManState.idle; });
        //transform.position = new Vector3(float.Parse(x), float.Parse(y), float.Parse(z));
        //if (State == DigitalManState.walk) return;
        State = DigitalManState.walk;
        a.SetTrigger("Walk");
       // a.SetBool("Go",true);
    }
    
    public void DMIdle()
    {
        //Debug.Log("ssssssssssssssssssssss");
        //if (State == DigitalManState.idle) return;
        State = DigitalManState.idle;
        a.SetTrigger("Standing");
    }
    public void DMSquat()
    {
        ResourceManager.Instance.log.text += " DMSquat";
        // if (State == DigitalManState.squat) return;
        State = DigitalManState.squat;
        a.SetTrigger("SquatDown");
    }
    public void DMStand()
    {
        ResourceManager.Instance.log.text += " DMStand";
        //if (State == DigitalManState.stand) return;
        State = DigitalManState.stand;
        a.SetTrigger("Standup");
    }
    #endregion
    #region 射线检测
    LineRenderer lr;
    public Transform Head;
    public void LineDetection()
    {

        RaycastHit hitInfo;

        if (Physics.Raycast(
                Camera.main.transform.position,
                Camera.main.transform.forward,
                out hitInfo,
                8, 1 << 8))
        {
            ShowLine(hitInfo.point, true);
            //lr.SetPosition(0, Head.position);
            //lr.SetPosition(1, hitInfo.point);
        }
        else
        {
            ShowLine(hitInfo.point, false);

        }
    }
    public void ShowLine(Vector3 v,bool isShow)
    {
        if (isShow)
        {
            NetHelper.Instance.SyncCMD("CMDShowLine", new string[] {1.ToString(), v.x.ToString(),v.y.ToString(),v.z.ToString() });
           
        }
        else
        {
            NetHelper.Instance.SyncCMD("CMDShowLine", new string[] {0.ToString(), 0.ToString(), 0.ToString(), 0.ToString(), });

        }

    }
    public void CMDShowLine(string isShow,string x,string y,string z)
    {
        if (int.Parse(isShow) == 0)
        {
            lr.enabled = false;
        }
        else
        {
            lr.enabled = true;
            transform.LookAt(new Vector3(float.Parse(x), float.Parse(y), float.Parse(z)));
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
            lr.SetPosition(0, Head.position);
            lr.SetPosition(1, new Vector3(float.Parse(x), float.Parse(y), float.Parse(z)));
        }
    }
    public void CMDInitPositon(string x ,string z)
    {
        transform.position = new Vector3(float.Parse(x), ResourceManager.Instance.World.transform.position.y - 1.7f, float.Parse(z));
        InitTransform = new Vector2(float.Parse(x), float.Parse(z));
        CurrentTransform = InitTransform;
        LastTransform = InitTransform;
    }
    #endregion
    #region unity
    private void OnEnable()
    {
        transform.position = Vector3.zero;
        State = DigitalManState.idle;
        NetHelper.Instance.SyncCMD("CMDInitPositon", new string[] { ResourceManager.Instance.HololensCamera.transform.position.x.ToString(),  ResourceManager.Instance.HololensCamera.transform.position.z.ToString() });
        //CMDInitPositon(ResourceManager.Instance.HololensCamera.transform.position.x.ToString(), ResourceManager.Instance.HololensCamera.transform.position.z.ToString());
         //InitTransform =new Vector3(ResourceManager.Instance.HololensCamera.transform.position.x, ResourceManager.Instance.World.transform.position.y, ResourceManager.Instance.HololensCamera.transform.position.z);
        
        InvokeRepeating("MotionDetection", 0, 0.7f);
        InvokeRepeating("LineDetection", 0, 0.2f);
        InvokeRepeating("SquatDetection", 0, 0.2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(SystemInfo.deviceUniqueIdentifier);
        NetHelper.Instance.RegistCmdHandler(this);
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDisable()
    {
        CancelInvoke("MotionDetection");
        CancelInvoke("LineDetection");
        //NetHelper.Instance.UnRegistCmdHandler(this);
    }
    #endregion
}
