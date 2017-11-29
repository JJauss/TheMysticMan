using System.Collections.Generic;
using System.Linq;

namespace TheMysticMan.Logic{
  public class Map{
    private readonly Cell[,] _innerMap;

    public Map(int maxX, int maxY){
      _innerMap = new Cell[maxX, maxY];

      for (int i = 0; i < maxX; i++){
        for (int j = 0; j < maxY; j++){
          _innerMap[i,j] = new Cell(i,j);
        }
      }
    }

    private IEnumerable<Cell> Cells{
      get{
        for (int i = 0; i < _innerMap.GetLength(0); i++){
          for (int j = 0; j < _innerMap.GetLength(1); j++){
            yield return _innerMap[i, j];
          }
        }
      }
    }

    public string GetPosition(int x, int y){
      Cell cell = Cells.SingleOrDefault(c => c.X == x && c.Y == y);
      return cell?.Id ?? throw new InvalidPositionException();
    }

    public Cell GetPosition(string coordinates){
      return Cells.Single(c => c.Id == coordinates);
    }
  }
}