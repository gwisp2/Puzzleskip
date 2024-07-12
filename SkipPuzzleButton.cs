using UnityEngine;

namespace Puzzleskip
{
    internal class SkipPuzzleButton : MonoBehaviour
    {
        private UILabel _label;
        private bool _skipEnabled;
        private string _originalText;
        private float _buttonDownSeconds = 0;

        public void Awake()
        {
            _label = this.gameObject.GetComponentInChildren<UILabel>();
            _originalText = _label.text;
        }

        public void Update()
        {
            if (Input.GetMouseButton(1))
            {
                _buttonDownSeconds += Time.deltaTime;
            }
            else
            {
                _buttonDownSeconds = 0;
            }
            if (_buttonDownSeconds > 3)
            {
                SkipEnabled = !SkipEnabled;
                _buttonDownSeconds = 0;
            }
        }

        public bool SkipEnabled
        {
            get { return _skipEnabled; }
            set
            {
                _skipEnabled = value;
                if (_skipEnabled)
                {
                    _label.text = "Skip";
                }
                else
                {
                    _label.text = _originalText;
                }
            }
        }
    }
}
