using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text bananaTextScore;
    // Start is called before the first frame update
    void Start()
    {
        bananaTextScore = GameObject.Find("singlebanana").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
