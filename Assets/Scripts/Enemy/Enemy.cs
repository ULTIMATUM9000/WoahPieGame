using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	#region Animation States
	protected Animator animator;
	private string currentState;

	protected const string MOVE = "Move";
	protected const string ATTACK = "Attack";
	protected const string DIE = "Die";
	protected const string HURT = "Hurt";
	protected const string IDLE = "Idle";
	#endregion

	protected GameObject Player;
	protected Rigidbody2D rb;
	protected Vector2 movement;

	protected bool isMoving;
	protected bool isAttacking;

	protected void Start()
	{
		Player = GameObject.FindGameObjectWithTag("PLAYER");
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

		ChangeAnimationState(IDLE);
	}

	protected void Update()
	{
		if(Player == null)
		{
			Player = GameObject.FindGameObjectWithTag("PLAYER");
		}
	}

	#region ANIMATOR HELL
	protected void ChangeAnimationState(string newState)
    {
		//stop the same animation from interrupting itself
		if (currentState == newState) return;

		//play the animation
		animator.Play(newState, 0);

		//reassing the current state
		currentState = newState;
	}
	
	//ChangeAnimationState(CHASE);
	//ChangeAnimationState(ATTACK);
	#endregion

	
}
