using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class RecycleItemsBase : ScriptableObject
{
    public Sprite icon;

    [Space]
    public new string name;

    [TextArea]
    public string description;

    protected bool isProcessing = false;

    public int currentCraftValue;

    public abstract void Seperate();
    public abstract void Crush();
    public abstract void Wash();
    public abstract void Shred();

    public abstract void SetActiveButtons();
    protected abstract void DisableButtons();
    protected abstract void ResetRecycleProcess();
}
