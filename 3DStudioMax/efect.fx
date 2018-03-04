struct VertexToPixel
{
    float4 Position     : POSITION;
    float2 TexCoords    : TEXCOORD0;
};

struct PixelToFrame
{
    float4 Color : COLOR0;
};

float4x4 xWorldViewProjection;
float time;

Texture xStreetTexture;
sampler StreetTextureSampler = sampler_state { texture = <xStreetTexture> ; magfilter = ANISOTROPIC; minfilter = ANISOTROPIC; mipfilter=ANISOTROPIC; AddressU = mirror; AddressV = mirror;};


VertexToPixel SimplestVertexShader( float4 inPos : POSITION, float3 Norm : NORMAL, float2 inTexCoords : TEXCOORD0)
{
    VertexToPixel Output = (VertexToPixel)0;
    
    inPos.x = inPos.x*(1-sin(time)/2);
    inPos.y = inPos.y*(1-cos(time)/2);
    inPos.z = inPos.z*(1-sin(time)/2+cos(time)/2);
    Output.Position = mul(inPos, xWorldViewProjection);
    Output.TexCoords = inTexCoords;
    
    return Output;    
}

PixelToFrame OurFirstPixelShader(VertexToPixel PSIn)
{
    PixelToFrame Output = (PixelToFrame)0;

    float3 color0 = tex2D(StreetTextureSampler, PSIn.TexCoords);
	float Aintensity=1.6;
    
    Output.Color.rgb=color0;

    return Output;
}

technique Simplest
{
    pass Pass0
    {        
        VertexShader = compile vs_1_1 SimplestVertexShader();
        PixelShader = NULL;
    }
}