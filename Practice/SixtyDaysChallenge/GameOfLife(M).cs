namespace Practice.SixtyDaysChallenge
{
    public class GameOfLife_M_
    {
        public static void Test()
        {
            var board = new int[][] { new int []{0, 1, 0 },
                                      new int []{0, 0, 1 },
                                      new int []{1, 1, 1},
                                      new int[] {0, 0, 0 }
                };
             GameOfLife(board);
        }

        private static int[] rows = {-1, -1, -1, 0, 0, 1, 1, 1};
        private static int[] cols = {-1, 0, 1, -1, 1, -1, 0, 1 };

        private static bool IsSafe(int x, int y, int[][] board)
        {
            if(x>=0 && x < board.Length && y >=0 && y < board[0].Length)
            {
                return true;
            }
            return false;
        }

        private static void GameOfLife(int[][] board)
        {
            int m = board.Length;
            int n = board[0].Length;

            var dupBoard = new int[m][];

            for (var i = 0; i < m; i++)
            {
                dupBoard[i] = new int[n];
                for (var j = 0; j < n; j++)
                {
                    dupBoard[i][j] = board[i][j];
                }
            }

            for (var i=0; i< m; i++)
            {
                for(var j=0; j<n; j++)
                {
                    var liveCount = GetLiveNeighborsCount(i, j, dupBoard);
                    board[i][j] = dupBoard[i][j] == 1 ? GetLivingCellStatus(liveCount) : GetDeadCellStatus(liveCount);
                }
            }
        }

        private static int GetLivingCellStatus(int liveCount)
        {
            return liveCount < 2 || liveCount > 3 ? 0 : 1;
        }

        private static int GetDeadCellStatus(int liveCount)
        {
            return liveCount == 3 ? 1 : 0;
        }

        private static int GetLiveNeighborsCount(int x, int y, int[][] board)
        {
            var liveCount = 0;
            for(int k=0; k < 8; k++)
            {
                var row = x + rows[k];
                var col = y + cols[k];
                if (IsSafe(row, col, board) && board[row][col] == 1)
                {
                    liveCount++;
                }
            }
            return liveCount;
        }
    }
}
