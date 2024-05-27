using Assets.Scripts.Menus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages navigation through the menu system
/// </summary>
public static class MenuManager
{
	/// <summary>
	/// Goes to the menu with the given name
	/// </summary>
	/// <param name="name">name of the menu to go to</param>
	public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.HighScore:

                // deactivate MainMenuCanvas and instantiate prefab
                HighScoreMenu.Instance.ActiveSelf();
                break;

            case MenuName.Play:
                PlayMenu.Instance.ActiveSelf();
                break;
            case MenuName.Main:

                // go to MainMenu scene
                MainMenu.Instance.ActiveSelf();
                break;
            case MenuName.Pause:

                PauseMenu.Instance.gameObject.SetActive(true);
                PauseMenu.Instance.HandlePauseEvent();
                break;
        }
	}
}
