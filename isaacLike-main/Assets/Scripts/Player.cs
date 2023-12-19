using MoreMountains.CorgiEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public enum DIRECTION
    {
        UP,
        RIGHT,
        DOWN,
        LEFT,
        MAX
    }

    public DIRECTION direction;
    //230929
    public static Vector2Int currentPos, nextPos;

    int[,] move = { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };
    int[,,] locations = {
           {{-1,0 },{1,0 },{0,0 } },
           {{0,-1 },{0,1 },{0,0 } },
           {{1,0 },{-1,0 },{0,0 } },
           {{0,1 },{0,-1 },{0,0 } },
    };

    
    Button[] cursors;

    [SerializeField] Transform directionArrow;
    //230929
    //Vector3[] arrowPositions = new[] { new Vector3(0,0.35f), new Vector3(0.35f, 0), new Vector3(0f, -0.35f),new Vector3(-0.35f,0f) };

    public MapGenerator mapGenerator;

    private void Start()
    {

        //20230915
        /*cursors = mapGenerator.buttons.GetComponentsInChildren<Button>();
        cursors[(int)DIRECTION.UP].onClick.AddListener(() => MoveForward());
        cursors[(int)DIRECTION.RIGHT].onClick.AddListener(() => TurnRight());
        cursors[(int)DIRECTION.DOWN].onClick.AddListener(() => TurnBack());
        cursors[(int)DIRECTION.LEFT].onClick.AddListener(() => TurnLeft());*/

        //231021
        //direction = DIRECTION.DOWN;
        //_viewArrow();

        //230927
        //mapGenerator.ResetView3D();
        _getMapPositions();
        //230926
        //mapGenerator._createMap2();
        //_move();
        
        //230927
        
        for(int i = 0; i < MapGenerator.mazeDatas.GetLength(0); i++)
        {
            for(int j = 0; j < MapGenerator.mazeDatas.GetLength(1); j++)
            {
                if(MapGenerator.mazeDatas[i, j] == 2)
                {
                    currentPos = new Vector2Int(i, j);
                    Debug.Log(currentPos);
                }
            }
        }
        
    }


    void MoveForward()
    {
        mapGenerator.ResetView3D();
        _move();
        _getMapPositions();
    }

    void TurnRight()
    {
        mapGenerator.ResetView3D();
        direction++;
        _setDirection();
        _viewArrow();
        _getMapPositions();
    }

    void TurnBack()
    {
        mapGenerator.ResetView3D();
        direction += 2;
        _setDirection();
        _viewArrow();
        _getMapPositions();
    }
    void TurnLeft()
    {
        mapGenerator.ResetView3D();
        direction--;
        _setDirection();
        _viewArrow();
        _getMapPositions();
    }
    



    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            mapGenerator.ResetView3D();
            _move();
            _getMapPositions();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mapGenerator.ResetView3D();
            direction++;
            _setDirection();
            _viewArrow();
            _getMapPositions();

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            mapGenerator.ResetView3D();
            direction += 2;
            _setDirection();
            _viewArrow();
            _getMapPositions();

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mapGenerator.ResetView3D();
            direction--;
            _setDirection();
            _viewArrow();
            _getMapPositions();

        }*/
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = DIRECTION.UP;
            _move();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = DIRECTION.RIGHT;
            _move();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = DIRECTION.DOWN;
            _move();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = DIRECTION.LEFT;
            _move();
        }
    }

    void _setDirection()
    {
        int d = ((int)direction + (int)DIRECTION.MAX) % (int)DIRECTION.MAX;
        direction = (DIRECTION)d;
        
    }

    void _viewArrow()
    {
        //230929
        //directionArrow.localPosition = arrowPositions[(int)direction];
    }
    

    public void _move()
    {
        nextPos = currentPos + new Vector2Int(move[(int)direction, 0], move[(int)direction, 1]);
        
        //230927
        Debug.Log(mapGenerator.GetNextMapType(nextPos));

        //230929
        //if(mapGenerator.GetNextMapType(nextPos) != MapGenerator.MAP_TYPE.WALL)

        if (mapGenerator.GetNextMapType(nextPos) != 1)
        {
            //230927
            MapGenerator.mazeDatas[nextPos.x, nextPos.y] = 2;
            MapGenerator.mazeDatas[currentPos.x, currentPos.y] = 0;
            for (int i = 0; i < MapGenerator.mazeDatas.GetLength(0); i++)
            {
                string str = "";
                for (int j = 0; j < MapGenerator.mazeDatas.GetLength(1); j++)
                {
                    str = str + MapGenerator.mazeDatas[i, j] + " ";
                }
                Debug.Log(str);
            }

            transform.localPosition = mapGenerator.ScreenPos(nextPos);
            currentPos = nextPos;
            //2023/09/19
            //mapGenerator._createMap();
            //230927
        }



    }

    public void _move_Anywhere(string direction)
    {
        //230929
        mapGenerator = new MapGenerator();

        switch (direction)
        {
            case "Up":

                nextPos = currentPos + new Vector2Int(move[0, 0], move[0, 1]);

                //230927
                Debug.Log(mapGenerator.GetNextMapType(nextPos));

                if (mapGenerator.GetNextMapType(nextPos) != 1)
                {
                    Debug.Log("not a wall");
                    Debug.Log("nextPos is");
                    Debug.Log(nextPos);
                    Debug.Log("currentPos is");
                    Debug.Log(currentPos);

                    //230927
                    MapGenerator.mazeDatas[nextPos.x, nextPos.y] = 2;
                    MapGenerator.mazeDatas[currentPos.x, currentPos.y] = 0;
                    for (int i = 0; i < MapGenerator.mazeDatas.GetLength(0); i++)
                    {
                        string str = "";
                        for (int j = 0; j < MapGenerator.mazeDatas.GetLength(1); j++)
                        {
                            str = str + MapGenerator.mazeDatas[i, j] + " ";
                        }
                        Debug.Log(str);
                    }
                    //230929
                    //transform.localPosition = mapGenerator.ScreenPos(nextPos);
                    currentPos = nextPos;
                    //2023/09/19
                    //mapGenerator._createMap();
                    //230927
                }

                /*
                //230927
                MapGenerator.mazeDatas[nextPos.x, nextPos.y] = 2;
                MapGenerator.mazeDatas[currentPos.x, currentPos.y] = 0;
                for (int i = 0; i < MapGenerator.mazeDatas.GetLength(0); i++)
                {
                    string str = "";
                    for (int j = 0; j < MapGenerator.mazeDatas.GetLength(1); j++)
                    {
                        str = str + MapGenerator.mazeDatas[i, j] + " ";
                    }
                    Debug.Log(str);
                }

                //transform.localPosition = mapGenerator.ScreenPos(nextPos);
                currentPos = nextPos;
                */

                Debug.Log("move up");
                break;
            case "Right":
                nextPos = currentPos + new Vector2Int(move[1, 0], move[1, 1]);

                //230927
                Debug.Log(mapGenerator.GetNextMapType(nextPos));

                if (mapGenerator.GetNextMapType(nextPos) != 1)
                {
                    Debug.Log("not a wall");
                    Debug.Log("nextPos is");
                    Debug.Log(nextPos);
                    Debug.Log("currentPos is");
                    Debug.Log(currentPos);

                    //230927
                    MapGenerator.mazeDatas[nextPos.x, nextPos.y] = 2;
                    MapGenerator.mazeDatas[currentPos.x, currentPos.y] = 0;
                    for (int i = 0; i < MapGenerator.mazeDatas.GetLength(0); i++)
                    {
                        string str = "";
                        for (int j = 0; j < MapGenerator.mazeDatas.GetLength(1); j++)
                        {
                            str = str + MapGenerator.mazeDatas[i, j] + " ";
                        }
                        Debug.Log(str);
                    }
                    //230929
                    //transform.localPosition = mapGenerator.ScreenPos(nextPos);
                    currentPos = nextPos;
                    //2023/09/19
                    //mapGenerator._createMap();
                    //230927
                }

                /*
                //230927
                MapGenerator.mazeDatas[nextPos.x, nextPos.y] = 2;
                MapGenerator.mazeDatas[currentPos.x, currentPos.y] = 0;
                for (int i = 0; i < MapGenerator.mazeDatas.GetLength(0); i++)
                {
                    string str = "";
                    for (int j = 0; j < MapGenerator.mazeDatas.GetLength(1); j++)
                    {
                        str = str + MapGenerator.mazeDatas[i, j] + " ";
                    }
                    Debug.Log(str);
                }

                //transform.localPosition = mapGenerator.ScreenPos(nextPos);
                currentPos = nextPos;
                */

                Debug.Log("a wall");
                break;
            case "Down":
                nextPos = currentPos + new Vector2Int(move[2, 0], move[2, 1]);

                //230927
                Debug.Log(mapGenerator.GetNextMapType(nextPos));

                if (mapGenerator.GetNextMapType(nextPos) != 1)
                {
                    Debug.Log("not a wall");
                    Debug.Log("nextPos is");
                    Debug.Log(nextPos);
                    Debug.Log("currentPos is");
                    Debug.Log(currentPos);

                    //230927
                    MapGenerator.mazeDatas[nextPos.x, nextPos.y] = 2;
                    MapGenerator.mazeDatas[currentPos.x, currentPos.y] = 0;
                    for (int i = 0; i < MapGenerator.mazeDatas.GetLength(0); i++)
                    {
                        string str = "";
                        for (int j = 0; j < MapGenerator.mazeDatas.GetLength(1); j++)
                        {
                            str = str + MapGenerator.mazeDatas[i, j] + " ";
                        }
                        Debug.Log(str);
                    }
                    //230929
                    //transform.localPosition = mapGenerator.ScreenPos(nextPos);
                    currentPos = nextPos;
                    //2023/09/19
                    //mapGenerator._createMap();
                    //230927
                    Debug.Log("moved down");
                }

                /*
                //230927
                MapGenerator.mazeDatas[nextPos.x, nextPos.y] = 2;
                MapGenerator.mazeDatas[currentPos.x, currentPos.y] = 0;
                for (int i = 0; i < MapGenerator.mazeDatas.GetLength(0); i++)
                {
                    string str = "";
                    for (int j = 0; j < MapGenerator.mazeDatas.GetLength(1); j++)
                    {
                        str = str + MapGenerator.mazeDatas[i, j] + " ";
                    }
                    Debug.Log(str);
                }

                //transform.localPosition = mapGenerator.ScreenPos(nextPos);
                currentPos = nextPos;
                */

                Debug.Log("move down");
                break;
            case "Left":
                nextPos = currentPos + new Vector2Int(move[3, 0], move[3, 1]);

                //230927
                Debug.Log(mapGenerator.GetNextMapType(nextPos));

                if (mapGenerator.GetNextMapType(nextPos) != 1)
                {
                    Debug.Log("not a wall");
                    Debug.Log("nextPos is");
                    Debug.Log(nextPos);
                    Debug.Log("currentPos is");
                    Debug.Log(currentPos);

                    //230927
                    MapGenerator.mazeDatas[nextPos.x, nextPos.y] = 2;
                    MapGenerator.mazeDatas[currentPos.x, currentPos.y] = 0;
                    for (int i = 0; i < MapGenerator.mazeDatas.GetLength(0); i++)
                    {
                        string str = "";
                        for (int j = 0; j < MapGenerator.mazeDatas.GetLength(1); j++)
                        {
                            str = str + MapGenerator.mazeDatas[i, j] + " ";
                        }
                        Debug.Log(str);
                    }
                    //230929
                    //transform.localPosition = mapGenerator.ScreenPos(nextPos);
                    currentPos = nextPos;
                    //2023/09/19
                    //mapGenerator._createMap();
                    //230927
                }

                /*
                //230927
                MapGenerator.mazeDatas[nextPos.x, nextPos.y] = 2;
                MapGenerator.mazeDatas[currentPos.x, currentPos.y] = 0;
                for (int i = 0; i < MapGenerator.mazeDatas.GetLength(0); i++)
                {
                    string str = "";
                    for (int j = 0; j < MapGenerator.mazeDatas.GetLength(1); j++)
                    {
                        str = str + MapGenerator.mazeDatas[i, j] + " ";
                    }
                    Debug.Log(str);
                }

                //transform.localPosition = mapGenerator.ScreenPos(nextPos);
                currentPos = nextPos;
                */

                Debug.Log("a wall");
                break;
            default:
                Console.WriteLine("Unknown message type.");
                break;
        }
    }

    void _getMapPositions()
    {
        int depth = 3;
        int width = 2;
        
        for (int d = depth; d >= 0; d--)
        {
            for (int w = 0; w <= width; w++)
            {
                //230926
                /*int mapX = currentPos.x + locations[(int)direction, w, 0] + move[(int)direction, 0] * d;
                int mapY = currentPos.y + locations[(int)direction, w, 1] + move[(int)direction, 1] * d;
                if(mapX >= 0 && mapX < mapGenerator.w && mapY >=0 && mapY < mapGenerator.h)
                {
                    
                    if (mapGenerator.GetNextMapType(new Vector2Int(mapX, mapY)) == MapGenerator.MAP_TYPE.WALL)
                    {
                        int idx = d * depth + width - w;
                        mapGenerator.View3D(idx);
                    }

                }
                */
            }
        }
    }
}
