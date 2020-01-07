using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFramework;
using DG.Tweening;

namespace ShowNow
{
    public class UIManager : ScriptSingleton<UIManager>
    {
        public void Start()
        {
            FrameworkEntry.Instance.GetManager<EventManager>().Subscribe(10, ReceviveFriendsListHandler);
            FrameworkEntry.Instance.GetManager<EventManager>().Subscribe(11, CallHandler);
            FrameworkEntry.Instance.GetManager<EventManager>().Subscribe(12, AcceptCallHandler);
            FrameworkEntry.Instance.GetManager<EventManager>().Subscribe(13, LoginResultHandler);

            NetHelper.Instance.RegistCmdHandler(this);
        }
        public void ChangeLoginAccount()
        {
            
            Debug.Log(ResourceManager.Instance.LoginInput.value);
            switch (ResourceManager.Instance.LoginInput.value)
            {
                case 0:
                    ChatManager.Instance.LoginAccount = "13611112221";
                    ChatManager.Instance.LoginPassword = "111111";
                    ChatManager.Instance.TargetUserId = 1000171296769;
                    ResourceManager.Instance.ZTE.text = "ZTE4";
                   // ResourceManager.Instance.DH = ResourceManager.Instance.DHG;
                    break;
                case 1:
                    ChatManager.Instance.LoginAccount = "13611112220";
                    ChatManager.Instance.LoginPassword = "111111";
                    ChatManager.Instance.TargetUserId = 1000171296750;
                   // ResourceManager.Instance.DH = ResourceManager.Instance.DHM;
                    ResourceManager.Instance.ZTE.text = "ZTE3";

                    break;
            }
        }
        public void Login()
        {
            ResourceManager.Instance.Logining.SetActive(true);
        }
        #region holocallkit连接回调
        public void LoginResultHandler(object sender, GlobalEventArgs e)
        {
            LoginResultEvent t = e as LoginResultEvent;
            if (t.Result)
            {
                ResourceManager.Instance.Logining.SetActive(false);
                ResourceManager.Instance.LoginPanel.SetActive(false);

                ResourceManager.Instance.ChatPanel.SetActive(true);
                ResourceManager.Instance.AssetsPanel.SetActive(true);
            }
            else
            {
                ResourceManager.Instance.Logining.SetActive(false);

            }

        }
        void CallHandler(object sender, GlobalEventArgs e)
        {
            CallResultEvent t = e as CallResultEvent;
            if (t.Result)
            {
                //Debug.Log("呼叫成功");
                ResourceManager.Instance.DH.SetActive(true);
                //ResourceManager.Instance.CallPanel.SetActive(true);
                ResourceManager.Instance.CallConnectStatus.text = "Connected";
                ResourceManager.Instance.AudioSource.Stop();
            }
            else
            {
                ResourceManager.Instance.CallConnectStatus.text = "DisConnect";
                ResourceManager.Instance.CallPanel.SetActive(false);
                ResourceManager.Instance.DH.SetActive(false);
                ResourceManager.Instance.AudioSource.Stop();
            }
           
        }
        void AcceptCallHandler(object sender, GlobalEventArgs e)
        {
            ResourceManager.Instance.DH.SetActive(true);
            ResourceManager.Instance.CallPanel.SetActive(true);
        }
        void ReceviveFriendsListHandler(object sender, GlobalEventArgs e)
        {
            //FriendListEvent t = e as FriendListEvent;
            //for(int i = 0; i < t.Friends.Count; i++)
            //{
            //    //Debug.Log(t.Friends[i].name);
            //    GameObject go = Instantiate(ResourceManager.Instance.FriendItem,ResourceManager.Instance.FriendPanel);
            //    go.GetComponent<QuoteItem>().Name.text = t.Friends[i].name;
            //    go.GetComponent<QuoteItem>().ID = t.Friends[i].
        }
        #endregion
        GameObject AAU=null;
        GameObject Car = null;
        GameObject Engine = null;

