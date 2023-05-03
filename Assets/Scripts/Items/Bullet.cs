using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public Vector2 dir;

    private static float damage = 20;

    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position += new Vector3(dir.x, dir.y, 0) * speed * Time.deltaTime;

        spriteRenderer.transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x));

        if (transform.position.x > 100 ||
            transform.position.x < -100 ||
            transform.position.y > 100 ||
            transform.position.y < -100)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Slime slime = collision.gameObject.GetComponent<Slime>();
            slime.Hit(damage);

            Destroy(gameObject);
        }
    }
}
