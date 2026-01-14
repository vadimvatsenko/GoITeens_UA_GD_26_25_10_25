using RPG_Monochrome.Data.Sprites;
using RPG_Monochrome.Engine;

namespace RPG_Monochrome;

public class Ghost : Creature, IUpdatable
{
    private Vector2 _direction = Vector2.Right;
    private readonly double _speed = 20;
    
    private readonly Hero _hero;
    private readonly Map _map;

    private Vector2 _targetPosition;
    private int _indexPatrol = 0;
    private List<Vector2> _patrolPoints = new List<Vector2>(4);
    
    private double _timer = 0;
    private double _multy = 1;
    
    
    public Ghost(Vector2 position, Renderer renderer, Animator animator, Hero hero, Map map)
        : base(position, renderer, animator)
    {
        _hero = hero;
        _map = map;
        
        // грубо
        _patrolPoints.Add(new Vector2(0, 0));
        _patrolPoints.Add(new Vector2(_map.Width - 32, 0 ));
        _patrolPoints.Add(new Vector2(_map.Width - 32, _map.Height - 16));
        _patrolPoints.Add(new Vector2(0, _map.Height - 16));
        
    }

    public void Update(double deltaTime)
    {
        Patrol(deltaTime);
        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        /*switch (_indexPatrol)
        {
            case 0:
                Animator.ChangeAnimation(SpriteName.WalkRight);
                _multy = 2;
                break;
            case 1:
                Animator.ChangeAnimation(SpriteName.WalkRight);
                _multy = 1;
                break;
            case 2:
                Animator.ChangeAnimation(SpriteName.WalkLeft);
                _multy = 2;
                break;
            case 3:
                Animator.ChangeAnimation(SpriteName.WalkLeft);
                _multy = 1;
                break;
        }*/
    }

    private void Chase(double deltaTime)
    {
        
    }
    
    private void Patrol(double deltaTime)
    {
        _targetPosition = _patrolPoints[_indexPatrol];

        if (Position == _targetPosition)
        {
            _indexPatrol = (_indexPatrol + 1) % _patrolPoints.Count;
        }
        
        Vector2 nextPosition = GetNextPosition(Position, _targetPosition);

        _timer += deltaTime * _speed;
        
        if (_timer >= _multy) 
        {
            Position = nextPosition;
            _timer = 0;
        }
        
    }
    
    private Vector2 GetNextPosition(Vector2 from, Vector2 to)
    {
        // Це шматок коду, який робить один крок із точки from у напрямку точки to по сітці.
        
        // 1. to.X - from.X — різниця по осі X (куди треба рухатися).
        // якщо to.X більший → різниця додатна
        // якщо менший → від’ємна
        // якщо рівні → 0
        
        // 2. Math.Sign(...) перетворює цю різницю на напрямок:
        // +1, якщо число > 0
        // -1, якщо число < 0
        // 0, якщо число = 0
        
        // 3. Sign перетворює від'ємне число в -1, додатнє +1, а нуль в нуль
        // sign (в C# это Math.Sign) — це функція, яка повертає знак числа.
        
        int dx = Math.Sign(to.X - from.X);
        int dy = Math.Sign(to.Y - from.Y);
        
        return new Vector2(from.X + dx, from.Y + dy);
    }
}
