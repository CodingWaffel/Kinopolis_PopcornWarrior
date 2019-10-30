using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MenuElement
{
    public override void Activate()
    {
        SceneChanger.instance.ChangeSceneToWithoutEndCapturing("Game");
    }
}
