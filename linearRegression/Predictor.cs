using System;
using System.Collections.Generic;
using System.Text;

namespace linearRegression
{
    class Predictor
    {      
        public float PredictY(float X, Trendline trendline)
        {
            return (trendline.M * X) + trendline.B;
        }

        public float PredictX(float Y, Trendline trendline)
        {
            return (Y - trendline.B) / trendline.M;
        }
    }
}
