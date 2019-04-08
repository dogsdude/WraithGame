using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitEnd : MonoBehaviour
{
    public int initialPosition;
    public int finalPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        //
        //transform.Translate(initialPosition);
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("SceneManager");
        SceneManager sm = obj.GetComponent<SceneManager>();
        
        transform.Translate(initialPosition,0,0);
        transform.Translate(finalPosition,0,0);
        transform.Rotate(sm.rotationSpeed, 0,0);
        //transform.localScale += (sm.scalingSpeed, 0,0 );
            
      
        
        
    }
}
