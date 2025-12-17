using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    [Header("References")]
    public Transform player;
    public Slider slider;

    [Header("Settings")]
    public float detectRange = 10f;
    public float stopRange = 2f;
    public float moveSpeed = 10f;
    public float distance = 0;
    public bool IsDead = false;

    Animator animator;

    Rigidbody2D rb;
    bool isFacingRight = true;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (player == null) return;

        distance = Vector2.Distance(transform.position, player.position);

        if (distance <= stopRange)
        {

            StopMoving();
            EnemyShooting.instance.Shooting();


        }
        else if (distance <= detectRange)
        {

            MoveTowardPlayer();
        }
        else
        {

            StopMoving();
            EnemyShooting.instance.Shooting();
        }
    }

    void MoveTowardPlayer()
    {
        if (IsDead) return;
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);


        if (direction.x < 0 && !isFacingRight)
            Flip();
        else if (direction.x > 0 && isFacingRight)
            Flip();


        if (animator != null)
            animator.SetInteger("PlayerMode", 1);
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;

        if (animator != null)
            animator.SetInteger("PlayerMode", 0);
    }
    public void TakeDamage(int dmg)
    {
        slider.value -= dmg;

        if (slider.value <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over");
        Destroy(gameObject);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopRange);
    }
}
