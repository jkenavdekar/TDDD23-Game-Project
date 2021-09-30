using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformleftmover : MonoBehaviour
{
    public float speed = 5f;

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
            moveplatright();
        }
        if(!swch){
            moveplatleft();
        }
        if(transform.position.x >= 4.6f){
            swch = false;
            //spriteRenderer.flipX = true;
        }
        if(transform.position.x <= 0.3f){
            swch = true;
            //spriteRenderer.flipX = false;
        }
    }



    void moveplatright(){
        transform.Translate(speed*Time.deltaTime,0,0);
    }
    void moveplatleft(){
        transform.Translate(-speed*Time.deltaTime,0,0);
    }
}
