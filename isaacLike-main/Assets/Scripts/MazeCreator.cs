using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCreator 
{

    const int PATH = 0;
    const int WALL = 1;
    //230927
    const int PLAYER = 2;

    int[,] maze;
    int w;
    int h;

    enum DIRECTION
    {
        UP,
        RIGHT,
        DOWN,
        LEFT
    }

    List<Cell> startCells = new List<Cell>();

    public MazeCreator(int _w,int _h)
    {
        if (_w < 5 || _h < 5) throw new ArgumentOutOfRangeException();
        if (_w % 2 == 0) _w++;
        if (_h % 2 == 0) _h++;
        w = _w;
        h = _h;
        maze = new int[w, h];
    }

    public int[,] CreateMaze()
    {
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                if(x == 0 || y == 0 || x == w -1 || y == h - 1)
                {
                    maze[x, y] = PATH;
                }
                else
                {
                    maze[x, y] = WALL;
                }
            }
        }

        //Dig(1, 1);
        //230927
        Dig(w/2, h/2);
        //maze[w % 2, h % 2] = PLAYER;

        for (int y = 0;y < h; y++)
        {
            for(int x = 0;x < w; x++)
            {
                if(x == 0|| y == 0 || x == w-1||y == h - 1)
                {
                    maze[x, y] = WALL;
                }
            }
        }

        //231021
        System.Random rnd = new System.Random();
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                //231020
                //UnityEngine.Random.InitState(DateTime.Now.Millisecond);
                //simdata.RandomMapNum[_x, _y, 0] = UnityEngine.Random.Range(0, 4);
                //simdata.RandomMapNum[x, y, 0] = rnd.Next(1,4);

                //231021
                simdata.RandomMapNum[x, y, 0] = (int)Random(0, 4);

                //UnityEngine.Random.InitState(DateTime.Now.Millisecond);
                simdata.RandomMapNum[x, y, 1] = (int)UnityEngine.Random.Range(0f,4f);
                //simdata.RandomMapNum[_x, _y, 1] = rnd.Next(4);
            }
        }

        return maze;
    }
    

    void Dig(int _x ,int _y)
    {
        System.Random rnd = new System.Random();
        while (true)
        {
            List<DIRECTION> directions = new List<DIRECTION>();
            if (maze[_x, _y - 1] == WALL && maze[_x, _y - 2] == WALL)
                directions.Add(DIRECTION.UP);
            if (maze[_x + 1, _y] == WALL && maze[_x + 2, _y] == WALL)
                directions.Add(DIRECTION.RIGHT);
            if (maze[_x  ,_y + 1] == WALL && maze[_x , _y + 2] == WALL)
                directions.Add(DIRECTION.DOWN);
            if(maze[_x-1,_y] == WALL && maze[_x - 2, _y] == WALL)
                directions.Add(DIRECTION.LEFT);

            if (directions.Count == 0) break;
            SetPath(_x, _y);
            int directionIndex = rnd.Next(directions.Count);
            switch (directions[directionIndex])
            {
                case DIRECTION.UP:
                    SetPath(_x, --_y);
                    SetPath(_x, --_y);
                    break;
                case DIRECTION.RIGHT:
                    SetPath(++_x, _y);
                    SetPath(++_x, _y);
                    break;
                case DIRECTION.DOWN:
                    SetPath(_x, ++_y);
                    SetPath(_x, ++_y);
                    break;
                case DIRECTION.LEFT:
                    SetPath(--_x, _y);
                    SetPath(--_x, _y);
                    break;
            }
            
            //230927
            //if文でゴール地点の処理
            //231003
            if(simdata.isExitTrue == false)
            {
                //231004
                /*
                IndexOutOfRangeException: Index was outside the bounds of the array.
                MazeCreator.Dig(System.Int32 _x, System.Int32 _y)(at Assets / Scripts / MazeCreator.cs:139)
                MazeCreator.CreateMaze()(at Assets / Scripts / MazeCreator.cs:57)
                MapGenerator._loadMapData()(at Assets / Scripts / MapGenerator.cs:173)
                MapGenerator.Start()(at Assets / Scripts / MapGenerator.cs:125)
                */

                simdata.ExitPoint[simdata.pastExitPointx, simdata.pastExitPointy] = 0;

                simdata.ExitPoint[_x, _y] = 1;

                simdata.isExitTrue = true;

                //231003
                //digが呼ばれる度にisExitTrueをfalseにしてExitPointをリセットし最後のDigが反映されるようにする

                //231004
                simdata.pastExitPointx = _x;
                simdata.pastExitPointy = _y;
            }

            //231003
            //ゴール地点を近くしたりする処理
            simdata.isExitTrue = false;

            //231020
            //UnityEngine.Random.InitState(DateTime.Now.Millisecond);
            //simdata.RandomMapNum[_x, _y, 0] = UnityEngine.Random.Range(0, 4);
            //simdata.RandomMapNum[_x, _y, 0] = rnd.Next(1,4);

            //231021
            //mdata.RandomMapNum[_x, _y, 0] = (int)Random(2, 4);

            //UnityEngine.Random.InitState(DateTime.Now.Millisecond);
            //simdata.RandomMapNum[_x, _y, 1] = (int)UnityEngine.Random.Range(1f,4f);
            //simdata.RandomMapNum[_x, _y, 1] = rnd.Next(4);

            Cell cell = GetStartCell();
            if(cell != null)
            {
                Dig(cell.X, cell.Y);
            }
            
        }

    }

    void SetPath(int _x,int _y)
    {
        maze[_x, _y] = PATH;
        if(_x % 2 == 1 && _y %2 == 1)
        {
            startCells.Add(new Cell() { X = _x, Y = _y });
        }
    }

    Cell GetStartCell()
    {
        if (startCells.Count == 0) return null;
        System.Random rnd = new System.Random();
        int idx = rnd.Next(startCells.Count);
        Cell cell = startCells[idx];
        startCells.RemoveAt(idx);
        return cell;
    }

    //ランダム関数
    double Random(float rmin, float rmax)
    {
        System.Random rnd = new System.Random();

        double r = 0.0;
        r = (double)rnd.Next(32767) / (double)32767;
        r = r * (rmax - rmin) + rmin;
        return r;
    }

}

public class Cell
{
    public int X, Y;
}