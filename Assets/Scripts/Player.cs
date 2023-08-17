using Newtonsoft.Json.Linq;
using UnityEngine;

public class Player : Character
{
    /// <summary> Полоса здоровья.</summary>
    [SerializeField] private Bar _healthBar;

    /// <summary> Полоса маны.</summary>
    [SerializeField] private Bar _manaBar;

    /// <summary> Максимальное значение здоровья.</summary>
    private const float MaxHealth = 100f;

    /// <summary> Максимальное значение здоровья.</summary>
    private const float MaxMana = 50f;

    #region MonoBehaviour
    protected override void Start()
    {
        base.Start();
        _healthBar.Initialize(MaxHealth, MaxHealth);
        _manaBar.Initialize(MaxMana, MaxMana);
    }

    protected override void Update()
    {
        base.Update();
        GetInput();

        // DEBUG
        if (Input.GetKeyDown(KeyCode.P))
        {
            _healthBar.CurrentValue -= 30;
            _manaBar.CurrentValue -= 20;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            _healthBar.CurrentValue += 30;
            _manaBar.CurrentValue += 20;
        }
    }
    #endregion

    #region Private Methods
    /// <summary> Обработка ввода игрока.</summary>
    private void GetInput()
    {
        _direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _direction += Vector2.right;
        }
    }
    #endregion
}
