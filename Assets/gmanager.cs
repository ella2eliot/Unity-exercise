using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gmanager : MonoBehaviour
{
    public List<GameObject> targets;
    float rate = 1.0f;      //時間差
    int score = 0;
    public TextMeshProUGUI stext;    //TextMeshProUGUI在UI裡面
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
            yield return new WaitForSeconds(rate);      //設定物件出來的時間差
            int ind = Random.Range(0,targets.Count);
            Instantiate(targets[ind]);
        }
    }

    public void updateScore(int point)      //分數刷新
    {
        score += point;
        stext.text = "Score: " + score;
    }
    public void restart()       //重玩
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameover()      //沒吃到食物的結束
    {
        gtext.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        isplay = false;

    }
}
