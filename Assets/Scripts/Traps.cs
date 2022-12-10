using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Traps : MonoBehaviour
{

    private Rigidbody2D rb;
    private GameObject player;
    private GameObject wall1, wall2, spikeTrap1, spikeTrap2, spikeTrap3, hiddenBlock;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        wall1 = GameObject.FindGameObjectWithTag("WallTrap1");
        wall2 = GameObject.FindGameObjectWithTag("WallTrap2");

        spikeTrap1 = GameObject.FindGameObjectWithTag("SpikeTrap1");
        spikeTrap2 = GameObject.FindGameObjectWithTag("SpikeTrap2");
        spikeTrap3 = GameObject.FindGameObjectWithTag("SpikeTrap3");

        hiddenBlock = GameObject.FindGameObjectWithTag("QuestionBlock");

        //enabled = false;
    }

    private void Start()
    {
        spikeTrap1.SetActive(false);
        spikeTrap2.SetActive(false);
        hiddenBlock.SetActive(false);
    }

    void Update()
    {
        Trap();
    }

    private void Trap()
    {
        float playerPositionX = player.transform.position.x;
        float playerPositionY = player.transform.position.y;
        if (playerPositionX >= 23f)
        {
            rb.gravityScale = 30f;
            if (rb.position.y <= 0)
            {
                hiddenBlock.SetActive(true);
            }

        }

        if (playerPositionX >= 35.3f && playerPositionX <= 37.5f && playerPositionY <= 2.2)
        {
            wall1.transform.position = new Vector3(35f, 1f, 0);
            wall2.transform.position = new Vector3(38f, 1f, 0);
        }

        if (playerPositionX >= 28.3f && playerPositionX <= 33.5f && playerPositionY <= 0.1)
        {
            spikeTrap1.SetActive(true);
        }

        if (playerPositionX >= 34f && playerPositionX <= 39f && playerPositionY <= 0.1)
        {
            spikeTrap2.SetActive(true);
        }
    }
}
