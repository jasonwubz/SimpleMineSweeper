using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMineSweeper
{
    class MineLand
    {
        private List<MineSquare> mineSquares;
        private int numberOfRows;
        private int numberOfColumns;
        private int numberOfMines;
        private int totalSquares;
        private float difficultyLevel;

        private bool hasExploded;
        private bool allCleared;
        private bool firstSquareProbed;

        public MineLand()
        {
            mineSquares = new List<MineSquare>();
        }

        public MineLand(int rowSize, int colSize, float level)
        {
            mineSquares = new List<MineSquare>();

            Initialize(rowSize, colSize, level);
            
            CheckDifficultyLevel();
            DetermineMineCount();
            SetupMineSquares();
            RandomlySetMines();
        }

        public void Recreate(int rowSize, int colSize, float level)
        {
            Initialize(rowSize, colSize, level);

            CheckDifficultyLevel();
            DetermineMineCount();
            SetupMineSquares();
            RandomlySetMines();
        }

        private void Initialize(int rowSize, int colSize, float level)
        {
            numberOfRows = rowSize > 0 ? rowSize : 5;
            numberOfColumns = colSize > 0 ? colSize : 5;
            totalSquares = numberOfRows * numberOfColumns;
            difficultyLevel = level;
            hasExploded = false;
            allCleared = false;
            firstSquareProbed = false;

            if (mineSquares.Count > 0)
            {
                mineSquares.RemoveRange(0, mineSquares.Count);
            }
            
        }

        public bool HasGameEnded()
        {
            return hasExploded || allCleared;
        }

        public void MoveFirstMineToTopLeft(int previousPos)
        {
            if (firstSquareProbed)
            {
                return;
            }

            //find first top left square that does not have a mine
            var hasFoundFreeSquare = false;
            var startingRow = 0;

            while (hasFoundFreeSquare == false)
            {
                foreach (MineSquare mineSquare in mineSquares.GetRange(startingRow, numberOfColumns))
                {
                    var currentPos = mineSquare.GetIndex();
                    if (currentPos == previousPos || mineSquare.HasMine())
                    {
                        continue;
                    }
                    
                    hasFoundFreeSquare = true;
                    mineSquares[previousPos].RemoveMine();
                    mineSquares[currentPos].InsertMine();
                    break;
                }

                if (hasFoundFreeSquare == false)
                {
                    startingRow += numberOfColumns;
                    if (startingRow >= mineSquares.Count())
                    {
                        break; //this should not occur if the number of mines is less than square count
                    }
                }
                
            } 
            
        }

        [Obsolete("GetMinePosition is deprecated. It has been replaced with method GetIndex in MineSquare.")]
        public int GetMinePosition(MineSquare mine)
        {
            if (mine == null)
            {
                return 0;
            }

            try
            {
                return mineSquares.IndexOf(mine);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<MineSquare> GetMineSquares()
        {
            return mineSquares;
        }

        public IEnumerable<MineSquare> GetEachMineSquare()
        {
            foreach(MineSquare mineSquare in mineSquares)
            {
                yield return mineSquare;
            }
        }

        public MineSquare GetMineSquare(int pos)
        {
            try
            {
                return (MineSquare) mineSquares[pos];
            }
            catch (Exception)
            {
                return new MineSquare(-1); //dummy MineSquare
            }
        }

        public int GetFlaggedCount()
        {
            var countFlagged = 0;
            foreach (MineSquare mineSquare in mineSquares)
            {
                if (mineSquare.GetState() == SquareState.Flagged)
                {
                    countFlagged++;
                }
            }

            return countFlagged;
        }

        public bool CheckIfAllCleared()
        {
            var countCleared = 0;
            foreach (MineSquare mineSquare in mineSquares)
            {
                if (mineSquare.GetState() == SquareState.EmptyExposed)
                {
                    countCleared++;
                }
            }

            if (countCleared == (totalSquares - numberOfMines))
            {
                allCleared = true;
                return allCleared;
            }
            return false;
        }

        public int GetRows()
        {
            return numberOfRows;
        }

        public int GetColumns()
        {
            return numberOfColumns;
        }

        public int GetTotalMineCount()
        {
            return numberOfMines;
        }

        public int GetTotalSquareCount()
        {
            return mineSquares.Count;
        }

        public bool ProbeForMine(int minePosition, bool activateMine = false)
        {
            if (this.mineSquares[minePosition].HasMine())
            {
                if (activateMine && this.firstSquareProbed == false)
                {
                    MoveFirstMineToTopLeft(minePosition);
                    this.firstSquareProbed = true;
                    return false;
                }

                if (activateMine)
                {
                    this.mineSquares[minePosition].ChangeState(SquareState.MineExploded);
                    this.hasExploded = true;
                }
                return true;
            }
            else
            {
                if (activateMine && this.firstSquareProbed == false)
                {
                    this.firstSquareProbed = true;
                }
            }

            return false;
        }

        private void SetupMineSquares()
        {
            for (int i = 0; i < this.totalSquares; i++)
            {
                this.mineSquares.Insert(i, new MineSquare(i));
            }            
        }

        private void RandomlySetMines()
        {
            var random = new Random();
            var remainingMines = numberOfMines;
            var actualTotalSquareCount = mineSquares.Count;

            while (remainingMines > 0)
            {
                //min range is inclusive, but max range is exlusive so no worrying about totalSquares - 1
                int randomPos = random.Next(0, totalSquares);
                if (actualTotalSquareCount < randomPos || mineSquares[randomPos].HasMine())
                {
                    continue;
                }
                mineSquares[randomPos].InsertMine();
                remainingMines--;
            }
        }

        private void CheckDifficultyLevel()
        {
            if (difficultyLevel >= 1 || difficultyLevel <= 0) //expecting a percentage lower than 100%
            {
                difficultyLevel = 0.5f;
            }
        }

        private void DetermineMineCount()
        {
            numberOfMines = (int) (totalSquares * difficultyLevel);

            //in case number of mines exceeds total squares
            if (numberOfMines >= totalSquares)
            {
                numberOfMines = totalSquares / 2;
            }
        }
    }
}
