using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseButton : MonoBehaviour
{
    private bool isPause;

    void Pause()
    {
        Time.timeScale = 0;
    }
    void UnPause()
    {
        Time.timeScale = 1;
    }

    public void PauseHandler()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log("Pause");
        }
    }
    // Update is called once per frame
    /*void Update()
    {
       if(Input.GetKey(KeyCode.P)){
           isPause = !isPause;
           Debug.Log("Pause");
           if(isPause){
               Debug.Log("Pause");
               Pause();
           }
           else{
               Debug.Log("UnPause");
               UnPause();
           }
    }
}*/
}
