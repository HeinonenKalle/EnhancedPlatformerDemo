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

        }

        public void SetOnOKClicked(DialogClosedDelegate callback = null, bool destroyAfterClose = true)
        {

        }

        public void SetOnCancelClicked(DialogClosedDelegate callback = null, bool destroyAfterClose = true)
        {

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

        }

        public void SetCancelButtonText(string text)
        {

        }
        #endregion
    }
}
