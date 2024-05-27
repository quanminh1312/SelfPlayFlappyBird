using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : IntEventInvoker
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    bool isActive = false;
    private void Start()
    {
        AudioManager.Initialize(this.GetComponent<AudioSource>());
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


        AddInvoker(EventName.GameStartedEvent);
        AddInvoker(EventName.PauseEvent);
        AddInvoker(EventName.InputEvent);
        EventManager.AddListener(EventName.GameOverEvent, HandleGameOverEvent);
        EventManager.AddListener(EventName.DeActiveMenuEvent, HandleDeactiveEvent);
    }
    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (!isActive)
                {
                    AudioManager.Play(AudioClipName.Flap);
                    unityEvents[EventName.GameStartedEvent].Invoke(1);
                    isActive = true;
                }
                unityEvents[EventName.InputEvent].Invoke(1);
            }
        }
    }
    void HandleGameOverEvent(int unused)
    {
        MenuManager.GoToMenu(MenuName.Pause);
    }
    void HandleDeactiveEvent(int menuName)
    {
        if ((MenuName)menuName == MenuName.Play)
        {
            isActive = false;
        }
    }
}
