using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GAME_MANAGER : Singleton<GAME_MANAGER>
{
    [SerializeField] TextMeshProUGUI[] SummaryText;

    public bool isPaused = false;
    public bool MapOpened = false;
    public bool inRecyclingUI = false;

    public bool playerDead = false;
    public bool afterScreen = false;

    public bool Level01Clear = false;
    public bool Level02Clear = false;

    [Space]
    public int currentEnemiesMutated, TotalEnemiesMutated;
    [Space]
    public int currentEnemiesDisposed, TotalEnemiesDisposed;
    [Space]
    public int currentMaterialsRecycled, TotalMaterialsRecycled;
    [Space]
    public int currentCraftedItems, TotalCraftedItems;

    [SerializeField] GameObject GameUI; //temp
    [SerializeField] bool isUIOn = true; //temp

    private void Update()
    {
        UIKey(); //temporary

        PauseKey();
        OpenRecyclingUI();
        OpenMap();
        SetSummaryText();
    }

    public void SetSummaryText()
    {
        SummaryText[0].SetText(currentEnemiesMutated.ToString());
        SummaryText[1].SetText(currentEnemiesDisposed.ToString());
        SummaryText[2].SetText(currentMaterialsRecycled.ToString());
    }

    public void SetTotalSummary() //call this everytime a level ends
    {
        TotalEnemiesDisposed += currentEnemiesDisposed;
        TotalEnemiesMutated += currentEnemiesMutated;
        TotalMaterialsRecycled += currentMaterialsRecycled;
        TotalCraftedItems += currentCraftedItems;
    }

    public void ResetCurrentSummary() //call this when starting a new level
	{
        currentEnemiesDisposed = 0;
        currentEnemiesMutated = 0;
        currentMaterialsRecycled = 0;
        currentCraftedItems = 0;
	}


    #region Pause
    public void PauseKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && CheckBeforePausing())
        {
            PauseGame();
        }
        
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused && CheckBeforePausing())
        {
            ResumeGame();
        }
    }

    bool CheckBeforePausing()
    {
        if (!playerDead && !inRecyclingUI && !MapOpened)
        {
            return true;
        }
        else
            return false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        CanvasManager.Instance.SecondaryCanvas(CanvasType.Pause);
        isPaused = true;
        AudioManager.instance.Play("Paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        CanvasManager.Instance.TurnOffSecondaryCanvas(CanvasType.Pause);
        isPaused = false;
        AudioManager.instance.Play("Unpaused");
    }
    #endregion Pause

    void OpenMap()
	{
        if (Input.GetKeyDown(KeyCode.Tab) && NoSecondaryUIOpen())
        {
            CanvasManager.Instance.SecondaryCanvas(CanvasType.MiniMap);
            MapOpened = true;
            Time.timeScale = 0;
        }
    }

    public void ExitMap()
    {
        CanvasManager.Instance.TurnOffSecondaryCanvas(CanvasType.MiniMap);
        MapOpened = false;
        Time.timeScale = 1;
    }

    public void OpenControls()
	{
        CanvasManager.Instance.SecondaryCanvas(CanvasType.Controls);
    }

    #region Recycling
    void OpenRecyclingUI()
    {
        if (Input.GetKeyDown(KeyCode.T) && NoSecondaryUIOpen())
        {
            CanvasManager.Instance.SecondaryCanvas(CanvasType.Recycling);
            Time.timeScale = 0;
            inRecyclingUI = true;
        }
    }

    bool NoSecondaryUIOpen()
	{
        if (!isPaused && !playerDead && !inRecyclingUI && !MapOpened)
        {
            return true;
        }
        else
            return false;
	}

    #endregion Recycling

    void UIKey()
    {
        if (Input.GetKeyDown(KeyCode.F1) && isUIOn)
        {
            CloseUIT();
        }

        else if (Input.GetKeyDown(KeyCode.F1) && !isUIOn)
        {
            OpenUIT();
        }
    }

    void OpenUIT()
    {
        GameUI.SetActive(true);
        isUIOn = true;
    }

    void CloseUIT()
    {
        GameUI.SetActive(false);
        isUIOn = false;
    }
}
