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
    public int numChips;
    bool isLeft = true;
    public GameObject circuit;
    AudioSource sfx;
    public AudioClip death;
    public AudioClip collect;


    //public int deaths;

    // Start is called before the first frame update
    void Start()
    {
        //this.numChips = 0;

        physics = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
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
    public void getChip() {
        
        numChips = numChips+1;

        Debug.Log("Chip count updated: " + GetNumChips());
    }

    public int GetNumChips() {
        return numChips;
    }
    IEnumerator RespawnAfterWait() {
        yield return new WaitForSeconds(0.30f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Bug") {
            Debug.Log("Collided With Bug!!");
            sfx.PlayOneShot(death, 0.7f);
            StartCoroutine(RespawnAfterWait());  
        } 
        if (collision.tag == "Collectable") {
            getChip();
            sfx.PlayOneShot(collect, 0.7f);
        }
    }
}
