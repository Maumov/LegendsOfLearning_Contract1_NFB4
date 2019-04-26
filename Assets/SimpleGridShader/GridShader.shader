﻿// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "PDT Shaders/TestGrid" {
	Properties {
		_LineColor ("Line Color", Color) = (1,1,1,1)
		_CellColor ("Cell Color", Color) = (0,0,0,0)
		_SelectedColor ("Selected Color", Color) = (1,0,0,1)
		[PerRendererData] _MainTex ("Albedo (RGB)", 2D) = "white" {}
		[IntRange] _GridXSize("Horizontal Size", Range(1,8)) = 2
		[IntRange] _GridYSize("Vertical Size", Range(1,8)) = 2
		_LineXSize("LineX Size", Range(0,1)) = 0.15
		_LineYSize("LineY Size", Range(0,1)) = 0.15
		[IntRange] _SelectCell("Select Cell Toggle ( 0 = False , 1 = True )", Range(0,1)) = 0.0
		[IntRange] _SelectedCellX("Selected Cell X", Range(0,8)) = 0.0
		[IntRange] _SelectedCellY("Selected Cell Y", Range(0,8)) = 0.0

		_StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _ColorMask ("Color Mask", Float) = 15
	}
	SubShader {
		Tags { "Queue"="AlphaTest" "RenderType"="TransparentCutout" }
		LOD 200
	
	    Stencil
        {
             Ref [_Stencil]
             Comp [_StencilComp]
             Pass [_StencilOp] 
             ReadMask [_StencilReadMask]
             WriteMask [_StencilWriteMask]
        }
        ColorMask [_ColorMask]

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness = 0.0;
		half _Metallic = 0.0;
		float4 _LineColor;
		float4 _CellColor;
		float4 _SelectedColor;

		float _GridXSize;
		float _GridYSize;
		
		float _LineXSize;
		float _LineYSize;

		float _SelectCell;
		float _SelectedCellX;
		float _SelectedCellY;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color

			float2 uv = IN.uv_MainTex;

			_SelectedCellX = floor(_SelectedCellX);
			_SelectedCellY = floor(_SelectedCellY);

			fixed4 c = float4(0.0,0.0,0.0,0.0);

			float brightness = 1.;

			float gxsize = floor(_GridXSize);
			float gysize = floor(_GridYSize);

			gxsize += _LineXSize;
			gysize += _LineYSize;

			float2 id;

			id.x = floor(uv.x/(1.0/gxsize));
			id.y = floor(uv.y/(1.0/gysize));

			float4 color = _CellColor;
			brightness = _CellColor.w;

			//This checks that the cell is currently	selected if the Select Cell slider is set to 1 ( True )
			if (round(_SelectCell) == 1.0 && id.x == _SelectedCellX && id.y == _SelectedCellY)
			{
				brightness = _SelectedColor.w;
				color = _SelectedColor;
			}

			if (frac(uv.x*gxsize) <= _LineXSize || frac(uv.y*gysize) <= _LineYSize)
			{
				brightness = _LineColor.w;
				color = _LineColor;
			}
			

			//Clip transparent spots using alpha cutout
			if (brightness == 0.0) {
				clip(c.a - 1.0);
			}
			

			o.Albedo = float4( color.x*brightness,color.y*brightness,color.z*brightness,brightness);
			// Metallic and smoothness come from slider variables
			o.Metallic = 0.0;
			o.Smoothness = 0.0;
			o.Alpha = 0.0;
		}
		ENDCG
	}
	FallBack "Diffuse"
}