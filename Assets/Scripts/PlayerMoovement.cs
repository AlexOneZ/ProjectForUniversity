using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoovement : MonoBehaviour
{
    public float runSpeed = 20f;
    public float horizontalMoove = 0;
    Rigidbody2D rb;
    Transform playerTransform;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float checkRadius = 1f;
    public float jumpForce = 150f;
    public int jumpAmount = 2;
    public bool isJump = false;
    bool isGround = false, isRight = true;

    Animator anim;

    public GameObject jumpEffect;
    bool isJumpEffect;

    AudioSource audios;
    public AudioClip jumpSound, finishSound, dethSound, enemeyDamageSound,
        fruitSound, damageGetSound, bonusSound;

    public bool ISRight
    {
        get { return isRight; }
    }

    private void Awake()
    {
        audios = GetComponent<AudioSource>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
#if UNITY_STANDALONE_OSX || UNITY_STANDALONE
        horizontalMoove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
#endif
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (!isGround) isJumpEffect = true;
        else GenerateJumpEffect();

    }

    private void FixedUpdate()
    {
        Moove();
    }

    private void Moove()
    {
#if UNITY_STANDALONE_OSX || UNITY_STANDALONE
        rb.velocity = new Vector2(horizontalMoove, rb.velocity.y);      
        if (horizontalMoove < 0 && isRight)
        {
            FlipCharacter();
        }
        else if (horizontalMoove > 0 && !isRight)
        {
            FlipCharacter();
        }
#endif
        rb.velocity = new Vector2(horizontalMoove, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(horizontalMoove));
        if (isGround && isJump)
        {
            jumpAmount = 2;
        }
        if (jumpAmount > 0 && isJump)
        {
            //rb.AddForce(new Vector2(0f, jumpForce));
            anim.SetBool("isJump", true);
            PlaySound(jumpSound);
            rb.velocity = Vector2.up * jumpForce;
            jumpAmount--;
            isJump = false;
        }
        else
        {
            anim.SetBool("isJump", false);
        }
    }

    public void PlaySound(AudioClip ac)
    {
        audios.PlayOneShot(ac);
    }

    public void FlipCharacter()
    {
        isRight = !isRight;
        playerTransform.Rotate(0f, 180f, 0f);
    }

    private void GenerateJumpEffect()
    {
        if (isJumpEffect)
        {
            anim.SetBool("isJump", false);
            isJumpEffect = false;
            GameObject go = Instantiate(jumpEffect);
            go.transform.position = groundCheck.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Traps")
        {
            this.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
        else if (collision.gameObject.tag == "dethzone")
        {
            this.gameObject.GetComponent<PlayerHealth>().DethZone();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dethzone")
        {
            this.gameObject.GetComponent<PlayerHealth>().DethZone();
        }
        else if (collision.gameObject.tag == "projectile")
        {
            this.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

}
