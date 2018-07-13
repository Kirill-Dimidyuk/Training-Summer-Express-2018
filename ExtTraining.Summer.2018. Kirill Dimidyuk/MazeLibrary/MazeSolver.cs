using System;

namespace MazeLibrary
{
    public class MazeSolver
    {
        public MazeSolver(int[,] mazeModel, int startX, int startY)
        {
            int StartX = startX;
            int StartY = startY;
            int[,] MazeModel = mazeModel;
        }

        private int StartX { get; }

        private int StartY { get; }

        private int[,] MazeModel { get; }

        public int[,] MazeWithPass() => throw new NotImplementedException();

        void PassMaze()
        {
            int StartX = 3;
            int StartY = 5;
            int i = StartX;
            int j = StartY;
            int pass = 0;
            int variaty = 0;

            while (i != 0 && j != 0 && i != 5 && j != 5)
            {
                variaty = 0;
                if (i < 5 && MazeModel[i + 1, j] == 0)
                {
                    ++variaty;
                    if (variaty > 1)
                    {
                        if (PassMaz(i + 1, j) == true)
                        {
                            MazeModel[i, j] = ++pass;
                            i++;
                        }
                    }
                    else
                    {
                        MazeModel[i, j] = ++pass;
                        i++;
                    }
                }

                if (i > 0 && MazeModel[i - 1, j] == 0)
                {
                    ++variaty;
                    if (variaty > 1)
                    {
                        if (PassMaz(i - 1, j) == true)
                        {
                            MazeModel[i, j] = ++pass;
                            i--;
                        }
                    }
                    else
                    {
                        MazeModel[i, j] = ++pass;
                        i--;
                    }
                }

                if (j < 5 && MazeModel[i, j + 1] == 0)
                {
                    ++variaty;
                    if (variaty > 1)
                    {
                        if (PassMaz(i, j + 1) == true)
                        {
                            MazeModel[i, j] = ++pass;
                            j++;
                        }
                    }
                    else
                    {
                        MazeModel[i, j] = ++pass;
                        j++;
                    }
                }

                if (j > 0 && MazeModel[i, j - 1] == 0)
                {
                    ++variaty;
                    if (variaty > 1)
                    {
                        if (PassMaz(i, j - 1) == true)
                        {
                            MazeModel[i, j] = ++pass;
                            j--;
                        }
                    }
                    else
                    {
                        MazeModel[i, j] = ++pass;
                        j--;
                    }
                }

                if (variaty == 0)
                {
                    break;
                }

            }
        }

        bool PassMaz(int i, int j)
        {
            bool k = false;
            int variaty = 0;
            while (i != 0 || j != 0 || i != 5 || j != 5)
            {
                variaty = 0;
                if (i < 5 && MazeModel[i + 1, j] == 0)
                {
                    variaty++;
                    if (variaty > 1)
                    {
                        if (PassMaz(i + 1, j))
                        {
                            i++;
                        }
                    }
                    else
                    {
                        i++;
                    }
                }

                if (i > 0 && MazeModel[i - 1, j] == 0)
                {
                    variaty++;
                    if (variaty > 1)
                    {
                        if (PassMaz(i - 1, j))
                        {
                            i--;
                        }
                    }
                    else
                    {
                        i--;
                    }
                }

                if (j < 5 && MazeModel[i, j + 1] == 0)
                {
                    variaty++;
                    if (variaty > 1)
                    {
                        if (PassMaz(i, j + 1))
                        {
                            j++;
                        }
                    }
                    else
                    {
                        j++;
                    }
                }

                if (j > 0 && MazeModel[i, j - 1] == 0)
                {
                    variaty++;
                    if (variaty > 1)
                    {
                        if (PassMaz(i, j - 1))
                        {
                            j--;
                        }
                    }
                    else
                    {
                        j--;
                    }
                }
                if (variaty == 0)
                {
                    k = false;
                    break;
                }
                else
                {
                    k = true;
                }
            }
            return k;
        }
    }
}
