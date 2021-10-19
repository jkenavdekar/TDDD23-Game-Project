using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D myBody;
    public float move_Speed = 2f;
    public float normal_Push = 10f;
    public float extra_Push = 14f;
    private bool initial_Push;
    private int push_Count;
    private bool player_Died;

    private Text bananaTextScore;
    private int scorecount;
    private float counterFlag;

    public float health = 100f;

    [SerializeField]
    private Image health_UI;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        bananaTextScore = GameObject.Find("Text").GetComponent<Text>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {

        move();
    }

    void move()
    {

        if(player_Died && counterFlag < 100)
        {
            transform.rotation = Quaternion.Euler(0 , 0, counterFlag);
            counterFlag = counterFlag + 1;
        }

        if(player_Died && counterFlag >= 100)
        {
            health_UI.fillAmount = 0f;
            return;
        }

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            myBody.velocity = new Vector2(move_Speed, myBody.velocity.y);
            health_UI.fillAmount = (health-20f) / 100f;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            myBody.velocity = new Vector2(-move_Speed, myBody.velocity.y);
            health_UI.fillAmount = (health-20f) / 100f;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if(player_Died)
        {
            return;
        }

        if(target.tag == "ExtraPush")
        {
            if(!initial_Push)
            {
                initial_Push = true;

                myBody.velocity = new Vector2(myBody.velocity.x, 18f);

                target.gameObject.SetActive(false);

                SoundManager.instance.JumpSoundFX();

                return;
            }
        }

        if(target.tag == "NormalPush")
        {
            scorecount++;

            bananaTextScore.text = "x" + scorecount;

            myBody.velocity = new Vector2(myBody.velocity.x, normal_Push);

            target.gameObject.SetActive(false);

            push_Count++;

            SoundManager.instance.JumpSoundFX();

            health = 50f;

            health_UI.fillAmount = health / 100f;
            PlayerPrefs.SetInt("Score",scorecount);
        }

        if(target.tag == "ExtraPush")
        {
            scorecount += 2;
            
            bananaTextScore.text = "x" + scorecount;

            myBody.velocity = new Vector2(myBody.velocity.x, extra_Push);

            target.gameObject.SetActive(false);

            push_Count++;

            SoundManager.instance.JumpSoundFX();

            health = 100f;
            health_UI.fillAmount = health / 100f;
            PlayerPrefs.SetInt("Score",scorecount);
        }

        if(push_Count == 2)
        {
            push_Count = 0;
            PlatformSpawner.instance.SpawnPlatforms(scorecount);
        }

        if(target.tag == "FallDown" || target.tag == "Bird")
        {

            health = 50f;

            health_UI.fillAmount = health / 100f;

            myBody.velocity = new Vector2(0f, 0f);

            player_Died = true;

            SoundManager.instance.GameOverSoundFX();

            GameManager.instance.RestartGame();

        }


    }

}
