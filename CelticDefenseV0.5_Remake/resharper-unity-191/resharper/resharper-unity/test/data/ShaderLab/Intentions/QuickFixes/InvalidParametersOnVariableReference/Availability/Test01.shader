Shader "Unlit/SingleColor"
{
    Properties
    {
        _Op ("Op value", float) = 1
    }
    SubShader
    {
        BlendOp [_Op (so{caret}mething something) ]
    }
}
