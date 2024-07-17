using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killplane : MonoBehaviour
{

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
