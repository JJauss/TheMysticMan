namespace TheMysticMan.Logic{
  public class Cell{
    public int X{ get; }
    public int Y{ get; }

    public string Id => $"{(char) (X + 65)}{Y+1}";

    public Cell(int x, int y){
      X = x;
      Y = y;
    }
  }
}