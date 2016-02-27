using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

class GameSceneManager : MonoBehaviour, IController
{
    public GameSequenceData currentSequence;

    public const string CurrentSequenceToken = "CurrentSequence";

    void Awake()
    {
        Resolver.Instance.GetController<EventHandler>().Register(Events.GameStateTransition.TransitionTo, OnTransitionToState);

        //no matter what scene we start in, we want to begin with the null state
        Resolver.Instance.GetController<GameStateEngine>().ChangeGameState(GameStateEngine.States.NullState);
    }

    void OnTransitionToState(int id, object param)
    {
        GameStateEngine.States newState = (GameStateEngine.States)param;

        switch (newState)
        {
            case GameStateEngine.States.NullState:
                SceneManager.LoadScene("EmptyStartScene");
                break;
            case GameStateEngine.States.Title:
                SceneManager.LoadScene("Title");
                break;
            case GameStateEngine.States.Playing:
                LoadCurrentSequence();
                LoadSceneFromCurrentSequence();
                break;
            case GameStateEngine.States.GameOver:
                SceneManager.LoadScene("Title");
                break;
            case GameStateEngine.States.Credits:
                SceneManager.LoadScene("Credits");
                break;
            case GameStateEngine.States.Settings:
                SceneManager.LoadScene("Settings");
                break;
            default:
                Debug.LogError("Invalid state transition");
                break;
        }
    }

    #region IController

    public void Cleanup()
    {

    }

    #endregion IController

    private void LoadCurrentSequence()
    {
        int currentSequenceId = PlayerPrefs.GetInt(CurrentSequenceToken, 1);

        ConfigurationData configData = (ConfigurationData)Resolver.Instance.GetController<ConfigurationManager>().GetSettingValue(ConfigurationData.ConfigurationToken);

        foreach (GameSequenceData sequenceData in configData.gamesequence)
        {
            if (sequenceData.id == currentSequenceId)
            {
                currentSequence = sequenceData;
                break;
            }
        }
    }

    private void SaveCurrentSequence()
    {
        PlayerPrefs.SetInt(CurrentSequenceToken, currentSequence.id);
        PlayerPrefs.Save();
    }

    void LoadSceneFromCurrentSequence()
    {
        switch (currentSequence.type)
        {
            case "stories":
                SceneManager.LoadScene("Story");
                break;
            case "levels":
                SceneManager.LoadScene("Game");
                break;
            default:
                Debug.Log("Invalid Sequence Type in data");
                break;
        }
    }
}