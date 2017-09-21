﻿using System;
using System.Collections.Generic;

namespace KelpNet.Common.Functions
{
    //前回の入出力を自動的に扱うクラステンプレート
    [Serializable]
    public abstract class NeedPreviousInputFunction : Function
    {
        //後入れ先出しリスト
        private readonly List<BatchArray> _prevInput = new List<BatchArray>();

        protected Func<BatchArray, BatchArray> NeedPreviousForward;
        protected Func<BatchArray, BatchArray, BatchArray> NeedPreviousBackward;

        protected NeedPreviousInputFunction(string name, int inputCount = 0, int oututCount = 0) : base(name, inputCount, oututCount)
        {
            Forward = ForwardCpu;
            Backward = BackwardCpu;
        }

        public BatchArray ForwardCpu(BatchArray x)
        {
            this._prevInput.Add(x);

            return this.NeedPreviousForward(x);
        }

        public BatchArray BackwardCpu(BatchArray gy)
        {
            BackwardCountUp();

            BatchArray prevInput = this._prevInput[this._prevInput.Count - 1];
            this._prevInput.RemoveAt(this._prevInput.Count - 1);

            return this.NeedPreviousBackward(gy, prevInput);
        }

        public override BatchArray Predict(BatchArray x)
        {
            return this.NeedPreviousForward(x);
        }
    }
}
