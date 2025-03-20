Shader "Custom/DepthMask"
{
    SubShader
    {
        Tags { "Queue" = "Geometry-1" "RenderType" = "Transparent" }
        Pass
        {
            Name "DepthMask"
            ZWrite On
            ColorMask 0
        }
    }
}
