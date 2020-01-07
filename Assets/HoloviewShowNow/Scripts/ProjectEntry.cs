
using UnityEngine;
using MyFramework;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using Microsoft.MixedReality.Toolkit;

namespace ShowNow
{
    public class ProjectEntry : ScriptSingleton<ProjectEntry>
    {
        //启用地面监测
        IMixedRealityDataProviderAccess access = CoreServices.SpatialAwarenessSystem as IMixedRealityDataProviderAccess;
        IMixedRealitySpatialAwarenessMeshObserver observer;

        private void Start()
        {
            //ChatManager.Instance.OnTestLogin();
            //#if UNITY_WSA
            //            Debug.unityLogger.logEnabled = false;
            //#endif
            Invoke("StartLocate", 3);
            NeedLocated = true;

            CoreServices.SpatialAwarenessSystem.ResumeObservers();
        }

        private void Update()
        {
            UpdateLocated(); 
        }
        public void UploadWorldAnchor()
        {
           
        }
#region 锚点更新逻辑
        public bool NeedLocated = false;
        public void UpdateLocated()
        {
            if (NeedLocated)
            {
                RaycastHit hitinfo;
#if UNITY_IOS
                if (Physics.Raycast(ResourceManager.Instance.IpadCamera.transform.position, ResourceManager.Instance.IpadCamera.transform.forward, out hitinfo, 10, 1 << 31))
#else
                if (Physics.Raycast(ResourceManager.Instance.HololensCamera.transform.position, ResourceManager.Instance.HololensCamera.transform.forward, out hitinfo, 10, 1 << 31))
#endif
                {
                    ResourceManager.Instance.Location.transform.position = hitinfo.point;
                    ResourceManager.Instance.LocationCanvas.transform.position = hitinfo.point;
                }
                else
                {
                    ResourceManager.Instance.Location.transform.position= Camera.main.transform.position + 3 * Camera.main.transform.forward;
                    ResourceManager.Instance.LocationCanvas.transform.position= Camera.main.transform.position + 3 * Camera.main.transform.forward;
                }
            }
        }
        public void StartLocate()
        {
            ResourceManager.Instance.AnchorObj.SetActive(true);
            NeedLocated = true;
        }
        public void EndLocate()
        {
            NeedLocated = false;
            UIManager.Instance.LocationComplete();
            //UIManager.Instance.SingleMode();
            // observer.Resume();
            //CoreServices.SpatialAwarenessSystem.SuspendObservers();
        }
        #endregion
        #region 
        public void Login()
        {
            UIManager.Instance.Login();
            ChatManager.Instance.OnTestLogin();
            NetHelper.Instance.JoinRoom();

        }
       
        public void Call()
        {
            ChatManager.Instance.OnTestCall();
            ResourceManager.Instance.CallPanel.SetActive(true);
            //ResourceManager.Instance.CallConnectStatus.gameObject.SetActive(true);
            ResourceManager.Instance.CallConnectStatus.text = "Connecting";
            ResourceManager.Instance.AudioSource.clip = ResourceManager.Instance.Audios[0];
            ResourceManager.Instance.AudioSource.Play();
        }
        public void Hang()
        {
            ResourceManager.Instance.AudioSource.Stop();
            ChatManager.Instance.OnTestHang();
            ResourceManager.Instance.CallPanel.SetActive(false);
            ResourceManager.Instance.DH.SetActive(false);
            //ResourceManager.Instance.AudioSource.clip = ResourceManager.Instance.Audios[1];
            //ResourceManager.Instance.AudioSource.Play();
        }
#endregion

        

    }



}

