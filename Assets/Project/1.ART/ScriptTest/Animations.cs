using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {
    public GameObject[] UI;
    public GameObject[] Asste;
    int  IsOut=1;
    public Animator animator;
    // Use this for initialization
    void Start() {
        Asste[1].SetActive(false);
        Asste[2].SetActive(false);
        Asste[3].SetActive(false);
        Asste[0].SetActive(false);
        UI[0].SetActive(false);
        UI[1].SetActive(false);
        UI[2].SetActive(false);
        UI[3].SetActive(false);
    }
    public void OutReturn()
    {
        IsOut++;
        if (IsOut%2==0)
        {
            animator.SetTrigger("out");
            Debug.Log("out" + IsOut);
        }
        if (IsOut % 2 != 0)
        {
            animator.SetTrigger("return");
            Debug.Log("return" + IsOut);
        }
        
    }
    private void OnDisable()
    {
        IsOut = 1;
    }
    // Update is called once per frame
    void Update() {

    }
    //协同
    public void Collaboration()
    {
        UI[3].SetActive(false);
        UI[2].SetActive(false);
        UI[1].SetActive(false);
        UI[0].SetActive(true);
    }
    //资产
    public void Assets()
    {
        UI[3].SetActive(false);
        UI[2].SetActive(false);
        UI[0].SetActive(false);
        UI[1].SetActive(true);

    }
    //扫描
    public void Scan()
    {
        UI[3].SetActive(false);
        UI[0].SetActive(false);
        UI[1].SetActive(false);
        UI[2].SetActive(true);
    }
    //联系人
    public void AddressBook()
    {
        UI[0].SetActive(false);
        UI[2].SetActive(false);
        UI[1].SetActive(false);
        UI[3].SetActive(true);
    }
    //返回
    public void Return()
    {
        UI[0].SetActive(false);
        UI[1].SetActive(false);
        UI[2].SetActive(false);
        UI[3].SetActive(false);
    }

    //资产按钮
    public void BYD()
    {
        Asste[1].SetActive(false);
        Asste[2].SetActive(false);
        Asste[3].SetActive(false);
        Asste[0].SetActive(true);

    }
    public void CJLR()
    {

        Asste[0].SetActive(false);
        Asste[2].SetActive(false);
        Asste[3].SetActive(false);
        Asste[1].SetActive(true);
    }
    public void GEpower()
    {
        Asste[0].SetActive(false);
        Asste[1].SetActive(false);
        Asste[3].SetActive(false);
        Asste[2].SetActive(true);
    }
    public void GEfactory()
    {

        Asste[0].SetActive(false);
        Asste[1].SetActive(false);
        Asste[2].SetActive(false);
        Asste[3].SetActive(true);
    }
   
}
