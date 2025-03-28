using System;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    public Text valueText;

    public void Init(Cell cell)
    {
        UpdateValue(cell.Num);

        cell.OnValueChanged += UpdateValue;
        cell.OnPositionChanged += UpdatePosition;

        transform.localPosition = new Vector3(-216 + cell.Coords.x * 144, 216 - cell.Coords.y * 144, 0);
    }

    public void UpdateValue(int val)
    {
        valueText.text = Math.Pow(2, val).ToString();
    }

    public void UpdatePosition(Vector2Int newPos)
    {
        transform.localPosition = new Vector3(-216 + newPos.x * 144, 216 - newPos.y * 144, 0);
    }
}
