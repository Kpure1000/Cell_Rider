using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBackSimple : MonoBehaviour
{
	public bool isTimeBacking;

	public struct ObjectState
	{
		public Vector2 position;
		public Sprite sprite;
		AnimatorStateInfo state;
		public ObjectState(Vector2 tr, Sprite sp, AnimatorStateInfo stateinfo)
		{
			position = tr;
			sprite = sp;
			state = stateinfo;
		}
	}

	public Stack<ObjectState> objectStates = new Stack<ObjectState>();

	public SpriteRenderer spriteRender;

	public Animator animator;

	private void Update()
	{
		//回溯
		if(Input.GetKey(KeyCode.LeftControl))
		{
			isTimeBacking = true;

			if (objectStates.Count <= 1) return;

			animator.enabled = false;

			transform.position = objectStates.Peek().position;
			spriteRender.sprite = objectStates.Peek().sprite;
			objectStates.Pop();
		}
		else
		{
			isTimeBacking = false;

			animator.enabled = true;

			objectStates.Push(new ObjectState(transform.position, spriteRender.sprite,animator.GetCurrentAnimatorStateInfo(0)));
		}

	}
}
