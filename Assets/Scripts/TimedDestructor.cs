using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestructor : MonoBehaviour
{
    public float Lifetime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Lifetime);
    }
}
