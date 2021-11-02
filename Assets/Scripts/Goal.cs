using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
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
    // Handle Level Progression.
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (scr.GetNumChips() >= 14) {
                if(SceneManager.GetActiveScene().buildIndex < 2) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                }
            }
        }
    }
}
