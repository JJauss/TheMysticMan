namespace TheMysticMan.Logic{
  public class Cell{
    public int X{ get; }
    public int Y{ get; }

    public string Id => $"{(char) (X + 65)}{Y}";

    public Cell(int x, int y){
      X = x;
      Y = y;
    }
  }
}