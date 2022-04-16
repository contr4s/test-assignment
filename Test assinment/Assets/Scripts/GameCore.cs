using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

/// <summary>
/// Controls the game state
/// </summary>
public class GameCore: MonoBehaviour
{
    [SerializeField] private Ball _ball;

    [SerializeField]
    private UIController _uIController = new();
    private InputController _inputController;
    private Timer _timer = new();

    private Result? _prevResult;
    private Coroutine _timerRoutine;

    private void OnEnable()
    {
        _ball.OutOfTheTrack += Lose;
        _ball.FinishTrack += Win;
        _inputController.CloseButtonPressed += GoBackToMainScreen;
        _inputController.MoveButtonPressed += _ball.Move;
    }

    private void OnDisable()
    {
        _ball.OutOfTheTrack -= Lose;
        _ball.FinishTrack += Win;
        _inputController.CloseButtonPressed -= GoBackToMainScreen;
        _inputController.MoveButtonPressed -= _ball.Move;
    }

    private void Awake()
    {
        _inputController = new InputController(_ball);
    }

    void Start()
    {
        GoBackToMainScreen();
    }

    void Update()
    {
        _inputController.CheckInput();
    }

    public void StartGame()
    {
        _uIController.SetStartScreenActive(false);
        _ball.SetupDefaults();
        if (!(_timerRoutine is null))
            StopCoroutine(_timerRoutine);
        _timerRoutine = StartCoroutine(_timer.CountDown());
    }

    public void GoBackToMainScreen()
    {
        _uIController.CloseResultsScreen();
        _uIController.SetStartScreenActive(true);
        _ball.SetupDefaults();
    }

    public void Lose()
    {
        _timer.Stop();
        _ball.SetupDefaults();
        var result = new Result(Result.ResultType.Lose);
        _uIController.ShowResult(result);
        _prevResult = result;
    }

    public void Win()
    {
        float time = _timer.Stop();
        _ball.SetupDefaults();
        var result = new Result(Result.ResultType.Victory, time);
        _uIController.ShowResult(result);
        _prevResult = result;
    }

    public void ShowPrevResult()
    {
        _uIController.ShowResult(_prevResult);
        _uIController.SetStartScreenActive(false);
    }
}
