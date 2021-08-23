using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecycleManager : Singleton<RecycleManager>
{
    [Header("Recycling UI")]
    public Button[] ProcessButtons;
    public Button[] MaterialButtons;
    public Button ExitRecyclingUIButton;
    public RecycleItemsBase recycleItem;
    [SerializeField] TextMeshProUGUI codexMaterialDescription;
    [SerializeField] TextMeshProUGUI codexMaterialName;
    [SerializeField] SpriteRenderer codexMaterialSprite;

    void Update()
    {
        UpdateRecyclingUI();
        CodexMaterial();
    }

    void UpdateRecyclingUI() //set all buttons na wala kapag null
    {
        if (recycleItem == null)
        {
            for (int i = 0; i <= ProcessButtons.Length - 1; i++)
            {
               ProcessButtons[i].gameObject.SetActive(false);
            }
        }
    }

    #region Recycling Buttons
    public void ExitRecycling()//Not working as intended not sure kung ano sira???
    {
        CanvasManager.Instance.TurnOffSecondaryCanvas(CanvasType.Recycling);
        Time.timeScale = 1;
        GAME_MANAGER.instance.inRecyclingUI = false;
    }

    public void ItemToRecycle()
    {

    }
    public void SeperateButton()
    {
        recycleItem.Seperate();
    }
    public void CrushButton()
    {
        recycleItem.Crush();
    }
    public void WashButton()
    {
        recycleItem.Wash();
    }
    public void ShredButton()
    {
        recycleItem.Shred();
    }

    public void CodexMaterial()
    {
        if (recycleItem != null)
        {
            codexMaterialDescription.text = recycleItem.description;
            codexMaterialName.text = recycleItem.name;
            codexMaterialSprite.sprite = recycleItem.icon;
        }
        else return;
    }
    #endregion
}
