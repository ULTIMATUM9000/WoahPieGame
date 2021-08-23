using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoBrick : MonoBehaviour
{
	PlayerAttack playerAttack;
    [SerializeField] Transform EcoBrickProjectile;

	private void Start()
	{
		playerAttack = GetComponentInParent<PlayerAttack>();
	}

	private void Update()
	{
		CheckInput();
	}

    void CheckInput()
	{
		if (Input.GetMouseButtonDown(1) && ItemManager.instance.EcoBricks > 0)
		{
			Debug.Log("Eco Brick Used");
			ThrowEcoBrick();
			ItemManager.instance.EcoBricks -= 1;
		}
	}

	void ThrowEcoBrick()
    {
        Transform bulletTransform = Instantiate(EcoBrickProjectile, playerAttack.attackPoint.position, Quaternion.identity);
        Vector3 shootDir = (playerAttack.attackPoint.position - this.transform.position).normalized;
        bulletTransform.GetComponent<EcoBrickBehavior>().Setup(shootDir);
		AudioManager.instance.Play("EcoBrickSFX");
    }
}
