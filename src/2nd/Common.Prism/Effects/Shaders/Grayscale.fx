sampler2D implicitInput : register(s0);

float4 MainPS(float2 uv : TEXCOORD) : COLOR
{
	float4 src = tex2D(implicitInput, uv);
	float gray = color.r * 0.3 + color.g * 0.59 + color.b *0.11;

	float4 result;
	result.r = (color.r - gray) * factor + gray;
	result.g = (color.g - gray) * factor + gray;
	result.b = (color.b - gray) * factor + gray;
	result.a = color.a;
	return result;
	/*
	float4 dst;
	float average = (src.r + src.g + src.b)/3;
	dst.rgb = average;
	dst.a = src.a;
	return dst;
	*/
}