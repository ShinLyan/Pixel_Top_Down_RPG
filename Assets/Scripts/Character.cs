using UnityEngine;

public abstract class Character : MonoBehaviour
{
    /// <summary> �������� ���������.</summary>
    [SerializeField] private float _speed;

    /// <summary> �������� ���������.</summary>
    private Animator _animator;

    /// <summary> ����������� �������� ���������.</summary>
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

    /// <summary> ������������ ���������.</summary>
    protected void Move()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);

        if (_direction.x != 0 || _direction.y != 0)
        {
            // ������������
            AnimateMovement(_direction);
        }
        else
        {
            // �� ������������
            _animator.SetLayerWeight(1, 0);
        }
    }

    /// <summary> ����������� �������� �� �����������.</summary>
    /// <param name="direction"> ����������� ��������.</param>
    private void AnimateMovement(Vector2 direction)
    {
        _animator.SetLayerWeight(1, 1);

        _animator.SetFloat("x", direction.x);
        _animator.SetFloat("y", direction.y);
    }
}
