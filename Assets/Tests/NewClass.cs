using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

[TestFixture]
public class CellViewTests
{
    [Test]
    public void Init_SubscribesToCellEventsAndUpdatesPosition()
    {
        var cell = new Cell(new Vector2Int(1, 2), 3);
        var cellViewObj = new GameObject();
        var cellView = cellViewObj.AddComponent<CellView>();
        cellView.valueText = cellViewObj.AddComponent<Text>();

        cellView.Init(cell);

        Assert.AreEqual("8", cellView.valueText.text); // 2^3
        var expectedPos = new Vector3(-216 + 1 * 144, 216 - 2 * 144, 0);
        Assert.AreEqual(expectedPos, cellView.transform.localPosition);
    }

    [Test]
    public void UpdateValue_ChangesTextToPowerOfTwo()
    {
        var cellViewObj = new GameObject();
        var cellView = cellViewObj.AddComponent<CellView>();
        cellView.valueText = cellViewObj.AddComponent<Text>();

        cellView.UpdateValue(4);

        Assert.AreEqual("16", cellView.valueText.text);
    }

    [Test]
    public void UpdatePosition_ChangesLocalPosition()
    {
        var cellViewObj = new GameObject();
        var cellView = cellViewObj.AddComponent<CellView>();
        var newPos = new Vector2Int(2, 3);

        cellView.UpdatePosition(newPos);

        var expectedPos = new Vector3(-216 + 2 * 144, 216 - 3 * 144, 0);
        Assert.AreEqual(expectedPos, cellView.transform.localPosition);
    }

    [Test]
    public void CellValueChange_UpdatesTextViaEvent()
    {
        var cell = new Cell(Vector2Int.zero, 1);
        var cellViewObj = new GameObject();
        var cellView = cellViewObj.AddComponent<CellView>();
        cellView.valueText = cellViewObj.AddComponent<Text>();
        cellView.Init(cell);

        cell.Num = 2;

        Assert.AreEqual("4", cellView.valueText.text);
    }
}