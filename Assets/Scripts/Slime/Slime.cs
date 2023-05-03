using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private GameObject visual;
    [SerializeField] private SlimeSeeArea slimeSeeArea;
    [SerializeField] private SlimeHurtArea slimeHurtArea;

    private float health = 30;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D slimeRigidbody;
    private Vector2 movementVector;


    private float changeDirectionTime = 1;
    private float changeDirectionElapsedTime = 0;
    private float speed;

    private float hitDelay = 0.5f;
    private float hitDelayElapsedTime = 0;

    private float damage = 10;

    private void Start()
    {

        Invoke("ChangeDirection", Random.Range(0f, 2f));

        animator = visual.GetComponent<Animator>();
        slimeRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = visual.GetComponent<SpriteRenderer>();
        movementVector = Vector2.zero;

        speed = Random.Range(3, 7);
        animator.SetFloat("walkSpeed", speed / 5f);
    }

    private void ChangeDirection()
    {
        if (slimeSeeArea.player != null)
        {
            movementVector = Vector3.Normalize(slimeSeeArea.player.transform.position - transform.position);
        }
        else
        {
            movementVector = Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector2(1, 0);
        }
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (slimeHurtArea.player != null)
            {
                if (hitDelayElapsedTime > hitDelay)
                {
                    slimeHurtArea.player.Hit(damage);

                    hitDelayElapsedTime = 0;
                }

                hitDelayElapsedTime += Time.deltaTime;
            }


            if (changeDirectionElapsedTime > changeDirectionTime)
            {
                Invoke("ChangeDirection", Random.Range(0f, 1f));
                changeDirectionElapsedTime = 0f;
            }

            changeDirectionElapsedTime += Time.deltaTime;

            if (movementVector.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (movementVector.x > 0)
            {
                spriteRenderer.flipX = true;
            }

            animator.SetBool("isWalking", movementVector != Vector2.zero);

            if (health < 0)
            {
                Global.killsCount += 1;

                if (Global.time > 60)
                {
                    Global.time = 60;
                }

                Destroy(gameObject);
            }
        }
    }

    public void Hit(float damage)
    {
        health -= damage;

        if (!animator.GetBool("isHit"))
        {
            animator.SetBool("isHit", true);
        }
    }

    private void FixedUpdate()
    {
        slimeRigidbody.velocity = movementVector * speed * Time.deltaTime * 100;
    }
}
