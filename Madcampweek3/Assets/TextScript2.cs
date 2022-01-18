using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TextScript2 : MonoBehaviour
{
    
public Text ScriptTxt;
public Image image;
Color color;
    int Gold = 0;          
    int cnt = 0;          
    string[] intro = new string[]{"봄을 무사히 보낸 다람이", "어느덧 여름이 찾아오는데..","다람이는 사실 날다람쥐였다..!"};
    // Use this for initialization
    void Start()
    {
        color = image.color;
        color.a = 0.0f;
        image.color = color;
        ScriptTxt.text = intro[0];
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space)==true)
        {
            if(cnt>=2) 
            {
                cnt = 0;
                ScriptTxt.gameObject.SetActive(false);
                SceneManager.LoadScene("4");
            }
            else {
                cnt++;
                ScriptTxt.text = intro[cnt];
                if(cnt == 2){
                    color.a = 1.0f;
                    image.color = color;
                }
            }
        }
    }
}
