using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBoardPageFlip : MonoBehaviour
{
    public int selectedPage = 0;
    int previousSelectedPage = 0;

    [SerializeField] Button prevPage;
    [SerializeField] Button nextPage;

    [SerializeField] GameObject startButton;

    private void Update()
    {
        PageSwitch();
    }

    void PageSwitch()
    {
        previousSelectedPage = selectedPage;

        if (selectedPage == 0)
        {
            prevPage.interactable = false;
        }
        if (selectedPage > 0)
        {
            prevPage.interactable = true;
        }

        if (selectedPage == transform.childCount - 1)
        {
            nextPage.interactable = false;
            startButton.SetActive(true);
        }
        if (selectedPage < transform.childCount - 1)
        {
            nextPage.interactable = true;
            startButton.SetActive(false);
        }
    }

    public void NextPage()
    {
        if (selectedPage < transform.childCount - 1)
        {
            selectedPage++;

            if (previousSelectedPage != selectedPage)
            {
                SelectPage();
            }
        }
    }

    public void PrevPage()
    {
        if (selectedPage > 0)
        {
            selectedPage--;

            if (previousSelectedPage != selectedPage)
            {
                SelectPage();

            }
        }
    }

    void SelectPage()
    {
        int i = 0;

        foreach (Transform page in transform)
        {
            if (i == selectedPage)
            {
                page.gameObject.SetActive(true);
            }
            else
            {
                page.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
