using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TheMysticMan.Logic.Tests
{
  [TestClass]
  public class EngineBasicTests : GameEngineTestsBase
  {
    [TestMethod]
    public void RunEngineShouldInitializeTheMap()
    {
      GameEngine engine = new GameEngine(Options);
      engine.Start();
      Assert.IsTrue(engine.IsRunning);
    }

    [TestMethod]
    public void EngineReturnsCurrentPosition()
    {
      GameEngine engine = new GameEngine(Options).Start();
      Assert.AreEqual("H6", engine.CurrentPosition);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void EnsureEngineIsInitialized(){
      GameEngine engine = new GameEngine(Options);
      engine.MoveDown();
    }


    [TestMethod]
    public void EnsureEngineIsNotStartetTwice(){
      int called = 0;
      RandomMock.Setup(_ => _.CalculateStart(Options.MapX, Options.MapY))
                .Returns(() => {
                  called++;
                  return StartCell;
                });
      GameEngine engine = new GameEngine(Options);
      engine.Start().Start();
      Assert.AreEqual(1, called);
    }

    [TestMethod]
    public void MoveUpShouldMove()
    {
      GameEngine engine = new GameEngine(Options).Start();
      engine.MoveUp();
      Assert.AreEqual("H5", engine.CurrentPosition);
    }

    [TestMethod]
    public void MoveDownShouldMove()
    {
      GameEngine engine = new GameEngine(Options).Start();
      engine.MoveDown();
      Assert.AreEqual("H7", engine.CurrentPosition);
    }

    [TestMethod]
    public void MoveLeftShouldMove()
    {
      GameEngine engine = new GameEngine(Options).Start();
      engine.MoveLeft();
      Assert.AreEqual("G6", engine.CurrentPosition);
    }

    [TestMethod]
    public void MoveRightShouldMove()
    {
      GameEngine engine = new GameEngine(Options).Start();
      engine.MoveRight();
      Assert.AreEqual("I6", engine.CurrentPosition);
    }

  }
}
