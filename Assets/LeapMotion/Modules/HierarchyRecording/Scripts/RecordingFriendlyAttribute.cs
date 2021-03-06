﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity.GraphicalRenderer;

namespace Leap.Unity.Recording {

  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
  public class RecordingFriendlyAttribute : Attribute {

    public static bool IsRecordingFriendly(object obj) {
      Type type = obj.GetType();

      foreach (var hardcodedType in hardcodedFriendlyTypes) {
        if (type == hardcodedType || type.IsSubclassOf(hardcodedType)) {
          return true;
        }
      }

      return type.GetCustomAttributes(typeof(RecordingFriendlyAttribute), inherit: true).Length > 0;
    }

    public static IEnumerable<Type> hardcodedFriendlyTypes {
      get {
        yield return typeof(LeapGraphicRenderer);
        yield return typeof(LeapGraphic);
        yield return typeof(LeapProvider);

        yield return typeof(Transform);
        yield return typeof(TextMesh);
        yield return typeof(MeshFilter);
        yield return typeof(Renderer);
        yield return typeof(Light);

        yield return typeof(Canvas);
        yield return typeof(CanvasScaler);
        yield return typeof(Graphic);
      }
    }
  }
}
