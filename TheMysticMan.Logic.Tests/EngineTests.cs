using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TheMysticMan.Logic.Tests
{
  [TestClass]
  public class EngineTests
  {
    private EngineOptions _options;
    private Mock<IRandom> _randomMock;

    [TestInitialize]
    public void TestInitialize(){
      _randomMock = new Mock<IRandom>();
      int startX = 7; // "H"
      int startY = 5;
      _randomMock.Setup(_ => _.CalculateStart(out startX, out startY));
      _options = new EngineOptions{
        Random = _randomMock.Object,
        Level = 1,
        MapX = 12,
        MapY = 10
      };
    }

    [TestMethod]
    public void RunEngineShouldInitializeTheMap()
    {
      Engine engine = new Engine(_options);
      engine.Run();
      Assert.IsTrue(engine.IsInitialized);
    }

    [TestMethod]
    public void EngineReturnsCurrentPosition()
    {
      Engine engine = new Engine(_options).Run();
      Assert.AreEqual("H5", engine.CurrentPosition);
    }

    [TestMethod]
    public void MoveUpShouldMove(){
      Engine engine = new Engine(_options).Run();
      engine.MoveUp();
      Assert.AreEqual("H6", engine.CurrentPosition);
    }

    [TestMethod]
    public void MoveDownShouldMove()
    {
      Engine engine = new Engine(_options).Run();
      engine.MoveDown();
      Assert.AreEqual("H4", engine.CurrentPosition);
    }

    [TestMethod]
    public void MoveLeftShouldMove()
    {
      Engine engine = new Engine(_options).Run();
      engine.MoveLeft();
      Assert.AreEqual("G5", engine.CurrentPosition);
    }

    [TestMethod]
    public void MoveRightShouldMove()
    {
      Engine engine = new Engine(_options).Run();
      engine.MoveRight();
      Assert.AreEqual("I5", engine.CurrentPosition);
    }

  }
}
