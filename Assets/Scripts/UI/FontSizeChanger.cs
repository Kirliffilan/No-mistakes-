using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FontSizeChanger : MonoBehaviour
{
    [SerializeField] private int _horizontalFontSize;
    [SerializeField] private int _verticalFontSize;

    private Camera _mainCamera;
    private Text _textChange;


    private void Awake()
    {
        _mainCamera = Camera.main;
        _textChange = GetComponent<Text>();
        OnRectTransformDimensionsChange();
    }

    private void OnRectTransformDimensionsChange()
    {
        if (_textChange == null || _mainCamera == null) return;

        var width = _mainCamera.pixelWidth;
        var height = _mainCamera.pixelHeight;

        if (width < height)
        {
            _textChange.fontSize = _verticalFontSize;
            _textChange.lineSpacing = (float) _verticalFontSize / 80;
        }
        else
        {
            _textChange.fontSize = _horizontalFontSize;
            _textChange.lineSpacing = (float) _horizontalFontSize / 80;
        }
    }
}
