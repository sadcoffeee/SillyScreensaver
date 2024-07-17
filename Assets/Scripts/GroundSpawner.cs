using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        // Create the first 3 slabs of floor
        Instantiate(groundPrefab, new Vector3(transform.position.x - 40, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(groundPrefab, new Vector3(transform.position.x - 20, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(groundPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // Create another slab of floor every 20 seconds, which is how long it takes for a slab to move one full length
        if (timer < 20)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Instantiate(groundPrefab, transform.position, Quaternion.identity);
        }
    }
}
