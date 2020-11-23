using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCollector : MonoBehaviour
{
    public static ScoreCollector Instance;

    [SerializeField] private Text display;

  

    void Awake()
    {
        Instance = this;
     
    }

    public void AddScore(float score)
    {
       
            display.text = score.ToString();
            
        

    }
}
