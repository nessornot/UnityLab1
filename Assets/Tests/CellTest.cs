using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class CellTests
{
    [Test]
    public void Constructor_InitializesCoordsAndNum()
    {
        var pos = new Vector2Int(2, 3);
        int val = 5;
        var cell = new Cell(pos, val);

        Assert.AreEqual(pos, cell.Coords);
        Assert.AreEqual(val, cell.Num);
    }

    [Test]
    public void Coords_SetNewValue_TriggersEvent()
    {
        var cell = new Cell(new Vector2Int(0, 0), 1);
        bool eventTriggered = false;
        cell.OnPositionChanged += _ => eventTriggered = true;

        cell.Coords = new Vector2Int(1, 1);

        Assert.IsTrue(eventTriggered);
    }

    [Test]
    public void Coords_SetSameValue_DoesNotTriggerEvent()
    {
        var initialCoords = new Vector2Int(0, 0);
        var cell = new Cell(initialCoords, 1);
        bool eventTriggered = false;
        cell.OnPositionChanged += _ => eventTriggered = true;

        cell.Coords = initialCoords;

        Assert.IsFalse(eventTriggered);
    }

    [Test]
    public void Num_SetNewValue_TriggersEvent()
    {
        var cell = new Cell(new Vector2Int(0, 0), 1);
        bool eventTriggered = false;
        cell.OnValueChanged += _ => eventTriggered = true;

        cell.Num = 2;

        Assert.IsTrue(eventTriggered);
    }

    [Test]
    public void Num_SetSameValue_DoesNotTriggerEvent()
    {
        var cell = new Cell(new Vector2Int(0, 0), 1);
        bool eventTriggered = false;
        cell.OnValueChanged += _ => eventTriggered = true;

        cell.Num = 1;

        Assert.IsFalse(eventTriggered);
    }
}