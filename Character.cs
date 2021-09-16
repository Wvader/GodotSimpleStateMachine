
using Godot;

public class Character : KinematicBody2D
{


    [Export] public float Speed = 100;
    
    [Export] public float MaxSlopeAngle = 90;

    private PlayerInput _input;
    
    private StateMachine<CharacterStates.Movement> _playerState;
    
    protected Vector2 _motion = Vector2.Zero;

    private Vector2 _linearVelocity = Vector2.Zero;
    
    public override void _Ready()
    {
        _playerState = new StateMachine<CharacterStates.Movement>(this);
        _input = this.GetNodeInParent<PlayerInput>();
    }

    protected virtual void AddInput()
    {
        _motion = _input.Player1Movement;
        _motion = _motion * Speed;
    }
    
    
    protected virtual void EveryFrame()
    {
        
        GDebug.Print("Movement: " + _playerState.CurrentState);

        HandleMovement();
        
        AddInput();
    }
    
    private void MoveController()
    {
        _linearVelocity = MoveAndSlide(_motion, Vector2.Zero,  true, 4, Mathf.Deg2Rad(MaxSlopeAngle));
    }

    protected virtual void HandleMovement()
    {
        if (_linearVelocity.Length() <= 0)
        {
            _playerState.ChangeState(CharacterStates.Movement.Idle);
        }
        else
        {
            _playerState.ChangeState(CharacterStates.Movement.Walking);

        }
    }

    public override void _Process(float delta)
    {
       EveryFrame();
    }

    public override void _PhysicsProcess(float delta)
    {
        MoveController();
    }
}
