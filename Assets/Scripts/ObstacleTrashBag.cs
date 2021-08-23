using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrashBag : MonoBehaviour
{
	enum EnemyType
	{
		Recyclable,
		Decomposable,
		NonDecomposable,
		Any
	};

	[SerializeField] EnemyType enemyType;

	SpriteRenderer spriteRenderer;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();

		switch(enemyType)
		{
			case EnemyType.Any:
				spriteRenderer.color = Color.white;
				break;
			case EnemyType.Recyclable:
				spriteRenderer.color = Color.green;
				break;
			case EnemyType.Decomposable:
				spriteRenderer.color = Color.blue;
				break;
			case EnemyType.NonDecomposable:
				spriteRenderer.color = Color.red;
				break;
		}
	}

	public void TakeDamage(string PlayerAttackType)
	{
		if(enemyType == EnemyType.Any)
		{
			Destroy(gameObject);
		}
		else
		{
			if (enemyType.ToString() == PlayerAttackType)
			{
				Destroy(gameObject);
			}
		}
	}
}
