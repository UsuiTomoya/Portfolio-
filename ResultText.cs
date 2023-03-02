using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultText : MonoBehaviour
{
    public Text textUI;
    public float step_time;
    
    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f;
        float value = ReceiverObject.Similary();
        Debug.Log(value);
        int number = ReceiverObject.Stuffnumber();
        Debug.Log(number);

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "C#1Answer")
        {
            if (number == 1)
            {
                if (value > 0.5)
                {
                    textUI.text = "Excellent!!";
                }
                else 
                {
                    textUI.text = "Good Job!";
                }
            }
            else
            {
                textUI.text = "Nice Try!";
            }
        }
        else if (scene.name == "C#2Answer")
        {
            if (number == 2)
            {
                if (value > 0.5)
                {
                    textUI.text = "Excellent!!";
                }
                else 
                {
                    textUI.text = "Good Job!";
                }
            }
            else
            {
                textUI.text = "Nice Try!";
            }
        }
        else if (scene.name == "C#3Answer")
        {
            if (number == 3)
            {
                if (value > 0.5)
                {
                    textUI.text = "Excellent!!";
                }
                else 
                {
                    textUI.text = "Good Job!";
                }
            }
            else
            {
                textUI.text = "Nice Try!";
            }
        }
        else if (scene.name == "C#4Answer")
        {
            if (number == 4)
            {
                if (value > 0.5)
                {
                    textUI.text = "Excellent!!";
                }
                else 
                {
                    textUI.text = "Good Job!";
                }
            }
            else
            {
                textUI.text = "Nice Try!";
            }
        }
        else if (scene.name == "C#5Answer")
        {
            if (number == 5)
            {
                if (value > 0.5)
                {
                    textUI.text = "Excellent!!";
                }
                else 
                {
                    textUI.text = "Good Job!";
                }
            }
            else
            {
                textUI.text = "Nice Try!";
            }
        }
        //textUI.text = "Sample Text";
        
    }

    // Update is called once per frame
    void Update()
    {
        step_time += Time.deltaTime;
        OnClickNextButton();
    }

    public void OnClickNextButton()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "C#1Answer")
        {
            if(step_time >= 3.0f)
            {
                SceneManager.LoadScene("Challenge#2");
            }
        }
        else if(scene.name == "C#2Answer")
        {
            if(step_time >= 3.0f)
            {
                SceneManager.LoadScene("Challenge#3");
            }
        }
        else if(scene.name == "C#3Answer")
        {
            if(step_time >= 3.0f)
            {
                SceneManager.LoadScene("Challenge#4");
            }
        }
        else if(scene.name == "C#4Answer")
        {
            if(step_time >= 3.0f)
            {
                SceneManager.LoadScene("Challenge#5");
            }
        }
        else if(scene.name == "C#5Answer")
        {
            if(step_time >= 3.0f)
            {
                SceneManager.LoadScene("FinalResult");
            }
        }
        
        
    }

}
