﻿using System;
using KelpNet.Common;

namespace KelpNet.Functions.Connections
{
    [Serializable]
    public class EmbedID : NeedPreviousInputFunction
    {
        public NdArray W;
        public NdArray gW;

        public EmbedID(int inputCount, int outputCount, Array initialW = null, string name = "EmbedID") : base(name,inputCount,outputCount)
        {
            this.W = NdArray.Zeros(inputCount, outputCount);
            this.gW = NdArray.ZerosLike(this.W);

            this.Parameters.Add(new OptimizeParameter(this.W, this.gW, this.Name + " W"));

            if (initialW == null)
            {
                InitWeight(this.W);
            }
            else
            {
                //単純に代入しないのはサイズのチェックを兼ねるため
                Buffer.BlockCopy(initialW, 0, this.W.Data, 0, sizeof(double) * initialW.Length);
            }
        }

        protected override NdArray NeedPreviousForward(NdArray x)
        {
            NdArray result = NdArray.Zeros(x.Length, this.OutputCount);

            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < this.OutputCount; j++)
                {
                    result.Data[i * this.OutputCount + j] = this.W.Data[(int)x.Data[i] * this.OutputCount + j];
                }
            }

            return result;
        }

        protected override NdArray NeedPreviousBackward(NdArray gy, NdArray prevInput)
        {
            for (int i = 0; i < prevInput.Length; i++)
            {
                for (int j = 0; j < this.OutputCount; j++)
                {
                    this.gW.Data[(int)prevInput.Data[i] * this.OutputCount + j] += gy.Data[i + j];
                }
            }

            return null;
        }
    }
}
