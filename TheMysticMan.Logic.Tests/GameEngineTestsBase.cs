using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TheMysticMan.Logic.Tests{
  [TestClass]
  public class GameEngineTestsBase{
    protected EngineOptions Options;
    protected Mock<IRandom> RandomMock;
    protected Cell StartCell{ get; set; }
    
    [TestInitialize]
    public virtual void TestInitialize(){
      RandomMock = new Mock<IRandom>();

      StartCell = new Cell(7,5);
      Options = new EngineOptions{
        Random = RandomMock.Object,
        Level = 1,
        MapX = 12,
        MapY = 10
      };
      RandomMock.Setup(_ => _.CalculateStart(Options.MapX, Options.MapY)).Returns(() => StartCell);

    }
  }
}