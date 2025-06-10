using UnityEngine;

public class DragableLetter : Letter
{
    char Letter => _letter;
    private void OnMouseDrag()
    {
        //движение по нажатию мыши (метод можно поменять)
    }

    public override bool Validate() => true; //это на всякий случай, если эти буквы тоже будете проверять (лучше не надо)
}
