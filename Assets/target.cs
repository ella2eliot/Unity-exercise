using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    Rigidbody rb;
    gmanager gm;
    public int pointvalue=5;
    public ParticleSystem p;        //消滅特效
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(14, 18), ForceMode.Impulse);      //往上丟
        rb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);  //物件旋轉
        transform.position = new Vector3(Random.Range(-4, 4), -6, 0);     //起始位置
        gm=GameObject.Find("GameManager").GetComponent<gmanager>();     //從gmanager抓取出來的對象作為gm這個變數
    }
    void OnMouseDown()      //滑鼠點擊物件
    {
        if (gm.isplay)
        {
            gm.updateScore(pointvalue);      //點到物件加5分
            Instantiate(p, transform.position, p.transform.rotation);       //(物件,位置,旋轉)
            Destroy(gameObject);
        }
        
    }
    void OnTriggerEnter(Collider other)     //物件落下至遊戲視線(Sensor)外
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("bad"))      //沒吃到食物
        {
            gm.gameover();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
