using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyViaTime : MonoBehaviour
{
    
    //Will destroy after given time
    public float lifetime;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

}
