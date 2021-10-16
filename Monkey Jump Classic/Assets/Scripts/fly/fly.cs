using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    public float speed = 2f;

    bool swch = true;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer =GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(swch){
            movebirdright();
        }
        if(!swch){
            movebirdleft();
        }
        if(transform.position.x >= 2.7f){
            swch = false;
            spriteRenderer.flipX = true;
        }
        if(transform.position.x <= -2.7f){
            swch = true;
            spriteRenderer.flipX = false;
        }
    }



    void movebirdright(){
        transform.Translate(speed*Time.deltaTime,0,0);
    }
    void movebirdleft(){
        transform.Translate(-speed*Time.deltaTime,0,0);
    }
}