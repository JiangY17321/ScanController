﻿namespace FlowController
{
    /// <summary>
    /// Set parameters for instrument, these parameters will not 
    /// change during the whole scan of an experiment
    /// </summary>
    public class GeneralParamOperation : Operation
    {
        public string GeneralParamName { get; set; }
        public GeneralParamOperation() : base(OperationType.GeneralParam)
        {

        }
    }
}
