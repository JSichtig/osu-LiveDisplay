#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;

sampler2D SpriteTextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
	float2 vPos : VPOS;
};

float4 MainPS(VertexShaderOutput input) : COLOR
{
	float4 c = tex2D(SpriteTextureSampler,input.TextureCoordinates) * input.Color;
	if(input.vPos.x > 900 || input.vPos.x < 40)
	{
		c.r = 0;
		c.g = 0;
		c.b = 0;
		c.a = 0;
	}
	return c;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};