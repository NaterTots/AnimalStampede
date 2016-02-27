using UnityEngine;
using System.Collections;

public class TitleScreenCanvas : MonoBehaviour
{
	public void OnStartGame()
    {
        Resolver.Instance.GetController<GameStateEngine>().ChangeGameState(GameStateEngine.States.Playing);
    }
}
