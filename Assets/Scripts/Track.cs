using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Bezier;

namespace Rollercoaster {
    [ExecuteInEditMode]
    public class Track : MonoBehaviour {
        [Header("Generation parameters")]
        [SerializeField]
        [Range(0,100)]
        private int _stepsPerCurve = 10;
        [SerializeField]
        private float _segmentLength = 1f;
        [Space]
        [SerializeField]
        private TrackPoint[] _points;
        
        //For debug purposes only
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

        private void Make() {
            //1st step: regular bezier
            float step = 1f/_stepsPerCurve;
            var bezierPoints = new Vector3[_stepsPerCurve * _points.Length];
            for(int j = 0; j < _points.Length; j++) {
                for(int i = 0; i <= _stepsPerCurve; i++) {
                    bezierPoints[i + j * _stepsPerCurve] = BezierCurve.Lerp(i * step, _points[j].points.Select(t => t.position).ToArray());
                }
            }
            //2nd step: make points in constant distance
            var regularPoints = new List<Vector3>();
            //TODO
            throw new NotImplementedException();
        }

        [Serializable]
        private struct TrackPoint {
            public Transform[] points;
        }

        [Serializable]
        public struct TrackVert {
            public Vector3 position;
            public Vector3 normal;
        }
    }
}
