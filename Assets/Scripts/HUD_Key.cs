using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Key : MonoBehaviour
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
        gameObject.SetActive(scr.getKey());
    }
}
