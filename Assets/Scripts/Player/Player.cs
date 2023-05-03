using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject visual;
    [SerializeField] private HandPivot handPivot;
    [SerializeField] private Hand hand;
    [SerializeField] private GameObject gunHoldPosition;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text killsCount;
    [SerializeField] private AudioSource bulletFireSound;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TMP_Text loseOrWin;
    [SerializeField] private TMP_Text endScreenKillCount;
    [SerializeField] private GameObject tutorial;

    private float fireDelay = 0.5f;
    private float fireElapsedTime = 0;
    private float second = 1f;
    private float secondElapsedTime = 0f;

    public Camera mainCamera;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D playerRigidbody;
    private Vector2 movementVector;
    private float health = 100;
    private bool keyOnePressed = false;
    private bool keyTwoPressed = false;

    private void Start()
    {
        endScreen.SetActive(false);
        timerText.text = $"Timer: {Global.time}";
        animator = visual.GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = visual.GetComponent<SpriteRenderer>();

        if (Global.isAlreadyTutorial)
        {
            tutorial.SetActive(false);
        }
    }

    private void getInput()
    {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementVector.Normalize();

        if (Input.GetMouseButton(0) && hand.holdType == HoldType.Gun && fireElapsedTime > fireDelay)
        {
            Bullet bullet = Instantiate(Global.bullet);
            bullet.transform.position = gunHoldPosition.transform.position;

            float bulletDirX = Mathf.Cos(Mathf.Deg2Rad * handPivot.transform.eulerAngles.z);
            float bulletDirY = Mathf.Sin(Mathf.Deg2Rad * handPivot.transform.eulerAngles.z);

            bullet.dir = new Vector2(bulletDirX, bulletDirY);

            bulletFireSound.Play();

            fireElapsedTime = 0;
        }
    }

    public void Hit(float damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                keyOnePressed = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                keyTwoPressed = true;
            }

            if (keyOnePressed && keyTwoPressed && !Global.isAlreadyTutorial)
            {
                Global.isAlreadyTutorial = true;
                tutorial.SetActive(false);
            }

            getInput();

            if (movementVector.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (movementVector.x > 0)
            {
                spriteRenderer.flipX = false;
            }

            animator.SetBool("isWalking", movementVector != Vector2.zero);

            healthBar.value = health / 100;

            if (health <= 0)
            {
                animator.Play("Dead");
            }

            if (secondElapsedTime >= second)
            {
                Global.time -= 1;
                timerText.text = $"Timer: {Global.time}";
                secondElapsedTime = 0;
            }

            if (Global.killsCount >= 40)
            {
                Global.time = 0;
            }

            if (Global.time == 0)
            {
                Time.timeScale = 0;

                if (Global.killsCount >= 40)
                {
                    loseOrWin.text = "You Win";
                }
                else
                {
                    loseOrWin.text = "You Lose";
                }

                endScreenKillCount.text = $"You Killed {Global.killsCount} Slimes";
                endScreen.SetActive(true);
            }

            killsCount.text = $"Kills: {Global.killsCount} / 40";

            fireElapsedTime += Time.deltaTime;
            secondElapsedTime += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = movementVector * speed * Time.deltaTime * 100;
    }
}
