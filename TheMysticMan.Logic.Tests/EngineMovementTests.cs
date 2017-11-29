using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheMysticMan.Logic.Tests{
  [TestClass]
  public class EngineMovementTests : GameEngineTestsBase{
    private GameEngine _engine;
    private int _called;

    [TestInitialize]
    public override void TestInitialize(){
     
      base.TestInitialize();
      _called = 0;
      _engine = new GameEngine(Options);
      _engine.ManRaisedTheWall += (sender, args) => _called++;

    }

    [TestMethod]
    public void TestMoveLeft(){
      StartCell = new Cell(0,0);
      _engine.Start();
      _engine.MoveLeft();
      Assert.AreEqual("A1", _engine.CurrentPosition);
      Assert.AreEqual(1, _called);
    }


    [TestMethod]
    public void TestMoveUp()
    {
      StartCell = new Cell(0, 0);
      _engine.Start();
      _engine.MoveUp();
      Assert.AreEqual("A1", _engine.CurrentPosition);
      Assert.AreEqual(1, _called);
    }

    [TestMethod]
    public void TestMoveRight()
    {
      StartCell = new Cell(Options.MapX-1, 0);
      _engine.Start();
      _engine.MoveUp();
      Assert.AreEqual("L1", _engine.CurrentPosition);
      Assert.AreEqual(1, _called);
    }

    [TestMethod]
    public void TestMoveDown()
    {
      StartCell = new Cell(0, Options.MapY-1);
      _engine.Start();
      _engine.MoveDown();
      Assert.AreEqual("A10", _engine.CurrentPosition);
      Assert.AreEqual(1, _called);
    }

    [TestMethod]
    [ExpectedException(typeof(MaxMovesReachedException))]
    public void TestMoveMultipleTime(){
      // Start on level 1 means we have three possible moments
      _engine.Start();

      _engine.MoveDown();
      _engine.MoveDown();
      _engine.MoveDown();
      _engine.MoveDown();
    }

  }
}