        public void ShowAAU()
        {
            CMDShowAAU();
            NetHelper.Instance.SyncCMD("CMDShowAAU", null);
        }
        public void CMDShowAAU()
        {
            if (AAU)
            {
                Transform[] transforms = ResourceManager.Instance.AssetsManager.GetComponentsInChildren<Transform>();
                for(int i=1; i < transforms.Length; i++)
                {
                    Destroy(transforms[i].gameObject);
                }
            }
            else
            {
                Transform[] transforms = ResourceManager.Instance.AssetsManager.GetComponentsInChildren<Transform>();
                for (int i = 1; i < transforms.Length; i++)
                {
                    Destroy(transforms[i].gameObject);
                }
                AAU = Instantiate(ResourceManager.Instance.AAUPrefab, ResourceManager.Instance.AssetsManager);
            }

        }
        public void ShowCar()
        {
            CMDShowCar();
            NetHelper.Instance.SyncCMD("CMDShowCar", null);
        }
        public void CMDShowCar()
        {
            if (Car)
            {
                Transform[] transforms = ResourceManager.Instance.AssetsManager.GetComponentsInChildren<Transform>();
                for (int i = 1; i < transforms.Length; i++)
                {
                    Destroy(transforms[i].gameObject);
                }
            }
            else
            {
                Transform[] transforms = ResourceManager.Instance.AssetsManager.GetComponentsInChildren<Transform>();
                for (int i = 1; i < transforms.Length; i++)
                {
                    Destroy(transforms[i].gameObject);
                }
                Car = Instantiate(ResourceManager.Instance.CarPrefab, ResourceManager.Instance.AssetsManager);
            }

        }
        public void ShowEngine()
        {
            CMDSE();
            NetHelper.Instance.SyncCMD("CMDSE", null);
        }
        public void CMDSE()
        {
            if (Engine)
            {
                Transform[] transforms = ResourceManager.Instance.AssetsManager.GetComponentsInChildren<Transform>();
                for (int i = 1; i < transforms.Length; i++)
                {
                    Destroy(transforms[i].gameObject);
                }
            }
            else
            {
                Transform[] transforms = ResourceManager.Instance.AssetsManager.GetComponentsInChildren<Transform>();
                for (int i = 1; i < transforms.Length; i++)
                {
                    Destroy(transforms[i].gameObject);
                }
                Engine = Instantiate(ResourceManager.Instance.EnginePrefab, ResourceManager.Instance.AssetsManager);
            }
        }
        public void LocationComplete()
        {
            ResourceManager.Instance.World.transform.position = ResourceManager.Instance.Location.transform.position;
            ResourceManager.Instance.World.transform.rotation = ResourceManager.Instance.Location.transform.rotation;
            ResourceManager.Instance.World.SetActive(true);
            ResourceManager.Instance.AnchorObj.SetActive(false);
            //ResourceManager.Instance.AssetsManager.DOMoveY(Mathf.Abs(ResourceManager.Instance.World.transform.position.y),0);
        }
        public void SingleMode()
        {
            ResourceManager.Instance.LoginPanel.SetActive(false);
            ResourceManager.Instance.AssetsPanel.gameObject.SetActive(true); 
            ResourceManager.Instance.World.transform.position = ResourceManager.Instance.Location.transform.position;
            ResourceManager.Instance.World.transform.rotation = ResourceManager.Instance.Location.transform.rotation;
            ResourceManager.Instance.World.SetActive(true);
            ResourceManager.Instance.AnchorObj.SetActive(false);
        }
        public void LocateRotateLeft()
        {
            ResourceManager.Instance.Location.transform.Rotate(new Vector3(0, 45, 0));
        }
        public void LocateRotateRight()
        {
            ResourceManager.Instance.Location.transform.Rotate(new Vector3(0,- 45, 0));
        }

    }
}


