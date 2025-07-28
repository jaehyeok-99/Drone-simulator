using System;
using UnityEngine;
using UnityEngine.UI;

namespace DroneController
{
    public class InputVisualizer : MonoBehaviour
    {
        [Serializable]
        private struct KeyboardControlMap
        {
            public Image ImagePositive;
            public Image ImageNegative;

            public void Update(float value, Color activeColor, Color inactiveColor)
            {
                if (Mathf.Approximately(value, 0.0f))
                {
                    ImagePositive.color = ImageNegative.color = inactiveColor;
                    return;
                }

                Image image = (value > 0f) ? ImagePositive : ImageNegative;
                image.color = activeColor;
            }
        }

        [Header("Local References:")]
        [SerializeField] private RectTransform _leftAnalogStickBox = default;
        [SerializeField] private RectTransform _leftAnalogStick = default;
        [Space]
        [SerializeField] private RectTransform _rightAnalogStickBox = default;
        [SerializeField] private RectTransform _rightAnalogStick = default;
        [Space]
        [SerializeField] private KeyboardControlMap _keyboardPitch = default;
        [SerializeField] private KeyboardControlMap _keyboardRoll = default;
        [SerializeField] private KeyboardControlMap _keyboardThrottle = default;
        [SerializeField] private KeyboardControlMap _keyboardYaw = default;

        [Header("Settings:")]
        [SerializeField] private Color _inactiveButtonColor = default;
        [SerializeField] private Color _activeButtonColor = default;

        // [추가] 인터퍼런스 존 안내 패널 참조 변수 (Text, Panel 등)
        [Header("Interference Zone UI")]
        [SerializeField] private GameObject interferenceZoneNoticePanel = default;
        // 또는 아래처럼 Text로 바꿀 수도 있음
        // [SerializeField] private Text interferenceZoneNoticeText = default;

        // Component references.
        private InputManager _inputManager = default;

        // Private properties.
        public InputManager InputManager
        {
            get
            {
                if (_inputManager == null)
                {
                    _inputManager = InputManager.Instance;
                }
                return _inputManager;
            }
        }

        private void LateUpdate()
        {
            // Joystick positioning:
            UpdateAnalogStickPosition(_leftAnalogStickBox, _leftAnalogStick, InputManager.RollInput, InputManager.PitchInput);
            UpdateAnalogStickPosition(_rightAnalogStickBox, _rightAnalogStick, InputManager.YawInput, InputManager.ThrottleInput);
            // Keyboard painting.
            _keyboardPitch.Update(InputManager.PitchInput, _activeButtonColor, _inactiveButtonColor);
            _keyboardRoll.Update(InputManager.RollInput, _activeButtonColor, _inactiveButtonColor);
            _keyboardThrottle.Update(InputManager.ThrottleInput, _activeButtonColor, _inactiveButtonColor);
            _keyboardYaw.Update(InputManager.YawInput, _activeButtonColor, _inactiveButtonColor);
        }

        private void UpdateAnalogStickPosition(RectTransform analogStickBox, RectTransform analogStick, float xInput, float yInput)
        {
            float xMovement = (xInput * analogStickBox.sizeDelta.x / 2) - (analogStick.sizeDelta.x / 2);
            float yMovement = (yInput * analogStickBox.sizeDelta.y / 2) - (analogStick.sizeDelta.y / 2);
            analogStick.anchoredPosition = new Vector2(xMovement, yMovement);
        }

        // [추가] Interference Zone 상태에 따라 안내 UI 표시 메서드
        public void SetInterferenceZoneState(bool isIn)
        {
            if (interferenceZoneNoticePanel != null)
                interferenceZoneNoticePanel.SetActive(isIn);

            // Text 방식이라면 아래처럼
            // if (interferenceZoneNoticeText != null)
            //     interferenceZoneNoticeText.text = isIn ? "인터퍼런스 존에 진입했습니다!" : "";
        }
    }
}
