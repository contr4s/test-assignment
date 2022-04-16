using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using TMPro;
using UnityEngine;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _title;
    [SerializeField] TextMeshProUGUI _timeDisplay;

    public void Setup(Result? result)
    {
        if (!result.HasValue)
        {
            _title.text = "You haven't got any results yet";
            _title.color = Color.white;
            gameObject.SetActive(true);
            _timeDisplay.gameObject.SetActive(false);
            return;
        }

        string title = result.Value.Type switch
        {
            Result.ResultType.Lose => "Game Over",
            Result.ResultType.Victory => "You Won",
            _ => "unknown result",
        };
        Color color = result.Value.Type switch
        {
            Result.ResultType.Lose => Color.red,
            Result.ResultType.Victory => Color.green,
            _ => Color.clear,
        };
        _title.text = title;
        _title.color = color;

        _timeDisplay.gameObject.SetActive(result.Value.Type == Result.ResultType.Victory);
        _timeDisplay.text = $"Time spent: {result.Value.TimeSpent:F2}s";

        gameObject.SetActive(true);
    }
}
