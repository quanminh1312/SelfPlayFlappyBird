using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Listens for the OnClick events for the main menu buttons
/// </summary>
public class MainMenu : IntEventInvoker
{
    static MainMenu instance;
    public static MainMenu Instance
    {
        get
        {
            return instance;
        }
    }
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        AddInvoker(EventName.DeActiveMenuEvent);
        EventManager.AddListener(EventName.DeActiveMenuEvent, DeActiveSelf);
    }
	/// <summary>
	/// Handles the on click event from the play button
	/// </summary>
    public void HandlePlayButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.Swoosh);
        MenuManager.GoToMenu(MenuName.Play);
	}

	/// <summary>
	/// Handles the on click event from the high score button
	/// </summary>
	public void HandleHighScoreButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.Swoosh);
        MenuManager.GoToMenu(MenuName.HighScore);
    }
    public void ActiveSelf()
    {
        unityEvents[EventName.DeActiveMenuEvent].Invoke((int)MenuName.Main);
        gameObject.SetActive(true);
    }
    public void DeActiveSelf(int menuName)
    {
        if ((MenuName)menuName != MenuName.Main)
            gameObject.SetActive(false);
    }
} 
