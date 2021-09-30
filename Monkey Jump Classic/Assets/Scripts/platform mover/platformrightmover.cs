using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformrightmover : MonoBehaviour
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
        if(transform.position.x >= -0.3f){
            swch = false;
            
        }
        if(transform.position.x <= -4.5f){
            swch = true;
            
        }
    }



    void moveplatright(){
        transform.Translate(speed*Time.deltaTime,0,0);
    }
    void moveplatleft(){
        transform.Translate(-speed*Time.deltaTime,0,0);
    }
}