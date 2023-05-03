using UnityEngine;

public class SlimeVisual : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void ResetHit()
    {
        animator.SetBool("isHit", false);
    }
}
