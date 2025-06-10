using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableLetter : Letter
{
    private void Update()
    {
        //движение по кругу
    }

    private void OnMouseDrag()
    {
        //движение по нажатию мыши (метод можно поменять)
    }

    public override bool Validate() => true;
}
