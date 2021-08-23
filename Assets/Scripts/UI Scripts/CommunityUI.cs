using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommunityUI : MonoBehaviour
{
    [SerializeField] private Button[] donateButtons;

    [SerializeField] private Slider[] donatedAmmount;

    [SerializeField] private TextMeshProUGUI[] toDonateAmount;

    [SerializeField] private Image[] CommunityBG;

    [SerializeField] private Sprite[] CommunityMaxedBG;

	private void Update()
    {
        UpdateToDonateAmount();
        UpdateCommunityBarValue();
        ButtonFunctionality();
        UpdateCommunityBackground();
    }

    void UpdateToDonateAmount()
	{
        toDonateAmount[0].SetText("x " + ItemManager.instance.EcoBricks);
        toDonateAmount[1].SetText("x " + ItemManager.instance.Carpet);
        toDonateAmount[2].SetText("x " + ItemManager.instance.BaseballBat);
        toDonateAmount[3].SetText("x " + ItemManager.instance.SkateBoard);
    }

    void UpdateCommunityBarValue()
	{
        donatedAmmount[0].value = ItemManager.instance.DonatedEcoBricksAmount; //Donated Eco Brick 
        donatedAmmount[1].value = ItemManager.instance.DonatedCarpetAmount; //Donated Carpet
        donatedAmmount[2].value = ItemManager.instance.DonatedBaseballBat; //Donated Base Ball Bat 
        donatedAmmount[3].value = ItemManager.instance.DonatedSkateBoardAmount; //Donated Skate Board 
	}

    void ButtonFunctionality()
	{
        if(ItemManager.instance.DonatedEcoBricksAmount == ItemManager.instance.MaxDonatedEcoBricksAmount)
		{
            donateButtons[0].interactable = false;
		}
        if(ItemManager.instance.DonatedEcoBricksAmount != ItemManager.instance.MaxDonatedEcoBricksAmount)
		{
            donateButtons[0].interactable = true;
		}
        
        if(ItemManager.instance.DonatedCarpetAmount == ItemManager.instance.MaxDonatedCarpetAmount)
		{
            donateButtons[1].interactable = false;
		}
        if(ItemManager.instance.DonatedCarpetAmount != ItemManager.instance.MaxDonatedCarpetAmount)
		{
            donateButtons[1].interactable = true;
		}
        
        if(ItemManager.instance.DonatedBaseballBat == ItemManager.instance.MaxDonatedBaseballBat)
		{
            donateButtons[2].interactable = false;
		}
        if(ItemManager.instance.DonatedBaseballBat != ItemManager.instance.MaxDonatedBaseballBat)
		{
            donateButtons[2].interactable = true;
		}

        if (ItemManager.instance.DonatedSkateBoardAmount == ItemManager.instance.MaxDonatedSkateBoardAmount)
        {
            donateButtons[3].interactable = false;
        }
        if (ItemManager.instance.DonatedSkateBoardAmount != ItemManager.instance.MaxDonatedSkateBoardAmount)
        {
            donateButtons[3].interactable = true;
        }
    }

    void UpdateCommunityBackground()
	{
        if (ItemManager.instance.DonatedEcoBricksAmount == ItemManager.instance.MaxDonatedEcoBricksAmount)
        {
            CommunityBG[0].sprite = CommunityMaxedBG[0];
        }
        if (ItemManager.instance.DonatedSkateBoardAmount == ItemManager.instance.MaxDonatedSkateBoardAmount)
        {
            CommunityBG[1].sprite = CommunityMaxedBG[1];
        }
        if (ItemManager.instance.DonatedBaseballBat == ItemManager.instance.MaxDonatedBaseballBat)
        {
            CommunityBG[2].sprite = CommunityMaxedBG[2];
        }
        if (ItemManager.instance.DonatedCarpetAmount == ItemManager.instance.MaxDonatedCarpetAmount)
        {
            CommunityBG[3].sprite = CommunityMaxedBG[3];
        }
    }

	#region Community Screen Button Functions
	public void DonateEcoBrick()//Hard Code Muna
    {
        if (ItemManager.instance.EcoBricks > 0)
        {
            ItemManager.instance.DonatedEcoBricksAmount += 1;
            ItemManager.instance.EcoBricks -= 1;
            //Debug.Log("Donated all Eco Bricks");
            //AudioManager.instance.Play("DonateTemp");
        }
    }
    public void DonateCarpet()
    {
        if (ItemManager.instance.Carpet > 0)
        {
            ItemManager.instance.DonatedCarpetAmount += 1;
            ItemManager.instance.Carpet -= 1;
            //Debug.Log("Donated all Carpet");
            //AudioManager.instance.Play("DonateTemp");
        }
    }

    public void DonateSkateBoard()
    {
        if (ItemManager.instance.SkateBoard > 0)
        {
            ItemManager.instance.DonatedSkateBoardAmount += 1;
            ItemManager.instance.SkateBoard -= 1;
            //Debug.Log("Donated all Skate Boards");
            //AudioManager.instance.Play("DonateTemp");
        }
    }
    
    public void DonateBaseballBat()//Hard Code Muna
    {
        if (ItemManager.instance.BaseballBat > 0)
        {
            ItemManager.instance.DonatedBaseballBat += 1;
            ItemManager.instance.BaseballBat -= 1;
            //Debug.Log("Donated all Skate Boards");
            //AudioManager.instance.Play("DonateTemp");
        }
    }
    #endregion
}
