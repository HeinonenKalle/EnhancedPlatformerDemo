using UnityEngine;
using System;
using System.Collections;
using GameProgramming2D.GUI;

namespace GameProgramming2D
{
    public class Pauser : MonoBehaviour
    {
        private bool paused = false;
        private Dialog _pauseDialog;

        public bool isPaused { get { return paused; } }

        public void setPauseOn()
        {
            Time.timeScale = 0;
            if(_pauseDialog == null)
            {
                InitPauseDialog();
            }

            _pauseDialog.Show();
        }

        private void InitPauseDialog()
        {
            _pauseDialog = GameManager.Instance.GUIManager.CreateDialog();
            _pauseDialog.SetHeadline("Pause");
            _pauseDialog.SetText("The game is paused. Press continue to continue the game.");
            _pauseDialog.SetShowCancel(false);
            _pauseDialog.SetOKButtonText("Continue");
            _pauseDialog.SetOnOKClicked(ContinueGame);
        }

        public void ContinueGame()
        {
            Time.timeScale = 1;
            Debug.Log("Continue game");
        }

        public void TogglePause()
        {
            paused = !paused;
            if (paused)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
}
