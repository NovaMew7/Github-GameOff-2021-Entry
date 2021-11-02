using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    public GameObject player;
    PlayerController scr;

    // Start is called before the first frame update
    void Start()
    {
        scr = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Player") {
            Debug.Log("Collected Chip!");
            scr.getChip();
            Destroy(gameObject);
        }

    }
}
