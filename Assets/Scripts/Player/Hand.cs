using UnityEngine;

public class Hand : MonoBehaviour
{
    public HoldType holdType;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private HandPivot handPivot;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        holdType = HoldType.None;
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                holdType = HoldType.Sword;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                holdType = HoldType.Gun;
            }



            switch (holdType)
            {
                case HoldType.None:
                    spriteRenderer.sprite = null;
                    break;

                case HoldType.Sword:
                    spriteRenderer.sprite = Global.sword;
                    break;

                case HoldType.Gun:
                    spriteRenderer.sprite = Global.gun;

                    if (handPivot.transform.eulerAngles.z > 90)
                    {
                        spriteRenderer.flipY = true;
                    }

                    if (handPivot.transform.eulerAngles.z > 270)
                    {
                        spriteRenderer.flipY = false;
                    }

                    if (handPivot.transform.eulerAngles.z < 90)
                    {
                        spriteRenderer.flipY = false;
                    }
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Slime slime = collision.gameObject.GetComponent<Slime>();
            slime.Hit(10);
        }
    }
}
