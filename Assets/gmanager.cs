using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gmanager : MonoBehaviour
{
    public List<GameObject> targets;
    float rate = 1.0f;      //�ɶ��t
    int score = 0;
    public TextMeshProUGUI stext;    //TextMeshProUGUI�bUI�̭�
    public TextMeshProUGUI gtext;
    public Button button;
    public bool isplay = true;
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(spawnObject());
        stext.text = "Score: " + score;
        isplay = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnObject()
    {
        while (isplay)
        {
            yield return new WaitForSeconds(rate);      //�]�w����X�Ӫ��ɶ��t
            int ind = Random.Range(0,targets.Count);
            Instantiate(targets[ind]);
        }
    }

    public void updateScore(int point)      //���ƨ�s
    {
        score += point;
        stext.text = "Score: " + score;
    }
    public void restart()       //����
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameover()      //�S�Y�쭹��������
    {
        gtext.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        isplay = false;

    }
}
