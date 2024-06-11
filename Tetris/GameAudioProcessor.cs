using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;

namespace Tetris
{
    public class GameAudioProcessor : IEventListener // This class processes audio request from game events
    {
        private EventManager _eventManager;
        private List<string> _currentMusic;
        private int _currentMusicIndex;
        private bool _stillInMenu; // When Menu state is changed to Help state, the music is still playing
        public GameAudioProcessor(EventManager eventManager)
        {
            _eventManager = eventManager;
            _eventManager.Attach(this);
            _currentMusic = new List<string>();
            _currentMusicIndex = 0;
            _stillInMenu = false;
        }

        public void Update(GameEvent e) // Update depends on the game events
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.Initialize:
                    Initialize();
                    break;
                case Event.Tick:
                    MusicCheck();
                    break;
                case Event.ClearLine:
                    PlaySoundEffect("ClearLine");
                    break;
                case Event.PlaceTetrimino:
                    PlaySoundEffect("PlaceTetrimino");
                    break;
                case Event.StateChange:
                    Enum.TryParse(e.GetMessage()[1], out State state);
                    StateChangeHandler(state);
                    break;
            }
        }

        public void StopCurrentSoundtrack() // Stop Current Soundtrack before changing to another state
        {
            SplashKit.StopMusic();
            _currentMusic.Clear();
            _currentMusicIndex = 0;
        }

        public void PlaySoundEffect(string soundEffectName)
        {
            SplashKit.PlaySoundEffect(soundEffectName, 100f);
        }

        public void PlayMusic(string musicName)
        {
            SplashKit.PlayMusic(musicName, 1);
            if(!SplashKit.MusicPlaying()) PlayMusic(musicName); // SplashKit.MusicPlaying() is inconsistent, so it needs to be recalled it.
        }

        public void MusicCheck()
        {
            if(!SplashKit.MusicPlaying() && _currentMusic.Count > 0)
            {
                PlayMusic(_currentMusic[_currentMusicIndex]);
                _currentMusicIndex++;
                _currentMusicIndex %= _currentMusic.Count;
            }
        }

        private void Initialize() // Load sound effects and musics in Initialize event
        {
            SplashKit.LoadSoundEffect("NewGame", "NewGame.wav");
            SplashKit.LoadSoundEffect("ClearLine", "ClearLine.wav");
            SplashKit.LoadSoundEffect("PlaceTetrimino", "PlaceTetrimino.wav");
            SplashKit.LoadSoundEffect("PauseMenu", "PauseMenu.wav");
            SplashKit.LoadSoundEffect("PauseMenuButtons", "PauseMenuButtons.wav");
            SplashKit.LoadMusic("FirstMenuMusic", "MenuMusic1.mp3");
            SplashKit.LoadMusic("SecondMenuMusic", "MenuMusic2.mp3");
            SplashKit.LoadMusic("FirstIngameMusic", "IngameMusic1.mp3");
            SplashKit.LoadMusic("SecondIngameMusic", "IngameMusic2.mp3");
            SplashKit.LoadMusic("ThirdIngameMusic", "IngameMusic3.mp3");
            SplashKit.LoadMusic("ForthIngameMusic", "IngameMusic4.mp3");
            SplashKit.LoadMusic("GameOverMusic", "GameOverMusic.mp3");
            SplashKit.LoadMusic("PauseMenuMusic", "PauseMenuMusic.mp3");
        }

        private void StateChangeHandler(State state) // Change the set of music tracks depends on the current state
        {
            switch (state)
            {
                case State.Menu:
                    if (!_stillInMenu)
                    {
                        StopCurrentSoundtrack();
                        _currentMusic.Add("FirstMenuMusic");
                        _currentMusic.Add("SecondMenuMusic");
                    }
                    _stillInMenu = false;
                    break;
                case State.Help:
                    _stillInMenu = true;
                    break;
                case State.Ingame:
                    StopCurrentSoundtrack();
                    _currentMusic.Add("FirstIngameMusic");
                    _currentMusic.Add("SecondIngameMusic");
                    _currentMusic.Add("ThirdIngameMusic");
                    _currentMusic.Add("ForthIngameMusic");
                    break;
                case State.PauseMenu:
                    StopCurrentSoundtrack();
                    PlaySoundEffect("PauseMenu");
                    _currentMusic.Add("PauseMenuMusic");
                    break;
                case State.GameOver:
                    StopCurrentSoundtrack();
                    _currentMusic.Add("GameOverMusic");
                    break;
            }
        }
    }
}
