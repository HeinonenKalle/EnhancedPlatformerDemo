using UnityEngine;
using GameProgramming2D.State;
using System.Collections;

namespace GameProgramming2D.GUI
{
    public class GameOverGUI : SceneGUI
    {
        public void OnRestartGamePressed()
        {
            GameManager.Instance.StateManager
                .PerformTransition(TransitionType.GameOverToGame);
        }

        public void OnToMainMenuPressed()
        {
            GameManager.Instance.StateManager
                .PerformTransition(TransitionType.GameOverToMenu);
        }
    }
}