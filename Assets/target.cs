using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    Rigidbody rb;
    gmanager gm;
    public int pointvalue=5;
    public ParticleSystem p;        //�����S��
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(14, 18), ForceMode.Impulse);      //���W��
        rb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);  //�������
        transform.position = new Vector3(Random.Range(-4, 4), -6, 0);     //�_�l��m
        gm=GameObject.Find("GameManager").GetComponent<gmanager>();     //�qgmanager����X�Ӫ���H�@��gm�o���ܼ�
    }
    void OnMouseDown()      //�ƹ��I������
    {
        if (gm.isplay)
        {
            gm.updateScore(pointvalue);      //�I�쪫��[5��
            Instantiate(p, transform.position, p.transform.rotation);       //(����,��m,����)
            Destroy(gameObject);
        }
        
    }
    void OnTriggerEnter(Collider other)     //���󸨤U�ܹC�����u(Sensor)�~
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("bad"))      //�S�Y�쭹��
        {
            gm.gameover();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
