using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public class snowspawner : MonoBehaviour
{
    GameObject[] snowflakes;
    public GameObject snowHolder;
    
    int randomroll = 2;
    public int spawnSnowCondition;

    // Start is called before the first frame update
    void Start()
    {
        // Fill snowflakes array
        snowflakes = new GameObject[snowHolder.transform.childCount];
        for (int i = 0; i < snowHolder.transform.childCount; i++)
        {
            snowflakes[i] = snowHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        snowTime();
    }

    void snowTime()
    {
        // Get a random number in the range specified. If lower than condition, increase the range for next random roll. If higher than condition, reset the range. This way chance for snowfall increases the longer we dont get any
        int temp = randomInt(1, randomroll);

        if (temp < spawnSnowCondition)
        {
            randomroll++;
        }
        else
        {
            randomroll = 2;
            
            // generate snow position
            Vector3 randomPosition = new Vector3(randomFloat(-5, 5), transform.position.y, randomFloat(-5, 5));

            // generate snow rotation
            Quaternion randomRotation = Quaternion.Euler(randomInt(0, 360), randomInt(0, 360), randomInt(0, 360));

            // Instantiate random gameobject from list
            Instantiate(snowflakes[randomInt(0, 2)], randomPosition, randomRotation);

        }
    }

    // Making an easily call-able int to get a random whole number between a range, both numbers inclusive
    int randomInt(int min, int max)
    {
        // Random.Range does not treat the max value as inclusive, however I wish this function do to so. Therefore we add 1 to it
        return Random.Range(min, max + 1);
    }

    // Making an easily call-able float to get a random whole number between a range, both numbers inclusive
    float randomFloat(float min, float max)
    {
        // Due to the different nature of floats from ints we do not add 1 to this value. Inputs are not inclusive but this is not necessary with floats as the random range can come virtually infinitely close
        return Random.Range(min, max);
    }
}
