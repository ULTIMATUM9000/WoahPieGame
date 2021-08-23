using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Player
{
    [SerializeField] GameObject PlayerHitEffect;

    public int MaxHealth;
    public int CurrentHealth;
    int CardboardHealth;

    private SpriteRenderer spriteRenderer;

	private void Start()
	{
        CurrentHealth = MaxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        CardboardHealth = ItemManager.instance.CardboardHeart;
        IsAlive();
    }

    void IsAlive()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            GAME_MANAGER.instance.playerDead = true;
            CanvasManager.Instance.SecondaryCanvas(CanvasType.GameOver);
        }
        else
            return;
    }

    public void TakeDamage(int damage)
	{
        if(CardboardHealth > 0)
		{
            CardboardHealth -= damage;
            ItemManager.instance.CardboardHeart -= damage;
        }
		else
		{
            CurrentHealth -= damage;
        }

        spriteRenderer.color = Color.red;
        AudioManager.instance.Play("PlayerHit");
        Instantiate(PlayerHitEffect, this.gameObject.transform);
        Invoke("ResetColor", 0.25f);
    }

    void ResetColor()
	{
        spriteRenderer.color = Color.white;
	}

	//private void OnCollisionEnter2D(Collision2D collision)
 //   {
 //       //Debug.Log("COLLISSION WITH " + collision.name);
 //       if (collision.gameObject.CompareTag("ENEMY"))
 //       {
 //           TakeDamage(1);
 //           IsAlive(); //check if player has 0 health
 //           //Debug.Log("Health: " + CurrentHealth + "/" + MaxHealth);
 //       }
 //   }
}
