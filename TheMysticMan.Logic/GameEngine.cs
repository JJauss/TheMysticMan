using System;
using System.Runtime.CompilerServices;

namespace TheMysticMan.Logic{
  public class GameEngine{
    private readonly EngineOptions _options;
    private readonly Map _map;
    private readonly MysticMan _mysticMan;
    private int _moveCounter;
    private int _maxMoves;

    public event EventHandler ManRaisedTheWall;

    public GameEngine(EngineOptions options){
      _mysticMan = new MysticMan();
      _map = new Map(options.MapX, options.MapY);
      _options = options;
    }

    public GameEngine Start(){
      if (IsRunning){
        return this;
      }

      Cell startCell = _options.Random.CalculateStart(_options.MapX, _options.MapY);
      _mysticMan.Position = startCell.Id;
      _moveCounter = 0;
      _maxMoves = _options.Level * 3;

      IsRunning = true;
      return this;
    }

    public bool IsRunning{ get; set; }

    public string CurrentPosition => _mysticMan.Position;

    public void MoveUp(){
      Move(MoveDirection.Up);
    }

    public void MoveDown(){
      Move(MoveDirection.Down);
    }

    public void MoveLeft(){
      Move(MoveDirection.Left);
    }

    public void MoveRight(){
      Move(MoveDirection.Right);
    }

    private void Move(MoveDirection direction){
      EnsureInitialized();

      Cell cell = _map.GetPosition(_mysticMan.Position);
      try{
        IncrementMove();
        int newX;
        int newY;
        switch (direction){
          case MoveDirection.Up:
            newX = cell.X;
            newY = cell.Y - 1;
            break;
          case MoveDirection.Down:
            newX = cell.X;
            newY = cell.Y + 1;
            break;
          case MoveDirection.Left:
            newX = cell.X - 1;
            newY = cell.Y;
            break;
          case MoveDirection.Right:
            newX = cell.X + 1;
            newY = cell.Y;
            break;
          default:
            throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        _mysticMan.Position = _map.GetPosition(newX, newY);
      } catch (InvalidPositionException){
        OnManRaisedTheWall();
      }
    }

    private void IncrementMove(){
      if (_moveCounter < _maxMoves){
        _moveCounter++;
      } else{
        throw new MaxMovesReachedException($"Only {_maxMoves} are allowed.");
      }
    }

    private void EnsureInitialized([CallerMemberName] string caller = ""){
      if (!IsRunning){
        throw new InvalidOperationException($"GameEngine is not initialized, Call Start method before executing {caller}.");
      }
    }

    protected virtual void OnManRaisedTheWall(){
      ManRaisedTheWall?.Invoke(this, EventArgs.Empty);
    }
  }
}