using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Menus
{
    internal class PlayMenu : IntEventInvoker
    {
        static PlayMenu instance;
        public static PlayMenu Instance
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
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
            AddInvoker(EventName.DeActiveMenuEvent);
            AddInvoker(EventName.PauseEvent);
            EventManager.AddListener(EventName.DeActiveMenuEvent, DeActiveSelf);
        }
        public void ActiveSelf()
        {
            unityEvents[EventName.DeActiveMenuEvent].Invoke((int)MenuName.Play);
            gameObject.SetActive(true);
        }
        public void DeActiveSelf(int menuName)
        {
            if ((MenuName)menuName != MenuName.Play)
                gameObject.SetActive(false);
            unityEvents[EventName.PauseEvent].Invoke(0);
        }
        public void Pause()
        {
            AudioManager.Play(AudioClipName.Swoosh);
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }
}
