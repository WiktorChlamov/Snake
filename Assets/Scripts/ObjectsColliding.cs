using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsColliding 
{
    private float _destroyTime = 0.1f;
    private Snake _snake;
    private Collide _target;
    private GameManager _gameManager;

    public ObjectsColliding(Snake snake, Collide target, GameManager gameManager)
    {
        _snake = snake;
        _target = target;
        _gameManager = gameManager;
    }

    public void Colliding()
    {
        switch(_target)
        {
            case Human human:
                HumanCollide(human);
                break;
            case Crystal _:
                CrystalCollide();
                break;
            case ColorfullLine colorfullLine:
                ColorchangerCollide(colorfullLine.BodyColor.Material);
                break;
            case Wall _:
                WallCollide();
                break;
            case Win win:
                win.WinGame();
                break;
        }
    }

    private void HumanCollide(Human human)
    {
        human.StartMoving(_snake.transform, _snake.PullSpeed);
        human.Destroy(_destroyTime);
        if (human.BodyColor.Material == _snake.BodyColor.Material || _snake.IsFever)
        {
            _snake.EatHuman();
            _gameManager.AddEaten();
        }
        else
        {
            PlayerDie();
        }
    }

    private void ColorchangerCollide(Material material)
    {
        _snake.StartChangeColor(material);
    }

    private void CrystalCollide()
    {
        _gameManager.AddCrystal(out int count);
        if (count > 3 && !_snake.IsFever)
        {
            _snake.StartFever();
        }
       _target.Destroy();
    }

    private void WallCollide()
    {
        if (!_snake.IsFever)
            PlayerDie();
        else
           _target.Destroy();
    }

    private void PlayerDie()
    {
        _snake.Stop();
        _gameManager.GameOver();
    }
}
