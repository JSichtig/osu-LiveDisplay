#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;
Texture2D MaskTexture;

sampler2D SpriteTextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};

sampler2D MaskTextureSampler = sampler_state
{
	Texture = <MaskTexture>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainProcessingShader(VertexShaderOutput input) : COLOR
{
	float4 res = tex2D(SpriteTextureSampler,input.TextureCoordinates) * input.Color;
	float4 mask = tex2D(MaskTextureSampler, input.TextureCoordinates);
	if(mask.r == 0 && mask.g == 0 && mask.b == 0){
		res.r = 0;
		res.g = 0;
		res.b = 0;
		res.a = 0;
	}
	else
	{
		res.r = 0 + res.r / 2;
		res.g = 0 + res.g / 2;
		res.b = 0 + res.b / 2;
	}
	return res;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainProcessingShader();
	}
};