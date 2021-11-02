using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    bool isLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isLeft) {
            transform.position = transform.position + new Vector3(-3,0,0) * Time.deltaTime;
        }
        else {
            transform.position = transform.position + new Vector3(3,0,0) * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        isLeft = !isLeft;
    }
}
