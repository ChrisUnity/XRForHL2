using ShowNow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEN : MonoBehaviour
{
    public GameObject[] UI;
    // Start is called before the first frame update
    void Start()
    {
        NetHelper.Instance.RegistCmdHandler(this);
    }

    // Update is called once per frame
    public void IsActiveRotating()
    {
        Rota();
        NetHelper.Instance.SyncCMD("Rota", null);
    }
    public void Rota()
    {
        UI[0].SetActive(true);
       
    }

    public void IsActiveTemperature()
    {
        Temp();
        NetHelper.Instance.SyncCMD("Temp", null);
        
    }
    public void Temp()
    {
        UI[1].SetActive(true);
      
    }

    public void IsActiveVibration()
    {
        Vibra();
        NetHelper.Instance.SyncCMD("Vibra", null);
    }
    public void Vibra()
    {
        UI[2].SetActive(true);

    }
    private void OnDisable()
    {
    }
    private void OnDestroy()
    {
        NetHelper.Instance.UnRegistCmdHandler(this);

    }
}
