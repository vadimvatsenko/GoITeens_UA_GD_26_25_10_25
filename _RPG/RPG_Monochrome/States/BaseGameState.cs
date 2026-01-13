using RPG_Monochrome.Engine;

namespace RPG_Monochrome.States;

// Базовий клас перемикання станів
public abstract class BaseGameState
{
    public abstract bool IsDone();
    public abstract void Update(float deltaTime);
    public abstract void Reset();
    public abstract void Draw(Renderer renderer);
}