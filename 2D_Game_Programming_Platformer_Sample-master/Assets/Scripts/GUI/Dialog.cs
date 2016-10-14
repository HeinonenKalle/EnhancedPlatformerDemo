using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace GameProgramming2D.GUI
{
    public class Dialog : MonoBehaviour
    {
        #region Delegates
        public delegate void DialogClosedDelegate();
        #endregion

        #region Unity fields
        [SerializeField]
        private Text _headline;

        [SerializeField]
        private Text _text;

        [SerializeField]
        private Button _okButton;

        [SerializeField]
        private Button _cancelButton;
        #endregion

        #region Private fields
        private Vector3 _okButtonPosition;
        private UnityAction _okButtonClick;
        private UnityAction _cancelButtonClick;
        #endregion

        #region Unity messages
        private void Awake()
        {
            _okButtonPosition = _okButton.transform.localPosition;
        }
        #endregion

        #region Public interface
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void CloseDialog(DialogClosedDelegate dialogClosedDelegate = null, bool destroyAfterClose = true)
        {
            if(dialogClosedDelegate != null)
            {
                dialogClosedDelegate();
            }

            if(destroyAfterClose)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        public void SetOnOKClicked(DialogClosedDelegate callback = null, bool destroyAfterClose = true)
        {
            _okButtonClick = () => CloseDialog(callback, destroyAfterClose);
            SetButtonOnClick(_okButton, _okButtonClick);
        }

        public void SetOnCancelClicked(DialogClosedDelegate callback = null, bool destroyAfterClose = true)
        {
            _cancelButtonClick = () => CloseDialog(callback, destroyAfterClose);
            SetButtonOnClick(_cancelButton, _cancelButtonClick);
        }

        public void SetHeadline(string text)
        {
            _headline.text = text;
        }

        public void SetText(string text)
        {
            _text.text = text;
        }

        public void SetShowCancel(bool showCancel)
        {
            _cancelButton.gameObject.SetActive(showCancel);

            if(!showCancel)
            {
                var okPosition = _okButton.transform.localPosition;
                okPosition.x = 0;
                _okButton.transform.localPosition = okPosition;
            }
            else
            {
                _okButton.transform.localPosition = _okButtonPosition;
            }
        }

        public void SetOKButtonText(string text)
        {
            SetButtonText(_okButton, text);
        }

        public void SetCancelButtonText(string text)
        {
            SetButtonText(_cancelButton, text);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Sets text to button's child text component
        /// </summary>
        /// <param name="button">The button which has the text to change</param>
        /// <param name="text">The new text for the button</param>
        private void SetButtonText(Button button, string text)
        {
            Text label = button.GetComponentInChildren<Text>();
            label.text = text;
        }

        private void SetButtonOnClick(Button button, UnityAction callback)
        {
            button.onClick.AddListener(callback);
        }
        #endregion
    }
}
