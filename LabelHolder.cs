﻿using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace LabelsOnFloor
{
    public class PlacementData
    {
        public IntVec3 Position;
        public Vector3 Scale;
        public bool Flipped = false;
    }

    public class Label
    {
        public Mesh LabelMesh;
        public PlacementData LabelPlacementData;
        public object AssociatedArea;

        public bool IsValid()
        {
            return LabelPlacementData != null && LabelMesh != null && AssociatedArea != null;
        }
    }

    public class LabelHolder
    {
        private readonly List<Label> _currentLabels = new List<Label>();

        public void Clear()
        {
            _currentLabels.Clear();
        }

        public void Add(Label label)
        {
            _currentLabels.Add(label);
        }

        public void RemoveLabelForArea(object area)
        {
            _currentLabels.RemoveAll(l => l.AssociatedArea == area);
        }

        public IEnumerable<Label> GetLabels()
        {
            return _currentLabels;
        }
    }
}