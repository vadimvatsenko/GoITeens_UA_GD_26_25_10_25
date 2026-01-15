using SharpHook;
using SharpHook.Data;

namespace RPG_Monochrome.Engine;


public class NewInputSystem : IUpdatable
{
    private EventLoopGlobalHook hook;
    public NewInputSystem()
    {
        hook = new EventLoopGlobalHook();
    }
    
    public void Update(double deltaTime)
    {
        hook.KeyPressed += (s, e) =>
        {
            Console.WriteLine($"DOWN: {e.Data.KeyCode}");

            // Выход по Esc
            if (e.Data.KeyCode == KeyCode.VcEscape)
                hook.Stop();
        };
        
        hook.Run();
    }
}