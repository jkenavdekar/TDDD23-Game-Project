using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGspawner : MonoBehaviour
{

    private GameObject[] bgs;
    private float height;
    private float highest_y_pos;

    void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag("BG");
    }
    // Start is called before the first frame update
    void Start()
    {
        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;
        highest_y_pos = bgs[0].transform.position.y;

        for(int i=1; i < bgs.Length; i++)
        {
            if(bgs[i].transform.position.y > highest_y_pos)
            {
                highest_y_pos = bgs[i].transform.position.y;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "BG")
        {
            if(target.transform.position.y >= highest_y_pos)
            {
                Vector3 temp = target.transform.position;
                for(int i=0; i < bgs.Length; i++)
                {
                    if(!bgs[i].activeInHierarchy)
                    {
                        temp.y += height;
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);

                        highest_y_pos = temp.y;
                    }
                }
            }
        }
    }
}
