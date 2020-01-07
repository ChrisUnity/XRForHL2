using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFramework;
using UnityEngine.UI;

namespace ShowNow
{
    public class ResourceManager : ScriptSingleton<ResourceManager>
    {
        public GameObject World;
        public GameObject HololensCamera;
        public GameObject IpadCamera;
        public GameObject AnchorObj;
        public Transform AssetsManager;
        public Text log;
        public AudioSource AudioSource;
        public GameObject Location;
        public Transform LocationCanvas;
        [Header("数字人")]
        public GameObject DH;
        [Header("Chat")]
        public GameObject ChatPanel;
        public GameObject FriendItem;
        public Transform FriendPanel;
        public Transform InvitePanel;
        public GameObject UserItem;
        public GameObject CallPanel;
        public Text CallConnectStatus;
        public Text ZTE;
        [Header("Login")]
        public Dropdown LoginInput;
        public GameObject LoginPanel;
        public GameObject Logining;
        [Header("Assets")]
        public GameObject AssetsPanel;
        public GameObject AAUPrefab;
        public GameObject CarPrefab;
        public GameObject EnginePrefab;

        public AudioClip[] Audios;
        [Header("Assets")]
        public GameObject DHG;
        public GameObject DHM;

    }
}
