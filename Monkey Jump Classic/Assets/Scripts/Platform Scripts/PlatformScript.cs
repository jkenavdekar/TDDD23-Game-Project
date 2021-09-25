using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField]
    private GameObject oneBanana, Bananas;

    [SerializeField]
    private Transform spawn_point;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newbanana = null;

        if(Random.Range(0, 10) > 3) 
        {
            newbanana = Instantiate(oneBanana, spawn_point.position, Quaternion.identity);

        }
        else
        {
            newbanana = Instantiate(Bananas, spawn_point.position, Quaternion.identity);
        }

        newbanana.transform.parent = transform;
        
    }

}
