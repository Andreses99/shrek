using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    

    [SerializeField] private TMP_Text timerText;

    private float timeElapsed;
    private int min;
    private int seg;


    // Update is called once per frame
    void Update() { 
            timeElapsed += Time.deltaTime;
            min = (int)(timeElapsed / 60f);
            seg = (int)(timeElapsed - min * 60f);
            timerText.text = string.Format("{0:00}:{1:00}", min, seg);
        
    }
}
