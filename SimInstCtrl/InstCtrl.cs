﻿using System;
using System.Threading;

namespace SimInstCtrl
{
    public class InstCtrl
    {
        public delegate void ScanCompelete();
        public delegate void ScanFailed();
        /// <summary>
        /// auto-get the data from InstCtrl 
        /// </summary>
        public delegate void DataReceived_AutoGet();

        public delegate void DataReceived_SinglePoint(double value);

        public delegate void DataReceived_DoublePoint(double xValue,double yValue);

        public delegate void DataReceived_DoublePoint_Arrays(double[] xValues, double[] yValues);


        public ScanCompelete ScanCompelete_CallBack { get; set; }

        public ScanFailed ScanFailed_CallBack { get; set; }

        public DataReceived_AutoGet AutoGet_CallBack { get; set; }

        public DataReceived_SinglePoint SinglePoint_CallBack { get; set; }

        public DataReceived_DoublePoint DoublePoint_CallBack { get; set; }

        public DataReceived_DoublePoint_Arrays DoublePoint_Arrays_CallBack { get; set; }


        public void PerformScan_SinglePoint()
        {
            Thread thread = new Thread(() =>
              {
                  Thread.Sleep(1000);
                  for(int i=0;i<200;i++)
                  {
                      Thread.Sleep(50);
                      Random random = new Random((int)DateTime.Now.Ticks);
                      int start = Math.Abs(i - 100);
                      SinglePoint_CallBack?.Invoke(random.Next(start, 100 + start));
                  }

                  ScanCompelete_CallBack?.Invoke();

              })
            { IsBackground = true};
            thread.Start();
        }
    }
}
