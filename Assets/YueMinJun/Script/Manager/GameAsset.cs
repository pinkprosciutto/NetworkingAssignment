using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAsset : MonoBehaviour
{
    public static GameAsset Instance { get; private set; }
    public Sprite pipeHeadSprite;

    private void Awake()
    {
        Instance = this;
    }


}
