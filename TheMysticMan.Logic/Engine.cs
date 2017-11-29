namespace TheMysticMan.Logic
{
    public class Engine
    {
      private readonly EngineOptions _options;
      private Map _map;
      private MysticMan _mysticMan;

      public Engine(EngineOptions options){
        _options = options;
      }

      public Engine Run(){
        _map = new Map(_options.MapX, _options.MapY);
        _mysticMan = new MysticMan();
        _options.Random.CalculateStart(out int startX, out int startY);
        _mysticMan.Position = _map.GetPosition(startX, startY);

        IsInitialized = true;
        return this;
      }

      public bool IsInitialized{ get; set; }
      public string CurrentPosition => _mysticMan.Position;

      public void MoveUp(){
        Cell cell = _map.GetPosition(_mysticMan.Position);
        _mysticMan.Position = _map.GetPosition(cell.X, cell.Y+1);
      }

      public void MoveDown(){
        Cell cell = _map.GetPosition(_mysticMan.Position);
        _mysticMan.Position = _map.GetPosition(cell.X, cell.Y - 1);
    }

    public void MoveLeft(){
      Cell cell = _map.GetPosition(_mysticMan.Position);
      _mysticMan.Position = _map.GetPosition(cell.X-1, cell.Y);
    }

    public void MoveRight(){
      Cell cell = _map.GetPosition(_mysticMan.Position);
      _mysticMan.Position = _map.GetPosition(cell.X + 1, cell.Y);
      }
  }
}
