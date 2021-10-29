using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder 
{
    public static Game Game { get; private set; }
    public static void SetGame(Game game) 
    {
        Game = game;
    }

    public static Cannon Cannon { get; private set; }

    public static void  SetCannon(Cannon cannon)
    {
        Cannon = cannon;
    }

    public static Camera MainCamera { get; private set; }

    public static void SetMainCamera(Camera mainCamera)
    {
        MainCamera = mainCamera;
    }

    public static Factory Factory { get; private set; }

    public static void SetFactory(Factory factory)
    {
        Factory = factory; 
    }
}
