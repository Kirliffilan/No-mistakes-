using UnityEngine;

public class HPBar : MonoBehaviour
{
    public static HPBar Instance {  get; private set; }

    [SerializeField] GameObject[] HPs;
    [SerializeField] GameObject _endGameMenu;
    private int _currentIndex;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        ChoosableLetter.WrongLetter += HPdown;
    }

    private void OnDisable()
    {
        ChoosableLetter.WrongLetter -= HPdown;
    }

    public void HPdown() //уменьшает здоровье
    {
        HPs[_currentIndex++].SetActive(false);
        if (_currentIndex == HPs.Length) _endGameMenu.SetActive(true); //заканчивает игру при окончании здоровья
    }

    public void ResetHP() //восстанавливает здоровье
    {
        _currentIndex = 0;
        foreach(var HP in HPs)
        {
            HP.SetActive(true);
        }
    }
}
