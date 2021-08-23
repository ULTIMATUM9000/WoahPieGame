using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoBrickBehavior : MonoBehaviour
{
	[SerializeField] GameObject EcoBrickExplosionEffect;

	public float speed = 4f;
	float DestroyTime = 2.5f;
	[SerializeField] float explosionRadius = 2;
	[SerializeField] LayerMask enemyLayers;

	[SerializeField] float knockbackStrength = 1.5f;

	Vector3 shootDir;

	private void Start()
	{
		Destroy(gameObject, DestroyTime);
	}
	public void Setup(Vector3 shootDir)
	{
		this.shootDir = shootDir;
	}
	public void Update()
	{
		transform.position += shootDir * speed * Time.deltaTime;
	}

	void ExplosionRadius()
	{
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyLayers);

		foreach (Collider2D enemy in hitEnemies)
		{
			if (enemy != null)
			{
				enemy.GetComponent<EnemyHealth>().EcoBrickKnockBack(this.gameObject, knockbackStrength);
			}
		}
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("ENEMY"))
		{
			ContactPoint2D contact = collision.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			Instantiate(EcoBrickExplosionEffect, pos, rot);
			ExplosionRadius();
		}
	}
}
