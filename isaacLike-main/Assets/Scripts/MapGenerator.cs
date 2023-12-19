//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoreMountains.InventoryEngine;
//using static UnityEditor.PlayerSettings;


public class MapGenerator : MonoBehaviour
{
    [SerializeField] TextAsset mapText;
    [SerializeField] GameObject[] prefabs;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject BossSpawn;
    [SerializeField] Transform map2D;
    [SerializeField] WallsArr[] wallsArr;
    //public GameObject buttons;
    MazeCreator maze;
    public static int[,] mazeDatas;
    public enum MAP_TYPE
    {
        GROUND, //0
        WALL,   //1
        PLAYER  //2
    }
    MAP_TYPE[,] mapTable;
    float mapSize;
    Vector2 centerPos;
    public int w, h;

    //230927
    //public static int createmazeflag;

    //231003
    public int row, col;
    
    //231114
    public Inventory testInventory { get; set; }

    void Start()
    {
        //231101
        w = Random.Range(11,19);
        h = Random.Range(11, 19);

        if (w % 2 == 0) w++;
        if (h % 2 == 0) h++;

        int r = 0;
        Debug.Log("w =" + w);
        Debug.Log("h =" + h);

        switch (w)
        {
            case 13:
                r = Random.Range(0, 1);
                Debug.Log("w case13. r=" + r);
                switch (r)
                {
                    case 0:
                        w += 2;
                    break;

                    case 1:
                        w -= 2;
                    break;
                }

            break;

            case 17:
                r = Random.Range(0, 1);
                Debug.Log("w case17. r=" + r);
                switch (r)
                {
                    case 0:
                        w += 2;
                        break;

                    case 1:
                        w -= 2;
                        break;
                }
            break;
        }

        switch (h)
        {
            case 13:
                r = Random.Range(0, 1);
                Debug.Log("h case13. r=" + r);
                switch (r)
                {
                    case 0:
                        h += 2;
                        break;

                    case 1:
                        h -= 2;
                        break;
                }

                break;

            case 17:
                r = Random.Range(0, 1);
                Debug.Log("h case17. r=" + r);
                switch (r)
                {
                    case 0:
                        h += 2;
                        break;

                    case 1:
                        h -= 2;
                        break;
                }
                break;
        }

        //w = 11;
        //h = 11;


        
        //230927
        Debug.Log(simdata.createmazeflag);

        _loadMapData();
        _createMap();

        //230927
        simdata.createmazeflag = 1;
        Debug.Log(mazeDatas);
        for (int i = 0; i < mazeDatas.GetLength(0); i++)
        {
            string str = "";
            for (int j = 0; j < mazeDatas.GetLength(1); j++)
            {
                str = str + mazeDatas[i, j] + " ";
            }
            Debug.Log(str);
        }
        //230926
        //map2D.position = new Vector3(5f, 0);

        //230929
        simdata.EntryPoints = mazeDatas;
    }

    void _loadMapData()
    {
        maze = new MazeCreator(w, h);

        //230927
        if (simdata.createmazeflag == 0)
        {
            mazeDatas = new int[w, h];

            //231003
            row = mazeDatas.GetLength(1);
            col = mazeDatas.GetLength(0);
            simdata.ExitPoint = new int[col, row];
            for (int y = 0; y < row; y++)
            {
                for (int x = 0; x < col; x++)
                {

                    //231003
                    simdata.ExitPoint[x, y] = 0;
                }
            }

            //231020 ランダムマップ用変数初期化
            simdata.RandomMapNum = new int[col, row, 2];

            mazeDatas = maze.CreateMaze();
            //キャラクターの位置設定
            mazeDatas[w / 2, h / 2] = 2;


        }

        //231021
        //simdata.createmazeflag = 1;

        //231003
        //int row = mazeDatas.GetLength(1);
        //int col = mazeDatas.GetLength(0);
        row = mazeDatas.GetLength(1);
        col = mazeDatas.GetLength(0);

        mapTable = new MAP_TYPE[col, row];

        for(int y = 0;y < row; y++)
        {
            for(int x = 0;x < col; x++)
            {
                mapTable[x, y] = (MAP_TYPE)mazeDatas[x, y];
                //231003
              //simdata.ExitPoint[x, y] = 0;
            }
        }

    }

