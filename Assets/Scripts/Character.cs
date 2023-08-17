using UnityEngine;

public abstract class Character : MonoBehaviour
{
    /// <summary> Скорость персонажа.</summary>
    [SerializeField] private float _speed;

    /// <summary> Аниматор персонажа.</summary>
    private Animator _animator;

    /// <summary> Направление движения персонажа.</summary>
    protected Vector2 _direction;

    #region MonoBehaviour
    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Move();
    }
    #endregion

    /// <summary> Передвижение персонажа.</summary>
    protected void Move()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);

        if (_direction.x != 0 || _direction.y != 0)
        {
            // Перемещаемся
            AnimateMovement(_direction);
        }
        else
        {
            // Не перемещаемся
            _animator.SetLayerWeight(1, 0);
        }
    }

    /// <summary> Анимировать движение по направлению.</summary>
    /// <param name="direction"> Направление движения.</param>
    private void AnimateMovement(Vector2 direction)
    {
        _animator.SetLayerWeight(1, 1);

        _animator.SetFloat("x", direction.x);
        _animator.SetFloat("y", direction.y);
    }
}
