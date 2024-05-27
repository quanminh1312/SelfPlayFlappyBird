using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Retrieves and displays high score and listens for
/// the OnClick events for the high score menu button
/// </summary>
public class HighScoreMenu : IntEventInvoker
{
	[SerializeField]
	TextMeshProUGUI message;
	static HighScoreMenu instance;
	public static HighScoreMenu Instance
    {
        get
        {
            return instance;
        }
    }
	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		if (instance == null)
        {
            instance = this;
			gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
		// retrieve and display high score
		if (PlayerPrefs.HasKey("High Score"))
		{
			message.text = "Your High Score: " + PlayerPrefs.GetInt("High Score");
		}
		else
		{
			message.text = "High Score\nNo games played yet";
		}
		AddInvoker(EventName.DeActiveMenuEvent);
		EventManager.AddListener(EventName.DeActiveMenuEvent, DeActiveSelf);
	}
	/// <summary>
	/// Handles the on click event from the quit button
	/// </summary>
	public void HandleQuitButtonOnClickEvent()
	{
		AudioManager.Play(AudioClipName.Swoosh);
		MenuManager.GoToMenu(MenuName.Main);
	}
	public void ActiveSelf()
    {
        unityEvents[EventName.DeActiveMenuEvent].Invoke((int)MenuName.HighScore);
        gameObject.SetActive(true);
	}
	public void DeActiveSelf(int menuName)
    {
		if ((MenuName)menuName != MenuName.HighScore)
        gameObject.SetActive(false);
    }
}