    public void _createMap()
    {
        //mapSize = prefabs[1].GetComponent<SpriteRenderer>().bounds.size.x;
        mapSize = prefabs[1].GetComponent<RectTransform>().rect.width;

        Debug.Log(mapSize);
        Debug.Log("creating map...");


        //231114
        if (simdata.isInventorySaved == false)
        {
            //testInventory.SaveInventory();
        }
        simdata.isInventorySaved = true;
        if (testInventory != null)
        {
            testInventory.LoadSavedInventory();
            Debug.Log("Loaded Inventory");
        }


        if (mapTable.GetLength(0) % 2 == 0)
        {
            centerPos.x = mapTable.GetLength(0) / 2 * mapSize - (mapSize / 2);
            //centerPos.x = this.transform.position.x;
        }
        else
        {
            centerPos.x = mapTable.GetLength(0) / 2 * mapSize;
            //centerPos.x = this.transform.position.x;
        }
        
        if(mapTable.GetLength(1) % 2 == 0)
        {
            centerPos.y = mapTable.GetLength(1) / 2 * mapSize - ( mapSize / 2);
            //centerPos.y = this.transform.position.y;
        }
        else
        {
            centerPos.y = mapTable.GetLength(1) / 2 * mapSize;
            //centerPos.y = this.transform.position.y;
        }
        

        for (int y = 0;y < mapTable.GetLength(1); y++)
        {
            for(int x = 0;x < mapTable.GetLength(0); x++)
            {
                /* 230927
                Vector2Int pos = new Vector2Int(x, y);
                GameObject _ground  = Instantiate(prefabs[(int)MAP_TYPE.GROUND],map2D);
                GameObject _map = Instantiate(prefabs[(int)mapTable[x,y]],map2D);
                _ground.transform.localPosition = ScreenPos(pos);
                
                _map.transform.localPosition = ScreenPos(pos);
                */

                Vector2Int pos = new Vector2Int(x, y);
                GameObject _ground = Instantiate(prefabs[(int)MAP_TYPE.GROUND], map2D);
                _ground.transform.localPosition = ScreenPos(pos);

                if (mapTable[x, y] == MAP_TYPE.WALL)
                {
                    GameObject _map = Instantiate(prefabs[(int)MAP_TYPE.WALL], map2D);
                    _map.transform.localPosition = ScreenPos(pos);
                }


                //231003 ボススポーン
                if (simdata.ExitPoint[x, y] == 1)
                {
                    GameObject _exit = Instantiate(prefabs[3], map2D);
                    _exit.transform.localPosition = ScreenPos(pos);

                    Vector2Int pos2 = new Vector2Int(x, y);

                    if(Player.currentPos == pos2)
                    {
                        Vector3 boss_pos = BossSpawn.transform.position;
                        simdata.BossGameObject = Instantiate(boss, boss_pos, Quaternion.identity);
                    }
                }


                if (mapTable[x,y] == MAP_TYPE.PLAYER)
                {
                    GameObject _player = Instantiate(prefabs[(int)MAP_TYPE.PLAYER], map2D);
                    _player.transform.localPosition = ScreenPos(pos);
                    //230929
                    //_player.GetComponent<Player>().currentPos = pos;
                    _player.GetComponent<Player>().mapGenerator = this;
                }

                //230926
                /*if (x == 1 && y == 1)
                {
                    GameObject _player = Instantiate(prefabs[2], map2D);
                    _player.transform.localPosition = ScreenPos(pos);
                    _player.GetComponent<Player>().currentPos = pos;
                    _player.GetComponent<Player>().mapGenerator = this;
                }*/

            }
        }
        //230926
        /*
        Vector2Int pos2 = new Vector2Int(1, 1);
        GameObject _player = Instantiate(prefabs[2], map2D);
        _player.transform.localPosition = ScreenPos(pos2);
        _player.GetComponent<Player>().currentPos = pos2;
        _player.GetComponent<Player>().mapGenerator = this;
        */
    }

    //230926
    public void _createMap2()
    {
        mapSize = prefabs[1].GetComponent<SpriteRenderer>().bounds.size.x;

        Debug.Log(mapSize);

        if (mapTable.GetLength(0) % 2 == 0)
        {
            centerPos.x = mapTable.GetLength(0) / 2 * mapSize - (mapSize / 2);
            //centerPos.x = this.transform.position.x;
        }
        else
        {
            centerPos.x = mapTable.GetLength(0) / 2 * mapSize;
            //centerPos.x = this.transform.position.x;
        }

        if (mapTable.GetLength(1) % 2 == 0)
        {
            centerPos.y = mapTable.GetLength(1) / 2 * mapSize - (mapSize / 2);
            //centerPos.y = this.transform.position.y;
        }
        else
        {
            centerPos.y = mapTable.GetLength(1) / 2 * mapSize;
            //centerPos.y = this.transform.position.y;
        }


        for (int y = 0; y < mapTable.GetLength(1); y++)
        {
            for (int x = 0; x < mapTable.GetLength(0); x++)
            {
                Vector2Int pos = new Vector2Int(x, y);
                GameObject _ground = Instantiate(prefabs[(int)MAP_TYPE.GROUND], map2D);
                GameObject _map = Instantiate(prefabs[(int)mapTable[x, y]], map2D);
                _ground.transform.position = ScreenPos(pos);

                _map.transform.position = ScreenPos(pos);
            }
        }
    }

    public Vector2 ScreenPos(Vector2Int _pos)
    {
        return new Vector2(
            _pos.x * mapSize - centerPos.x  ,
            -(_pos.y * mapSize - centerPos.y));
    }

    //230929
    //public MAP_TYPE GetNextMapType(Vector2Int _pos)
    public int GetNextMapType(Vector2Int _pos)
    {
        //230929
        //return mapTable[_pos.x, _pos.y];

        return mazeDatas[_pos.x, _pos.y];
    }

    public void View3D(int _idx)
    {
        //20230926
        /*foreach(GameObject wall in wallsArr[_idx].wall)
        {
            wall.SetActive(true);
        }*/
    }

    public void ResetView3D()
    {
        foreach (WallsArr walls in wallsArr)
        {
            foreach(GameObject wall in walls.wall)
            {
                wall.SetActive(false);
            }
        }
    }
}


[System.Serializable]
public class WallsArr
{
    public GameObject[] wall;
}