using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text healthLabel;
    [SerializeField] InventoryPopup popup;
    [SerializeField] TMP_Text levelEnding;

    void OnEnable()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
        Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.AddListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
        Messenger.AddListener(GameEvent.GAME_COMPLETE, OnGameComplete);
    }

    void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.RemoveListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
        Messenger.RemoveListener(GameEvent.GAME_COMPLETE, OnGameComplete);
    }

    void Start()
    {
        OnHealthUpdated();

        popup.gameObject.SetActive(false);
        levelEnding.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            {
            bool isShowing = popup.gameObject.activeSelf;
            popup.gameObject.SetActive(!isShowing);
            popup.Refresh();
        }
    }

    private void OnHealthUpdated()
    {
        string message = $"Health:" +
            $"{Managers.Player.health}/{Managers.Player.maxHealth}";
        healthLabel.text = message;
    }

    private void OnLevelComplete()
    {
        StartCoroutine(CompleteLevel());
    }

    private IEnumerator CompleteLevel()
    {
        levelEnding.gameObject.SetActive (true);
        levelEnding.text = "Level Complete!";

        yield return new WaitForSeconds(2);

        Managers.Mission.GoToNext();
    }

    private void OnLevelFailed()
    {
        StartCoroutine(FailLevel());
    }

    private IEnumerator FailLevel()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "Level Failed";

        yield return new WaitForSeconds(2);

        Managers.Player.Respawn();
        Managers.Mission.RestartCurrent();
    }

    public void SaveGame()
    {
        Managers.Data.SaveGameState();
    }

    public void LoadGame()
    {
        Managers.Data.LoadGameState();
    }

    public void OnGameComplete()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "You Finished the Game!";
    }
}
