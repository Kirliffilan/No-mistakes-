using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class IndefierAnswer : MonoBehaviour
{
    private Image _image;
    private Color _noColor;
    private Color _redColor;
    private Color _greenColor;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _noColor = Color.white;
        _noColor.a = 0f;
        _greenColor = new(0f, 0.7f, 0.2f, 0.3f);
        _redColor = Color.red;
        _redColor.a = 0.3f;
        _image.color = _noColor;
        ChoosableLetter.CorrectLetter += ChoosableLetter_CorrectLetter;
        ChoosableLetter.WrongLetter += ChoosableLetter_WrongLetter;
    }

    private void OnDestroy()
    {
        ChoosableLetter.CorrectLetter -= ChoosableLetter_CorrectLetter;
        ChoosableLetter.WrongLetter -= ChoosableLetter_WrongLetter;
    }

    private void ChoosableLetter_WrongLetter()
    {
        StartCoroutine(ShowRed());
    }

    private void ChoosableLetter_CorrectLetter()
    {
        _image.color = _greenColor;
    }

    private IEnumerator ShowRed()
    {
        _image.color = _redColor;
        yield return new WaitForSeconds(0.5f);
        _image.color = _noColor;
    }
}
