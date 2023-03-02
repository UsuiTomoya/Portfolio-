using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    private float time = 10.0f;
    public Text timerText;
    public Text timeUpText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(0 < time){
            time -= Time.deltaTime;
            timerText.text = time.ToString("F0");
        }
        else if (time < 0){
            //timeUpText.text = "ヒント：キッチンで使うもの";
            timerText.text = " ";
            if(scene.name == "Challenge#1"){
                timeUpText.text = "ヒント: キッチンで使うもの";
            }
            else if(scene.name == "Challenge#2"){
                timeUpText.text = "ヒント: 夏らしいもの";
            }
            else if(scene.name == "Challenge#3"){
                timeUpText.text = "ヒント: 実際に何かを折ろう";
            }
            else if(scene.name == "Challenge#4"){
                timeUpText.text = "ヒント: プシュよりもカチャ";
            }
            else if(scene.name == "Challenge#5"){
                timeUpText.text = "ヒント: なにかを振ろう";
            }
        }
    }
}
