using UnityEngine;
using System.Collections;
using GameProgramming2D.State;
using System;

namespace GameProgramming2D.GUI
{
    public class GUIManager : MonoBehaviour
    {
        [SerializeField]
        private Dialog _dialogPrefab;

        public SceneGUI SceneGUI { get; private set; }

        public void Init()
        {
            // Register to listen to StateManager.StateLoaded event. When fired,
            // call HandleStateLoaded method.
            GameManager.Instance.StateManager.StateLoaded += HandleStateLoaded;
            SceneGUI = FindObjectOfType<SceneGUI>();
        }

        void OnDisable()
        {
            GameManager.Instance.StateManager.StateLoaded -= HandleStateLoaded;
        }

        private void HandleStateLoaded(StateType type)
        {
            SceneGUI = FindObjectOfType<SceneGUI>();
            if (SceneGUI == null)
            {
                Debug.LogWarning("Could not find a SceneGUI component from loaded scene. Is this intentional?");
            }
        }

        public Dialog CreateDialog()
        {
            Dialog dialog = Instantiate(_dialogPrefab);
            dialog.transform.SetParent(SceneGUI.transform);
            dialog.transform.localPosition = Vector3.zero;
            dialog.transform.SetAsLastSibling();
            return dialog;
        }
    }
}
