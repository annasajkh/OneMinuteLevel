using UnityEngine;

public class SlimeHurtArea : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Player>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
        }
    }
}
