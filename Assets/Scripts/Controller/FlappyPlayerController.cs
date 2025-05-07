using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlayerController : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidBody = null;

    private float flapForce = 6f;
    private float forwardSpeed = 3f;
    private bool isDead = false;
    private float deathCooldown = 0f;

    bool isFlap = false;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidBody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    // 게임 재시작
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidBody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidBody.velocity = velocity;

        float angle = Mathf.Clamp(_rigidBody.velocity.y * 10f, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;

        gameManager.GameOver();
    }
}
