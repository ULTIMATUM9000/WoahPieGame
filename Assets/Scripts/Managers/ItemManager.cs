using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] TextMeshProUGUI[] ItemText; // UI for current values of usable items
    [SerializeField] Button[] CraftingButtons; //UI Buttons

    [Space]
    //ITEM PICKUPS
    public int plastic;
    public int aluminum;
    public int glass;
    public int paper;

    int originalplastic;
    int originalaluminum;
    int originalglass;
    int originalpaper;

    [Space]
    //RECYCLING ITEM OUTPUTS
    public int recycledPlastic;
    public int recycledAluminum;
    public int recycledPaper;
    public int recycledGlass;

    int originalrecycledPlastic;
    int originalrecycledAluminum;
    int originalrecycledPaper;
    int originalrecycledGlass;

    //amount of the crafted usable items, yung mga eco bombs and stuff, dagdag nlang
    [Space]
    public int EcoBricks;
    public int Carpet;
    public int BaseballBat;

    int originalEcoBricks;
    int originalCarpet;
    int originalBaseballBat;

    [Space] //Passive Powerups;
    public int SkateBoard;
    int originalSkateBoard;

    public int CardboardHeart, MaxCardboardHeart;

    [Space] //Current Donated Stuff
    public int DonatedEcoBricksAmount;
    public int DonatedCarpetAmount;
    public int DonatedSkateBoardAmount;
    public int DonatedBaseballBat;

    [Space] //Maximum Donated Stuff
    public int MaxDonatedEcoBricksAmount;
    public int MaxDonatedCarpetAmount;
    public int MaxDonatedSkateBoardAmount;
    public int MaxDonatedBaseballBat;

    public void InitializeData() //call this function when starting a level or resetting
	{
        plastic = originalplastic;
        paper = originalpaper;
        glass = originalglass;
        aluminum = originalaluminum;

        recycledPlastic = originalrecycledPlastic;
        recycledPaper = originalrecycledPaper;
        recycledGlass = originalrecycledGlass;
        recycledAluminum = originalrecycledAluminum;

        EcoBricks = originalEcoBricks;
        Carpet = originalCarpet;
        BaseballBat = originalBaseballBat;
        SkateBoard = originalSkateBoard;
    }

    public void UpdateData() //call this function when starting the next level
	{
        originalplastic += plastic;
        originalpaper += paper;
        originalglass += glass;
        originalaluminum += aluminum;

        originalrecycledAluminum += recycledAluminum;
        originalrecycledGlass += recycledGlass;
        originalrecycledPaper += recycledPaper;
        originalrecycledPlastic += recycledPlastic;

        originalEcoBricks += EcoBricks;
        originalCarpet += Carpet;
        originalBaseballBat += BaseballBat;
        originalSkateBoard += SkateBoard;
	}

	private void Update()
	{
        UpdateGameUI();
        ControlButtons();
	}

	void UpdateGameUI() // Hard Code ko muna
	{
        ItemText[0].SetText("x" + EcoBricks.ToString());
        ItemText[1].SetText("x" + Carpet.ToString());
        ItemText[2].SetText("x" + BaseballBat.ToString());
	} 

    void ControlButtons() //Hard Code rin muna to, looking for a better solution
	{
        if(recycledPlastic > 2 && recycledGlass > 1) //EcoBrick Craft Button
		{
            CraftingButtons[0].interactable = true;
		}
        else
		{
            CraftingButtons[0].interactable = false;
        }
        
        if(recycledPlastic > 3) //Carpet Button
		{
            CraftingButtons[1].interactable = true;
		}
        else
		{
            CraftingButtons[1].interactable = false;
        }
        
        if(recycledAluminum > 2) //Baseball Bat
		{
            CraftingButtons[2].interactable = true;
		}
        else
		{
            CraftingButtons[2].interactable = false;
        }
        
        if(recycledPlastic > 2 && recycledAluminum > 2) //Skateboard
		{
            CraftingButtons[3].interactable = true;
		}
        else
		{
            CraftingButtons[3].interactable = false;
        }
        
        if(recycledPaper > 3 && CardboardHeart < MaxCardboardHeart) //Cardboard Heart
		{
            CraftingButtons[4].interactable = true;
		}
        else
		{
            CraftingButtons[4].interactable = false;
        }

        
    }

    //name of function subject to change
    #region Crafting Buttons
    public void CraftEcoBricks()
	{
        if (recycledPlastic > 2 && recycledGlass > 1)
        {
            recycledPlastic -= 2;
            recycledGlass -= 1;
            EcoBricks += 1;
            GAME_MANAGER.instance.currentMaterialsRecycled += 3;
            GAME_MANAGER.instance.currentCraftedItems += 1;
            AudioManager.instance.Play("CraftedItem");
            return;
        }
	}
    public void CraftCarpet()
	{
        if (recycledPlastic > 3)
        {
            recycledPlastic -= 3;
            Carpet += 1;
            GAME_MANAGER.instance.currentMaterialsRecycled += 3;
            GAME_MANAGER.instance.currentCraftedItems += 1;
            AudioManager.instance.Play("CraftedItem");
            return;
        }
	}
    public void CraftBaseballBat()
	{
        if (recycledAluminum > 2)
        {
            recycledAluminum -= 2;
            BaseballBat += 1;
            GAME_MANAGER.instance.currentMaterialsRecycled += 2;
            GAME_MANAGER.instance.currentCraftedItems += 1;
            AudioManager.instance.Play("CraftedItem");
            return;
        }
	}
    public void CraftSkateBoard()
    {
        if (recycledPlastic > 2 && recycledAluminum > 2)
        {
            recycledPlastic -= 2;
            recycledAluminum -= 2;
            SkateBoard += 1;
            GAME_MANAGER.instance.currentMaterialsRecycled += 4;
            GAME_MANAGER.instance.currentCraftedItems += 1;
            AudioManager.instance.Play("CraftedItem");
            return;
        }
    }
    public void CraftCardboardHeart()
	{
        if (recycledPaper > 3 && CardboardHeart < MaxCardboardHeart)
        {
            recycledPaper -= 3;
            CardboardHeart += 1;
            GAME_MANAGER.instance.currentMaterialsRecycled += 3;
            GAME_MANAGER.instance.currentCraftedItems += 1;
            AudioManager.instance.Play("CraftedItem");
            return;
        }
	}
    #endregion
}
