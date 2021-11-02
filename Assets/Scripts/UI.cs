using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public GameObject player;
    PlayerController _player;
    private Text txt;
    // Start is called before the first frame update
    void Start()
    {
        _player = player.GetComponent<PlayerController>();
        txt = gameObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Debug: " + _player.GetNumChips().ToString());
        txt.text = "Circuits: " + _player.GetNumChips().ToString();
    }
}
