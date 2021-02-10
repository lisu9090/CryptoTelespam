﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Helper
{
    internal class Range2D
    {
        public Func<double, bool> FirstBorderCondition { get; private set; }
        public Func<double, bool> SecondBorderCondition { get; private set; }

        public bool IsAndCondition { get; set; }

        private Range2D(Func<double, bool> firstBorderCondition, Func<double, bool> secondBorderCondition, bool isAndCondition)
        {
            FirstBorderCondition = firstBorderCondition;
            SecondBorderCondition = secondBorderCondition;
            IsAndCondition = isAndCondition;
        }

        public static Range2D And(Func<double, bool> firstBorderCondition, Func<double, bool> secondBorderCondition)
        {
            return new Range2D(firstBorderCondition, secondBorderCondition, true);
        }

        public static Range2D Or(Func<double, bool> firstBorderCondition, Func<double, bool> secondBorderCondition)
        {
            return new Range2D(firstBorderCondition, secondBorderCondition, false);
        }

        public bool IsInRange(double value)
        {
            return IsAndCondition ? FirstBorderCondition(value) && SecondBorderCondition(value) : FirstBorderCondition(value) || SecondBorderCondition(value);
        }
    }
}
