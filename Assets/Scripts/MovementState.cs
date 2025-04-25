using System;
using System.Collections.Generic;

public class State
{
    private bool _active = false;
    public bool Active
    {
        get { return _active; }
        set
        {
            if (value) Enable();
            if (!value) Disable();
        }
    }

    public Action<Object> enabled = delegate { };
    public Action<Object> disabled = delegate { };

    private void Enable()
    {
        if (_active) return;
        _active = true;
        enabled.Invoke(this);
    }

    private void Disable()
    {
        if (!_active) return;
        _active = false;
        disabled.Invoke(this);
    }
}