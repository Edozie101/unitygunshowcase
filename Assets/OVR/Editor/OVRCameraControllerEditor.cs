﻿/************************************************************************************

Filename    :   OVRCameraControllerEditor.cs
Content     :   Player controller interface. 
				This script adds editor functionality to the OVRCameraController
Created     :   March 06, 2013
Authors     :   Peter Giokaris

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/
#define CUSTOM_LAYOUT

using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(OVRCameraController))]

//-------------------------------------------------------------------------------------
// ***** OVRCameraControllerEditor
//
// OVRCameraControllerEditor adds extra functionality in the inspector for the currently
// selected OVRCameraController.
//
public class OVRCameraControllerEditor : Editor
{
	// target component
	private OVRCameraController m_Component;

	// OnEnable
	void OnEnable()
	{
		m_Component = (OVRCameraController)target;
	}

	// OnDestroy
	void OnDestroy()
	{
	}

	// OnInspectorGUI
	public override void OnInspectorGUI()
	{
		GUI.color = Color.white;
		
		Undo.RecordObject(m_Component, "OVRCameraController");

		{
#if CUSTOM_LAYOUT
			OVREditorGUIUtility.Separator();			
			
			m_Component.VerticalFOV         = EditorGUILayout.FloatField("Vertical FOV", m_Component.VerticalFOV);
			m_Component.IPD         		= EditorGUILayout.FloatField("IPD", m_Component.IPD);
			m_Component.ScaleRenderTarget   = EditorGUILayout.FloatField("Scale Render", m_Component.ScaleRenderTarget);

			OVREditorGUIUtility.Separator();
			
			m_Component.CameraRootPosition  = EditorGUILayout.Vector3Field("Camera Root Position", m_Component.CameraRootPosition);
			m_Component.NeckPosition 		= EditorGUILayout.Vector3Field("Neck Position", m_Component.NeckPosition);

			OVREditorGUIUtility.Separator();

			m_Component.UsePlayerEyeHeight  = EditorGUILayout.Toggle ("Use Player Eye Height", m_Component.UsePlayerEyeHeight);
			
			OVREditorGUIUtility.Separator();
			
			m_Component.FollowOrientation = EditorGUILayout.ObjectField("Follow Orientation", 
																		m_Component.FollowOrientation,
																		typeof(Transform), true) as Transform;
			m_Component.TrackerRotatesY 	= EditorGUILayout.Toggle("Tracker Rotates Y", m_Component.TrackerRotatesY);
			
			OVREditorGUIUtility.Separator();	

			// Remove Portrait Mode from Inspector window for now
			//m_Component.PortraitMode        = EditorGUILayout.Toggle ("Portrait Mode", m_Component.PortraitMode);
#if (!UNITY_ANDROID || UNITY_EDITOR)
			m_Component.EnableOrientation   = EditorGUILayout.Toggle ("Enable Orientation", m_Component.EnableOrientation);
			m_Component.EnablePosition      = EditorGUILayout.Toggle ("Enable Position", m_Component.EnablePosition);
			m_Component.PredictionOn        = EditorGUILayout.Toggle ("Prediction On", m_Component.PredictionOn);
			m_Component.CallInPreRender     = EditorGUILayout.Toggle ("Call in Pre-Render", m_Component.CallInPreRender);
			m_Component.WireMode     		= EditorGUILayout.Toggle ("Wire-Frame Mode", m_Component.WireMode);

			OVREditorGUIUtility.Separator();

			m_Component.UseCameraTexture    = EditorGUILayout.Toggle ("Use Camera Texture", m_Component.UseCameraTexture);
			m_Component.CameraTextureScale  = EditorGUILayout.FloatField("Camera Texture Scale", m_Component.CameraTextureScale);
			m_Component.LensCorrection     	= EditorGUILayout.Toggle ("Lens Correction", m_Component.LensCorrection);
			m_Component.Chromatic     		= EditorGUILayout.Toggle ("Chromatic", m_Component.Chromatic);
			m_Component.TimeWarp     		= EditorGUILayout.Toggle ("Time Warp", m_Component.TimeWarp);
			m_Component.FreezeTimeWarp     	= EditorGUILayout.Toggle ("Freeze Time Warp", m_Component.FreezeTimeWarp);
			m_Component.FlipCorrectionInY   = EditorGUILayout.Toggle ("FlipY", m_Component.FlipCorrectionInY);

			OVREditorGUIUtility.Separator();
#endif

			m_Component.BackgroundColor 	= EditorGUILayout.ColorField("Background Color", m_Component.BackgroundColor);
			m_Component.NearClipPlane       = EditorGUILayout.FloatField("Near Clip Plane", m_Component.NearClipPlane);
			m_Component.FarClipPlane        = EditorGUILayout.FloatField("Far Clip Plane", m_Component.FarClipPlane);			
			
			OVREditorGUIUtility.Separator();
#else			 
			DrawDefaultInspector ();
#endif
		}

		if (GUI.changed)
		{
			EditorUtility.SetDirty(m_Component);
		}
	}		
}

