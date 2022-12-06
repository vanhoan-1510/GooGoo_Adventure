using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Traps : MonoBehaviour
{

    private Rigidbody2D rb;
    private GameObject player;
    private GameObject wall1, wall2;


    // Start is called before the first frame update
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        wall1 = GameObject.FindGameObjectWithTag("WallTrap1");
        wall2 = GameObject.FindGameObjectWithTag("WallTrap2");

        //enabled = false;
    }

    //    private void OnBecameVisible()
    //    {
    //        #if UNITY_EDITOR
    //        enabled = !EditorApplication.isPaused;
    //        #else
    //        enabled = true;
    //        #endif
    //    }
    //    private void OnBecameInvisible()
    //    {
    //        enabled = false;
    //    }
    //    private void OnEnable()
    //    {
    //        rb.WakeUp();
    //    }
    //    private void OnDisable()
    //    {
    //        rb.velocity = Vector2.zero;
    //        rb.Sleep();
    //    }

    void Update()
    { 
        float playerPositionX = player.transform.position.x;
        float playerPositionY = player.transform.position.y;
        if (playerPositionX >= 22.5f)
        {
            rb.gravityScale = 30f;
        }

        if (playerPositionX >= 35.3f && playerPositionX <= 37.5f && playerPositionY <= 2.2)
        {
            wall1.transform.position = new Vector3(35f,1f,0);
            wall2.transform.position = new Vector3(38f, 1f, 0);
        }
        //if (Input.GetKeyDown("z"))
        //{
        //    rb.transform.position = new Vector3();
        //}


    }

    //    private void FixedUpdate()
    //    {
    //        velocity.x = direction.x * speed;
    //        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

    //        //rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

    //        //if (rb.Raycast(direction))
    //        //{
    //        //    rb.gravityScale = 5f;
    //        //}

    //        //if (rb.Raycast(Vector2.down))
    //        //{
    //        //    rb.gravityScale = 5f;
    //        //}

    //        if (direction.x > 0f)
    //        {
    //            rb.gravityScale = 5f;
    //        }
    //        else if (direction.x < 0f)
    //        {
    //            rb.gravityScale = 5f;
    //        }
    //    }

}
