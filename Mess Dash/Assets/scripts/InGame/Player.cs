using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Player : MonoBehaviour
{
    Camera cam; 
    Rigidbody2D playerRigidbody2D;
    SpriteRenderer spriteRenderer;

    public GameObject obtacle;
    public GameObject textMove;
    
    private bool isGround = false;
    private int count;
    public int deathCount = 0;
    private float jumpSpeed = 25;
    private float spinSpeed = 0.0045f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine("fGround");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            StartCoroutine("Die");
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            StartCoroutine("Goal");
        }
    }

    void Start()
    {
        cam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (isGround == true)
            {
                playerRigidbody2D.velocity = Vector2.zero;
                isGround = false;

                StartCoroutine("Jump");
            }
        }
        spriteRenderer.color = GameManager.instance.playerColor;
    }
    IEnumerator Jump()
    {
        if (playerRigidbody2D.gravityScale > 0)
        {
            playerRigidbody2D.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);

            while (count < 90)
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 2);
                count++;

                yield return new WaitForSeconds(spinSpeed);
            }
            count = 0;
        }    
        else
        {
            playerRigidbody2D.AddForce(Vector3.up * -jumpSpeed, ForceMode2D.Impulse);

            while (count < 90)
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 2);
                count++;

                yield return new WaitForSeconds(spinSpeed);
            }
            count = 0;
        }        
    }

    IEnumerator Die()
    {
        StopCoroutine("Jump");
        transform.rotation = Quaternion.Euler(0, 0, 0);
        spriteRenderer.enabled = false;
        playerRigidbody2D.velocity = Vector2.zero;
        playerRigidbody2D.simulated = false;
        transform.GetChild(0).gameObject.SetActive(true);
        GameManager.instance.audioSource.Stop();
        obtacle.GetComponent<Obtacle>().enabled = false;
        textMove.GetComponent<TextMove>().moveSpeed = 0;

        yield return new WaitForSeconds(0.5f);

        GameManager.instance.deathCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.audioSource.Play();
    }

    IEnumerator Goal()
    {
        StopCoroutine("Jump");
        transform.rotation = Quaternion.Euler(0, 0, 0);
        spriteRenderer.enabled = false;
        playerRigidbody2D.velocity = Vector2.zero;
        playerRigidbody2D.simulated = false;
        transform.GetChild(1).gameObject.SetActive(true);
        GameManager.instance.audioSource.Stop();

        yield return new WaitForSeconds(1f);

        GameManager.instance.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
    IEnumerator fGround()
    {

        yield return new WaitForSeconds(0.5f);

        isGround = false;
    }
}
