using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FontSizeChanger : MonoBehaviour
{
    [SerializeField] private int _horizontalFontSize; //размер шрифта при горизонтальном положении
    [SerializeField] private int _verticalFontSize; //размер шрифта при вертикальном положении

    private Camera _mainCamera; //основная камера, по которой определяется ориентация
    private Text _textChange; //тестовое поле, где надо менять размер

    private void Awake()
    {
        _mainCamera = Camera.main;
        _textChange = GetComponent<Text>();
        OnRectTransformDimensionsChange();
    }

    private void OnRectTransformDimensionsChange() //при трансформации Rect у текста
    {
        if (_textChange == null || _mainCamera == null) return;

        var width = _mainCamera.pixelWidth;
        var height = _mainCamera.pixelHeight;

        if (width < height) //проверка ориентации
        {
            _textChange.fontSize = _verticalFontSize; //установка новых значений
            _textChange.lineSpacing = (float) _verticalFontSize / 80;
        }
        else
        {
            _textChange.fontSize = _horizontalFontSize; //установка новых значений
            _textChange.lineSpacing = (float) _horizontalFontSize / 80;
        }
    }
}
