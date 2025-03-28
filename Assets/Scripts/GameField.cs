using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    public int Width => 4;
    public int Height => 4;

    public GameObject cellViewPrefab;
    public List<Cell> cells;

    public void Awake()
    {
        cells = new();
        CreateCell();
    }

    public Vector2Int GetEmptyPosition()
    {
        List<Vector2Int> emptyPos = new();

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Vector2Int pos = new(x, y);
                bool occup = false;

                foreach (Cell cell in cells)
                {
                    if (cell.Coords == pos)
                    {
                        occup = true;
                        break;
                    }
                }

                if (!occup)
                {
                    emptyPos.Add(pos);
                }
            }
        }

        if (emptyPos.Count == 0)
        {
            return new Vector2Int(-1, 0);
        }

        return emptyPos[Random.Range(0, emptyPos.Count)];
    }

    public void CreateCell()
    {
        Vector2Int pos = GetEmptyPosition();
        if (pos.x == -1) { return; }

        int val = (Random.value <= 0.9f) ? 1 : 2;

        Cell newCell = new(pos, val);
        cells.Add(newCell);

        GameObject cellViewObject = Instantiate(cellViewPrefab, transform);
        CellView cellView = cellViewObject.GetComponent<CellView>();

        cellView.Init(newCell);
    }
}
