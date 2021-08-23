using UnityEngine;

public class Player : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;

    private string currentState;

    public const string PLAYER_IDLE = "Idle";
    public const string PLAYER_MOVE = "Move";
    public const string PLAYER_DIE = "Die";

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeAnimationState(string newState)
    {
        if (newState != null)
		{
            //stop the same animation from interrupting itself
            if (currentState == newState) 
                return;

            //reassing the current state
            currentState = newState;
            //play the animation
            animator.Play(newState, 0);
        }
        return;
    }
}
