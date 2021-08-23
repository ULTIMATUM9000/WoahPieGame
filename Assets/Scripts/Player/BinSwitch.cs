using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinSwitch : MonoBehaviour
{
    public int selectedWeapon = 0;
    PlayerAttack playerAttack;

	private void Start()
	{
        playerAttack = GetComponentInParent<PlayerAttack>();
	}

	void Update()
    {
        WeaponSwitch();
        BinColorSwitch();
    }

    void WeaponSwitch()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.Q) && !playerAttack.isAttacking)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && !playerAttack.isAttacking)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

    }

    void BinColorSwitch()
    {
        switch (selectedWeapon)
        {
            case 0: // Green Bin
                playerAttack.GreenBin = true;
                playerAttack.BlueBin = false;
                playerAttack.RedBin = false;
                break;
            case 1: //Red Bin
                playerAttack.GreenBin = false;
                playerAttack.BlueBin = true;
                playerAttack.RedBin = false;
                break;
            case 2: //Blue Bin
                playerAttack.GreenBin = false;
                playerAttack.BlueBin = false;
                playerAttack.RedBin = true;
                break;
        }
    }

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform bin in transform)
        {
            if (i == selectedWeapon)
            {
                bin.gameObject.SetActive(true);
            }
            else
            {
                bin.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
