using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float left = -2;
    public float right = 2;
    float middle = 0;
    float direction;
    public float speed = 5f;
    public float jumpSpeed = 300;
    Rigidbody rb;
    bool grounded = true;
    public bool isDead = false;
    public static bool isMoving;
    bool slipped = false;
    public float slippedTime = 0.7f;
    BoxCollider coll;
    float startCollCenter, startCollSize;
    
    public AudioClip jumpClip, slipClip, dieClip, moveClip;
    bool sounds;
    Animator anim;
    AudioSource playerSounds;
    public AudioSource coinSound;
    

    Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<BoxCollider>();
        anim = GetComponentInChildren<Animator>();
        playerSounds = GetComponent<AudioSource>();
        

    }



    
    void Start()
    {

        startCollCenter = coll.center.y;
        startCollSize = coll.size.y;
        sounds = MusicScript.playSounds;
        
    }


    void Update()
    {

        if (!isDead)
        {
            if (!slipped)
            {
                if (((Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") == 1) || SwipeController.right) && direction < right && grounded)
                {
                    MoveSound();
                    SwipeController.right = false;
                    //anim.SetTrigger("right");
                    direction += right;
                }

                if (((Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") == -1) || SwipeController.left) && direction > left && grounded)
                {
                    MoveSound();
                    //anim.SetTrigger("left");
                    SwipeController.left = false;
                    direction += left;
                }

                if (((Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") == 1) || SwipeController.jump || Input.GetButtonDown("Jump")) && grounded)
                
                {
                    SwipeController.jump = false;
                    Jump();
                }
            }
            

            if (((Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") == -1) || SwipeController.slip) && grounded)
            
            {
                if (!slipped)
                {
                    slipped = true;
                    SwipeController.slip = false;
                    StartCoroutine(Slip());
                    if (sounds)
                    {
                        playerSounds.clip = slipClip;
                        playerSounds.volume = 1f;
                        playerSounds.Play();
                    }
                }
            }
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, direction, Time.deltaTime * speed), transform.position.y, transform.position.z);
                
    }

    IEnumerator Slip()
    {
        ChangeCollider(0.5f*startCollCenter, 0.5f*startCollSize);
        anim.SetTrigger("slide");
        yield return new WaitForSeconds(slippedTime);
        ChangeCollider(startCollCenter, startCollSize);
        slipped = false;
    }

    void ChangeCollider(float center, float size)
    {
        coll.center = new Vector3(coll.center.x, center, coll.center.z);
        coll.size = new Vector3(coll.size.x, size, coll.size.z);
    }
    

    void OnCollisionStay(Collision coll)
    {
        grounded = true;
        
        
    }

    void OnCollisionExit(Collision coll)
    {
        grounded = false;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            ScoreManagerScript.score++;
            other.gameObject.SetActive(false);
            if (sounds)
            {
                coinSound.Play();
            }
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            isDead = true;
            GameManagerScript.current.GameOver();
            anim.updateMode = AnimatorUpdateMode.UnscaledTime;
            anim.SetTrigger("dead");
            
            MusicScript.bgMusic.Stop();
            Time.timeScale = 0;
            if (sounds)
            {
                playerSounds.clip = dieClip;
                playerSounds.volume = 1f;
                playerSounds.Play();
            }
            
            

        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpSpeed);
        anim.SetTrigger("jump");

        if (sounds)
        {
            playerSounds.clip = jumpClip;
            playerSounds.volume = 1f;
            playerSounds.Play();
            

        }
    }

    void MoveSound()
    {
        if (sounds)
        {
            playerSounds.clip = moveClip;
            playerSounds.volume = 0.7f;
            playerSounds.Play();
        }
    }


}
