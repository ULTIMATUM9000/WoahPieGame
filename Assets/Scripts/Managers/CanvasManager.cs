using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType
{
    MainMenu,
    GameUI,
    EndScreen,
    GameOver,
    Pause,
    Recycling,
    Codex,
    CommunityScreen,
    Controls,
    MiniMap,
    FinalScreen,
    StoryBoard
}

public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;
    CanvasController secondaryActiveCanvas;

    protected override void Awake()
    {
        base.Awake();
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.MainMenu);
    }

    public void SwitchCanvas(CanvasType _type)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }
        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);

        if (desiredCanvas != null)
        {
            //check if desired canvas is parented with another canvas
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else  Debug.LogWarning("The desired canvas was not found!");
    }

    public void SecondaryCanvas(CanvasType _type)
    {
        if(secondaryActiveCanvas != null)
        {
            secondaryActiveCanvas.gameObject.SetActive(false);
        }
        CanvasController desiredSecondaryCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        if (desiredSecondaryCanvas != null || desiredSecondaryCanvas == null)
        {
            desiredSecondaryCanvas.gameObject.SetActive(true);
            secondaryActiveCanvas = desiredSecondaryCanvas;
        }
    }

    public void TurnOffSecondaryCanvas(CanvasType _canvasType)
    {
        secondaryActiveCanvas.gameObject.SetActive(false);
    }
}