namespace SuperMarioBros.Animation;

public class AnimationClip
{
    private string _name;
    private string[][] _sprite;
    private bool _loop;
    private bool _allowNextClip;
    private Action _onComplete;

    public AnimationClip(string name, string[][] sprite, bool loop, bool allowNextClip)
    {
        _name = name;
        _sprite = sprite;
        _loop = loop;
        _allowNextClip = allowNextClip;
    }

    public string Name => _name;
    public string[][] Sprite => _sprite;
    public bool Loop => _loop;
    public bool AllowNextClip => _allowNextClip;
    public Action OnComplete => _onComplete;
}