using UnityEngine;

public class HandPivot : MonoBehaviour
{
    [SerializeField] private Hand hand;
    [SerializeField] Player player;
    [SerializeField] private SpriteRenderer handSpriteRenderer;

    private SpriteRenderer handItem;

    private void Start()
    {
        handItem = hand.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            Vector3 worldMousePosition = player.mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Vector3 handPivotDir = Vector3.Normalize(worldMousePosition - transform.position);

            float handPivotEulerAngle = Mathf.Rad2Deg * Mathf.Atan2(handPivotDir.y, handPivotDir.x);

            transform.eulerAngles = new Vector3(0, 0, handPivotEulerAngle);

            handItem.transform.eulerAngles = transform.eulerAngles;
        }
    }
}
