using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEpower : MonoBehaviour
{
    public Transform startpos;
    public Transform endpos; 
    public Animator animator;
    float Speed = 5;//吸附速度
    float Distance = 0.2f;//吸附距离
    bool isback=true;
    // Start is called before the first frame update
    void Start()
    {       

    }

    // Update is called once per frame
    void Update()
    {          
        if (Vector3.Distance(startpos.position, endpos.position) < Distance)
        {
        startpos.transform.position = Vector3.Lerp(startpos.position, endpos.position, Speed * Time.deltaTime * 2);
        startpos.transform.rotation = new Quaternion(0, 0, 0, 0);
            if (Vector3.Distance(startpos.position, endpos.position) <= 0.001f)
            {
                if (isback)
                {
                    animator.SetTrigger("back");
                    isback = !isback;
                }
                
            }
        }
    }
    public void ReturnScal()//恢复原始大小
    {
        isback = true;
        startpos.localScale = new Vector3(2800, 2800, 2800);
    }
    public void OnDisable()
    {              
         animator.SetTrigger("Start");
        // isback = true;
    }
}
