using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bezier {
    public class BezierCurve {
        public static Vector3 Lerp(float t, params Vector3[] args) {
            if(args.Length == 0)
                throw new ArgumentException();
            if(args.Length == 1)
                return args[0];
            Vector3[] newArgs = new Vector3[args.Length-1];
            for(int i = 0; i < newArgs.Length; i++) {
                newArgs[i] = Vector3.Lerp(args[i], args[i + 1], t);
            }
            return Lerp(t, newArgs);
        }
    }
}
