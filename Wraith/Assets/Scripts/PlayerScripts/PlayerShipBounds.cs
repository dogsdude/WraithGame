using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}


public class PlayerShipBounds : MonoBehaviour
{
    public Boundary bounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.position= new Vector3
            ( Mathf.Clamp( transform.position.x, bounds.xMin, bounds.xMax),
                Mathf.Clamp( transform.position.y, bounds.yMin, bounds.yMax),
                0.0f
            );
        

       
    }
}
