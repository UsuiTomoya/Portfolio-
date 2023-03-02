using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hinto : MonoBehaviour {
    public Text Qtext;
    float a_color;
    bool flag_G;
    float seconds;
    // Use this for initialization
    void Start () {
        a_color = 0;
    }
    // Update is called once per frame
    void Update () {
            //テキストの透明度を変更する
            Qtext.color = new Color (0, 0, 0, a_color);
            //if (flag_G)
            seconds += Time.deltaTime;
            if(seconds > 10)
            {
                a_color += Time.deltaTime;
                if (a_color > 255) {
                    a_color = 255;
                    flag_G = false;
                }
            }
            
    }
}

