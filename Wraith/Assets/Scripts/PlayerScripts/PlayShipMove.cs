using System;
using UnityEngine;



public class PlayShipMove : MonoBehaviour
{
    private Animator animator;
    public static float maxAccel = 9f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 post = transform.position;
    
        //THIS MOVES PLAYER
        //Returns float from -1 to 1, + = up, - = down
        float y = Input.GetAxis("Vertical") ;
        //Returns float from -1 to 1, + = right, - = left
        float x = Input.GetAxis("Horizontal") * -1 ;
        
        //Trigger animations based on input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetTrigger("LeftArrowPress");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetTrigger("RightArrowPress");
        }
        
        //Not using z axis
        Vector2 direction = new Vector2(x,y).normalized;
        if(direction != Vector2.zero)
            Movement(direction);

    }

    void Movement(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));

        max.x -= 0.75f;
        min.x += 0.75f;

        max.y -= 1f;
        min.y += 1f;

        //Current position
        Vector2 pos = transform.position;

        //New position
        pos += direction * maxAccel * Time.deltaTime;

        //Sets boundaries for player
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //New position
        transform.position = pos;

    }
    
    
}