using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectivesManager : Singleton<ObjectivesManager>
{
    [SerializeField] TextMeshProUGUI[] ObjectiveText;

	[SerializeField] int TutorialEnemyGoal;
	[SerializeField] int TutorialCraftGoal;

	[SerializeField] int Level1EnemyGoal;
	[SerializeField] int Level1CraftGoal;
	
	[SerializeField] int Level2EnemyGoal;
	[SerializeField] int Level2CraftGoal;
	
	[SerializeField] int Level3EnemyGoal;
	[SerializeField] int Level3CraftGoal;

	bool ObjectiveDone;


	private void Update()
	{
		UpdateObjectives();
	}


	void UpdateObjectives()
	{
		switch(SceneManager.GetActiveScene().buildIndex)
		{
			case 1:
				if (GAME_MANAGER.instance.currentEnemiesDisposed <= TutorialEnemyGoal)
				{
					ObjectiveText[0].SetText("Enemies Trashed: " + GAME_MANAGER.instance.currentEnemiesDisposed + "/" + TutorialEnemyGoal);
				}

				if (GAME_MANAGER.instance.currentCraftedItems <= TutorialCraftGoal)
				{
					ObjectiveText[1].SetText("Crafted Items: " + GAME_MANAGER.instance.currentCraftedItems + "/" + TutorialCraftGoal);
				}
				break;

			case 2:
				if (GAME_MANAGER.instance.currentEnemiesDisposed <= Level1EnemyGoal)
				{
					ObjectiveText[0].SetText("Enemies Trashed: " + GAME_MANAGER.instance.currentEnemiesDisposed + "/" + Level1EnemyGoal);
				}

				if (GAME_MANAGER.instance.currentCraftedItems <= Level1CraftGoal)
				{
					ObjectiveText[1].SetText("Crafted Items: " + GAME_MANAGER.instance.currentCraftedItems  + "/" + Level1CraftGoal);
				}
				break;

			case 3:
				if (GAME_MANAGER.instance.currentEnemiesDisposed <= Level2EnemyGoal)
				{
					ObjectiveText[0].SetText("Enemies Trashed: " + GAME_MANAGER.instance.currentEnemiesDisposed + "/" + Level2EnemyGoal);
				}

				if (GAME_MANAGER.instance.currentCraftedItems <= Level2CraftGoal)
				{
					ObjectiveText[1].SetText("Crafted Items: " + GAME_MANAGER.instance.currentCraftedItems + "/" + Level2CraftGoal);
				}
				break;

			case 4:
				if (GAME_MANAGER.instance.currentEnemiesDisposed <= Level3EnemyGoal)
				{
					ObjectiveText[0].SetText("Enemies Trashed: " + GAME_MANAGER.instance.currentEnemiesDisposed + "/" + Level3EnemyGoal);
				}

				if (GAME_MANAGER.instance.currentCraftedItems <= Level3CraftGoal)
				{
					ObjectiveText[1].SetText("Crafted Items: " + GAME_MANAGER.instance.currentCraftedItems + "/" + Level3CraftGoal);
				}
				break;
		}
	}

	public bool CheckObjectives()
	{
		switch (SceneManager.GetActiveScene().buildIndex)
		{
			case 1:
				if (GAME_MANAGER.instance.currentEnemiesDisposed >= TutorialEnemyGoal && GAME_MANAGER.instance.currentCraftedItems >= TutorialCraftGoal)
					ObjectiveDone = true;
				else
					ObjectiveDone = false;
				break;
			case 2:
				if (GAME_MANAGER.instance.currentEnemiesDisposed >= Level1EnemyGoal && GAME_MANAGER.instance.currentCraftedItems >= Level1CraftGoal)
					ObjectiveDone =  true;
				else
					ObjectiveDone = false;
				break;

			case 3:
				if (GAME_MANAGER.instance.currentEnemiesDisposed >= Level2EnemyGoal && GAME_MANAGER.instance.currentCraftedItems >= Level2CraftGoal)
					ObjectiveDone = true;
				else
					ObjectiveDone = false;
				break;
			case 4:
				if (GAME_MANAGER.instance.currentEnemiesDisposed >= Level3EnemyGoal && GAME_MANAGER.instance.currentCraftedItems >= Level3CraftGoal)
					ObjectiveDone = true;
				else
					ObjectiveDone = false;
				break;
		}

		return ObjectiveDone;
	}
}
