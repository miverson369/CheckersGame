using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;



namespace CheckersGame.Tests
{
    public class [TestClass]
    {
        [TestMethod]
        public void MovePiece_ValidMove_UpdatesBoard()
        {
            var game = new Game();

            bool result = game.Move(5, 0, 4, 1);

            Assert.IsTrue(result);
            Assert.IsNull(game.Board.Grid[5, 0]);
            Assert.IsNotNull(game.Board.Grid[4, 1]);
        }
    }
}
