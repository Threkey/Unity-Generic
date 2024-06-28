using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;         // ��� �� ����� ����� Ŭ��
    public float jumpForce = 700f;      // ���� ��

    private int jumpCount = 0;          // ���� ���� Ƚ��
    private bool isGrounded = false;    // �ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false;        // ��� ����

    private Rigidbody2D playerRigidbody;// ����� ������ٵ� ������Ʈ
    private Animator animator;          // ����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ�ȭ

        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����� �Է��� �����ϰ� �����ϴ� ó��

        if (isDead)
            return;

        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;

            playerRigidbody.velocity = Vector2.zero;

            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            playerAudio.Play();
        }
        else if(Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        animator.SetBool("Grounded", isGrounded);
    }

    void Die()
    {
        // ��� ó��

        //deathClip
        animator.SetTrigger("Die");

        playerAudio.clip = deathClip;

        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;

        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹 ����
        if (collision.tag == "Dead" && !isDead)
        {
            Die();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // � �ݶ��̴��� �������, �浹 ǥ���� ������ ���� ������
        if(collision.contacts[0].normal.y > 0.7f)
        {
            // isGrounded�� true�� �����ϰ�, ���� ���� Ƚ���� 0���� ����
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        // �ٴڿ��� ������� �����ϴ� ó��
    }
}