using OpenTK.Mathematics;
using Sagittarius.Graphics;
using System.Runtime.InteropServices;

namespace Sagittarius.Core;

public class BaseEntity : IComponent, IRenderComponent{

    public delegate void MoveDelegate(ref Vector3 Position, Vector2 prePosition, Vector2 Size);
    public delegate void DelegateDelegate(BaseEntity entity);

    public event DelegateDelegate isDeleted;
    public event MoveDelegate isMoved;

    protected Vector3 position;
    protected Vector2 size;
    protected Vector2 angle;

    public Vector3 Position { get { return position; } }
    public Vector2 Size { get { return size; } }
    public Vector2 Angle { get { return angle; } }

    public int Hp { get; protected set; }
    public int MAX_HP { get; }

    public bool IsColision { get; private set; }
    public bool IsLife { get; private set; }

    public List<IRenderItem> renderItems { get; set; }

    ~BaseEntity() { isDeleted?.Invoke(this); }
    public BaseEntity() {}

    public BaseEntity(EntitySettings settings) {
        position = settings.Position;
        size = settings.Size;
        angle = settings.Angle;

        Hp = settings.Hp;
        MAX_HP = settings.MAX_HP;

        IsColision = settings.IsColision;
        IsLife = settings.IsLife;
    }


    public void Move(float VelosityX, float VelosityY, double time) =>
        Move(new Vector2(VelosityX, VelosityY), time);

    public void Move(Vector2 velocity, double time){
        Vector2 prePosition = position.Xy;
        velocity *= (float)time;
        float X = 0;
        float Y = 0;

        float X1 = 0;
        float Y1 = 0;

        X = ((float)((MathF.Cos((((angle.X) * MathF.PI) / 180)) * velocity.X)));
        X1 = ((float)((MathF.Cos((((90 + angle.X) * MathF.PI) / 180)) * velocity.Y)));

        Y = ((float)((MathF.Sin((((angle.X) * MathF.PI) / 180)) * velocity.X)));
        Y1 = ((float)((MathF.Sin((((90 - angle.X) * MathF.PI) / 180)) * velocity.Y)));

        position -= new Vector3(0, Y, 0);
        position -= new Vector3(0, Y1, 0);

        position -= new Vector3(X, 0, 0);
        position -= new Vector3(X1, 0, 0);

        isMoved?.Invoke(ref position, prePosition, size);
    }

    public bool TakeDamage(int Damage) {
        Hp -= Damage;

        if (Hp < 0) IsLife = false;

        return IsLife;
    }

    public void RotateX(float angle, double time) => this.angle += new Vector2((float)(angle * time), 0);

    public void RotateY(float angle, double time) => this.angle += new Vector2(0, (float)(angle * time));

    public virtual void Start(){ }
    public virtual void End() { }

    public virtual void Update(double args){}
}
