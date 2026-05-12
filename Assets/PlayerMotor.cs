using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    public float dashForce = 10;
    public float dashTime = 0.5f;
    private bool canJump = true;
    private Rigidbody2D rigidbody2D;
    public float speed = 10;
    public float maxSpeed = 10;
    public float jumpForce = 10;
    public float stoppingForce = 5;
    private bool _isDashing = false;
    private int _JumpCount = 0;
    public int maxJumpCount = 2;

    public float Jumpforce = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        NewMethod();
    }

    private void NewMethod()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
        if(_isDashing)
        { return; } 
        if (rigidbody2D.linearVelocityX >= maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }
        else if (rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
        }

        PlayerStopping();
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)

        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * Jumpforce, ForceMode2D.Impulse);
            _JumpCount++;
            if(_JumpCount >= maxJumpCount)
            {
                canJump = false;
            }

        }

    }

    private void OnDash()
    {
        
        if (_isDashing)

        {
            return;
        }
        _isDashing = true;
        rigidbody2D.AddForce(new Vector2(direction.x * dashForce, 0), ForceMode2D.Impulse);
        Debug.Log(direction.x * dashForce);
        StartCoroutine(ResetDash(1));
        

    }

    IEnumerator ResetDash(float timeToReset)
    {
        yield return new WaitForSeconds(timeToReset);
        _isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        _JumpCount = 0;

    }
}
