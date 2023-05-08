using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo : MonoBehaviour
{
    bool detener_time = false;
    public  void EventoClick()
    {
        if ( detener_time)
        {
            Time.timeScale = 1.0f;
            detener_time=false;
        }
        else
        {
            Time.timeScale = 0;
            detener_time = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
