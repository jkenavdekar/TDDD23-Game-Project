using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float movespeed = 1f;
    private Rigidbody2D mybody;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        mybody.velocity = new Vector2(movespeed, mybody.velocity.y);
        
    }
}
