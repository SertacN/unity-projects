using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudioSource;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10f;
    public float doubleJumpForce = 5f;
    public float gravityModifier;
    public bool gameStart;
    public bool isOnGround = true;
    public bool gameOver;
    public bool isOnDoubleJump;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Start game after short delay
        if(transform.position.x <= 0)
        {
            transform.position = new Vector3(transform.position.x + 2 * Time.deltaTime, 0, 0);
            playerAnim.SetFloat("Speed_f", 0.30f);
        }
        // Start game with full functionality
        if(transform.position.x >= 0)
        {
            gameStart = true;
            PlayerJump();
            PlayerDash();
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(crashSound, 0.5f);
        }
        
    }
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(jumpSound, 0.5f);
            isOnDoubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isOnDoubleJump && !gameOver && !isOnGround)
        {
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            isOnDoubleJump = false;
        }
    }

    void PlayerDash()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnim.SetFloat("Speed_f", 2.5f);
        }
        // Also set Speed_f to 1 for when game started, player run.
        else
        {
            playerAnim.SetFloat("Speed_f", 1);
        }
    }  
}
