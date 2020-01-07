using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowenEntest : MonoBehaviour
{
    public GameObject[] UI;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame

    public void Rota()
    {
        UI[0].SetActive(true);

    }

  
    public void Temp()
    {
        UI[1].SetActive(true);

    }


    public void Vibra()
    {
        UI[2].SetActive(true);

    }

}
