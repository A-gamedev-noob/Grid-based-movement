using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    
    public Vector2Int _dimensions = new Vector2Int(4,4);
    Vector2Int _pos;
    Dictionary<Vector2Int,Vector2Int> _grid = new Dictionary<Vector2Int, Vector2Int>();
    [SerializeField] GameObject _spawn;

    void Start() 
    {
        GridFormation();
    }

    public bool GridAvailable(Vector2Int Key)
    {
        if(_grid.ContainsKey(Key))
            return true;
        return false;
    }

    void GridFormation()
    {
        Vector2Int Pos = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        for(int x=0; x<_dimensions.x; x++)
        {
            for(int y=0; y<_dimensions.y; y++)
            {
                Vector2Int Key = new Vector2Int(Pos.x + x, Pos.y + y);
                _grid.Add(Key,Key);
            }
        }
        for (int x = 0; x < _dimensions.x; x++)
        {
            for (int y = 0; y < _dimensions.y; y++)
            {
                Vector2Int Key = new Vector2Int(Pos.x + x,Pos.y + y);
                if(_grid.ContainsKey(Key))
                {
                    GameObject spawn = Instantiate(_spawn, (Vector3Int)Key, Quaternion.identity);
                    spawn.name = Key.ToString();
                    spawn.transform.parent = this.gameObject.transform;
                }
            }
        }
      
    }

}
