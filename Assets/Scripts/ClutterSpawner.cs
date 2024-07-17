using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClutterSpawner : MonoBehaviour
{
    GameObject[] clutter;
    GameObject clutterHolder;

    GameObject[] markers;
    float distx;
    float distz;

    // Start is called before the first frame update
    void Start()
    {
        // Fill marker array and calculate size of plane
        markers = new GameObject[transform.childCount];
        for (int i = 0; i <transform.childCount; i++)
        {
            markers[i] = transform.GetChild(i).gameObject;
        }
        distx = markers[1].transform.position.x - markers[0].transform.position.x;
        distz = markers[1].transform.position.z - markers[0].transform.position.z;

        // Fill clutter array
        clutterHolder = GameObject.Find("ClutterHolder");
        clutter = new GameObject[clutterHolder.transform.childCount];
        for (int i = 0; i < clutterHolder.transform.childCount; i++)
        {
            clutter[i] = clutterHolder.transform.GetChild(i).gameObject;
        }

        // Ugly functions that run the clutter placer 4 seperate times on seperate areas of the plane. This is an attempt to balance the clutter spread a little bit but I don't really know what I'm doing
        UpdateArea(markers[0].transform.position.x, 0.5f *distx+markers[0].transform.position.x, markers[0].transform.position.z, 0.5f * distz + markers[0].transform.position.z);
        UpdateArea(markers[0].transform.position.x, 0.5f * distx + markers[0].transform.position.x, 0.5f * distz + markers[0].transform.position.z, markers[1].transform.position.z);
        UpdateArea(0.5f * distx + markers[0].transform.position.x, markers[1].transform.position.x, markers[0].transform.position.z, 0.5f * distz + markers[0].transform.position.z);
        UpdateArea(0.5f * distx + markers[0].transform.position.x, markers[1].transform.position.x, 0.5f * distz + markers[0].transform.position.z, markers[1].transform.position.z);
    }

    void UpdateArea(float minx, float maxx, float minz, float maxz) 
    {
        // Decide how much clutter we want in this area
        int items = randomInt(1, 4); 

        // Spawn clutter as long as there are still items we haven't spawned
        while (items > 0)
        {
            // generate item position
            Vector3 randomPosition = new Vector3(randomFloat(minx, maxx),transform.position.y, randomFloat(minz, maxz));

            // make a quaternion with a random y rot for more variation to clutter
            Quaternion randomRotation =  Quaternion.Euler(0, randomInt(0,360), 0); 

            // Instantiate random gameobject from list
            Instantiate(clutter[randomInt(0,5)], randomPosition, randomRotation);

            items--;
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
