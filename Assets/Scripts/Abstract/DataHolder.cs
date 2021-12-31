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

    public static void SetCannon(Cannon cannon)
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

    public static EffectsHandler EffectsHandler { get; private set; }

    public static void SetEffectsHandler(EffectsHandler effectsHandler)
    {
        EffectsHandler = effectsHandler;
    }

    public static Wizzard Wizzard { get; private set; }

    public static void SetWizzard(Wizzard wizzard)
    {
        Wizzard = wizzard;
    }
    public static UIHandler UIHandler;
    public static void SetUIHandler(UIHandler uiHandler)
    {
        UIHandler = uiHandler;
    }

    public static Labaratory Labaratory { get; private set; }
    
    public static void SetLabaratory(Labaratory labaratory)
    {
        Labaratory = labaratory;
    }

    public static SoundManager SoundManager { get; private set; }

    public static void SetSoundManager(SoundManager manager)
    {
        SoundManager = manager;
    }

}
