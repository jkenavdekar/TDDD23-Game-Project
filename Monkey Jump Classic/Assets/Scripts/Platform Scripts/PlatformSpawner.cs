using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public static PlatformSpawner instance;

    private int score;


    [SerializeField]
    private GameObject left_platform, right_platform;

    private float left_x_min = -4.4f, left_x_max = -2.8f, right_x_min = 4.4f, right_x_max = 2.8f;

    private float y_threshold = 2.6f;

    private float last_y;

    public int spawn_count = 8;

    private int platform_spawned;

    [SerializeField]

    private Transform platform_parent;

    [SerializeField]
    private GameObject bird;
    public float bird_y = 5f;
    private float bird_x_min = -2.3f, bird_x_max = 2.3f;


    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }

    void Start()
    {
        last_y = transform.position.y;
        right_platform.GetComponent<platformrightmover>().enabled = false;
        left_platform.GetComponent<platformleftmover>().enabled = false;
        SpawnPlatforms(score);
    }

    public void SpawnPlatforms(int score)
    {
        Vector2 temp = transform.position;
        GameObject newplatform = null;

        for(int i = 0; i< spawn_count; i++)
        {
            temp.y = last_y;

            if(platform_spawned % 2 == 0)
            {
                temp.x = Random.Range(left_x_min, left_x_max);
                newplatform = Instantiate(right_platform, temp, Quaternion.identity);
                if(score > 10)
                {
                    right_platform.GetComponent<platformrightmover>().enabled = true;
                }

            }
            else
            {
                temp.x = Random.Range(right_x_min, right_x_max);
                newplatform = Instantiate(left_platform, temp, Quaternion.identity);
                if(score > 10)
                {
                    left_platform.GetComponent<platformleftmover>().enabled = true;
                }
            }

            newplatform.transform.parent = platform_parent;

            last_y += y_threshold;
            platform_spawned++;
        }

        if(Random.Range(0, 2) > 0)
        {
            if(score > 25)
            {
                bird.GetComponent<fly>().enabled = true;
                SpawnBird();

            }
            else if(score > 15)
            {
                bird.GetComponent<fly>().enabled = false;
                SpawnBird();
            }

        }

    }



    // Update is called once per frame
    void SpawnBird()
    {
        Vector2 temp = transform.position;

        temp.x = Random.Range(bird_x_min, bird_x_max);

        temp.y += bird_y;

        GameObject newBird = Instantiate(bird, temp, Quaternion.identity);

        newBird.transform.parent = platform_parent;

    }


}
