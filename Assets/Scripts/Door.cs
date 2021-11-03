using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
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

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Has Key: " + scr.getKey());
        if (collision.gameObject.tag == "Player" && scr.getKey()) {
            Destroy(gameObject);
        }
    }
}
