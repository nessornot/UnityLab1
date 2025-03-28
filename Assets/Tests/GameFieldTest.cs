using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[TestFixture]
public class GameFieldTests
{
    [Test]
    public void Awake_InitializesCellsAndCreatesCell()
    {
        var gameFieldObj = new GameObject();
        var gameField = gameFieldObj.AddComponent<GameField>();
        gameField.cellViewPrefab = CreateMockCellViewPrefab();

        gameField.Awake();

        Assert.IsNotNull(gameField.cells);
        Assert.AreEqual(1, gameField.cells.Count);
    }

    [Test]
    public void GetEmptyPosition_AllPositionsOccupied_ReturnsInvalid()
    {
        var gameField = new GameField();
        gameField.cells = CreateFullCellsList();

        var pos = gameField.GetEmptyPosition();

        Assert.AreEqual(new Vector2Int(-1, 0), pos);
    }

    [Test]
    public void CreateCell_NoEmptySpace_DoesNotCreateCell()
    {
        var gameField = new GameField();
        gameField.cells = CreateFullCellsList();
        gameField.cellViewPrefab = CreateMockCellViewPrefab();

        gameField.CreateCell();

        Assert.AreEqual(16, gameField.cells.Count);
    }

    [Test]
    public void CreateCell_WithEmptySpace_AddsCellAndInstantiatesView()
    {
        var gameFieldObj = new GameObject();
        var gameField = gameFieldObj.AddComponent<GameField>();
        gameField.cellViewPrefab = CreateMockCellViewPrefab();

        gameField.CreateCell();

        Assert.AreEqual(1, gameField.cells.Count);
        Assert.AreEqual(1, gameFieldObj.transform.childCount);
    }

    private GameObject CreateMockCellViewPrefab()
    {
        var prefabObj = new GameObject();
        prefabObj.AddComponent<CellView>().valueText = prefabObj.AddComponent<Text>();
        return prefabObj;
    }

    private List<Cell> CreateFullCellsList()
    {
        var cells = new List<Cell>();
        for (int x = 0; x < 4; x++)
            for (int y = 0; y < 4; y++)
                cells.Add(new Cell(new Vector2Int(x, y), 1));
        return cells;
    }
}