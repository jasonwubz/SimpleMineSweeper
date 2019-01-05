using System;

namespace SimpleMineSweeper
{
    public enum SquareState
    {
        Untouched = 1,
        Questioned = 2,
        Flagged = 3,
        MineExposed = 4,
        MineExploded = 5,
        WrongGuess = 6,
        EmptyExposed = 7
    }

    class MineSquare
    {
        private SquareState currentState;
        private bool hasMine = false;
        private readonly int squareIndex;

        public MineSquare(int index, bool insertMine = false)
        {
            squareIndex = index;
            currentState = SquareState.Untouched;
            hasMine = insertMine;
        }

        public int GetIndex()
        {
            return squareIndex;
        }

        public bool HasMine()
        {
            return hasMine;
        }

        public void InsertMine()
        {
            hasMine = true;
        }

        public void RemoveMine()
        {
            hasMine = false;
        }

        public void ChangeState(SquareState newState)
        {
            currentState = newState;
        }

        [Obsolete("GetStateName is deprecated. It was used for testing.")]
        public string GetStateName()
        {
            var state = (SquareState) currentState;
            return state.ToString();
        }

        public SquareState GetState()
        {
            return (SquareState) currentState;
        }

    }
}
