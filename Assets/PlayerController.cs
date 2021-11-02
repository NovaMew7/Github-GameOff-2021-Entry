using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D physics;
    public float speed;
    Animator animator;
    Vector3 velocity;

    bool isLeft = true;    

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(0,0,0);
        
        if (Input.GetKey(KeyCode.W)) {
            velocity.y+=speed * Time.deltaTime;
            animator.Play("Walk_U");
            animator.enabled = true;
        } else 
        if (Input.GetKey(KeyCode.A)) {
            velocity.x-=speed * Time.deltaTime;
            
            animator.Play("Walk_L");
            animator.enabled = true;
            isLeft = true;
            
        } else
        if (Input.GetKey(KeyCode.S)) {
            velocity.y-=speed * Time.deltaTime;
            animator.Play("Walk_D");
            animator.enabled = true;
        } else
        if (Input.GetKey(KeyCode.D)) {
            velocity.x+=speed * Time.deltaTime;
            animator.Play("Walk_L");
            animator.enabled = true;
            isLeft = false;
        } else {
            animator.enabled = false;
        }
        if (isLeft){
            transform.localScale = new Vector3(1,1,1);
        } else {
            transform.localScale = new Vector3(-1,1,1);
        }
        transform.position = transform.position + velocity;
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Bug") {
            Debug.Log("Collided With Bug!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
