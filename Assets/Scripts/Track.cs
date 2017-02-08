using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Bezier;

namespace Rollercoaster {
    [ExecuteInEditMode]
    public class Track : MonoBehaviour {
        [SerializeField]
        private TrackPoint[] _points;

        private void Update() {
            DebugDraw(10);
        }

        private void DebugDraw(int stepCount) {

            float step = 1f/stepCount;

            var prev = Vector3.zero;
            bool _isPrev = false;
            foreach(var point in _points) {
                for(int i = 0; i <= stepCount; i++) {
                    var position = BezierCurve.Lerp(i * step,point.points.Select(t => t.position).ToArray());
                    if(_isPrev) {
                        Debug.DrawLine(prev, position);
                    }
                    prev = position;
                    _isPrev = true;
                }
                for(int i = 1; i < point.points.Length; i++) {
                    Debug.DrawLine(point.points[i].position, point.points[i - 1].position, Color.red);
                }
            }
        }

        [Serializable]
        private struct TrackPoint {
            public Transform[] points;
        }
    }
}
