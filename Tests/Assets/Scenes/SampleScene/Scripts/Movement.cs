using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] Swipe_Controls _swipe;
    [SerializeField] Grid _gS;
    public int _steps = 1;
    Vector2Int[] _directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Step();
    }

    void Step()
    {
        Vector2Int Pos = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        if(_swipe._swipeUp)
        {
            Vector2Int Key = Pos + _directions[0]; ;
            for(int x=1;x<=_steps;x++)
            {
                Vector2Int tempKey = Pos + _directions[0];
                Pos = tempKey;
                if(_gS.GridAvailable(tempKey))
                    Key = tempKey;
            }
            
            if(_gS.GridAvailable(Key))
            {
                transform.position = new Vector3(Key.x, Key.y, transform.position.z);
            }
        }
        if (_swipe._swipeRight)
        {

            Vector2Int Key = Pos + _directions[1];
            for (int x = 1; x <= _steps; x++)
            {
                Vector2Int tempKey = Pos + _directions[1];
                Pos = tempKey;
                if (_gS.GridAvailable(tempKey))
                    Key = tempKey;
            }
            if (_gS.GridAvailable(Key))
            {
                transform.position = new Vector3(Key.x, Key.y, transform.position.z);
            }
        }
        if (_swipe._swipeDown)
        {

            Vector2Int Key = Pos + _directions[2];
            for (int x = 1; x <= _steps; x++)
            {
                Vector2Int tempKey = Pos + _directions[2];
                Pos = tempKey;
                if (_gS.GridAvailable(tempKey))
                    Key = tempKey;
            }
            if (_gS.GridAvailable(Key))
            {
                transform.position = new Vector3(Key.x, Key.y, transform.position.z);
            }
        }
        if (_swipe._swipeLeft)
        {
            Vector2Int Key = Pos + _directions[3];
            for (int x = 1; x <= _steps; x++)
            {
                Vector2Int tempKey = Pos + _directions[3];
                Pos = tempKey;
                if (_gS.GridAvailable(tempKey))
                    Key = tempKey;
            }
            if (_gS.GridAvailable(Key))
            {
                transform.position = new Vector3(Key.x, Key.y, transform.position.z);
            }
        }
    }
}
