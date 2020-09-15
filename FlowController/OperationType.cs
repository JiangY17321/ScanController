namespace FlowController
{
    public enum OperationType
    {
        None=0,

        /// <summary>
        /// All operations should belong to one experiment
        /// </summary>
        Experiment=1,
        
        /// <summary>
        /// Params which will not change during the scanning
        /// </summary>
        GeneralParam = 2,
        
        /// <summary>
        /// A data node which can group the spectrums by sample name 
        /// </summary>
        Data =3,
        
        /// <summary>
        /// All Sub operations are about background scanning
        /// </summary>
        BackgroundData = 4,
        
        /// <summary>
        /// Indicates that this operation create a sample
        /// </summary>
        Sample=5,
        
        /// <summary>
        /// Issue the scan command to instrument
        /// </summary>
        Scan=6,

        /// <summary>
        /// Waiting for trigger
        /// </summary>
        Trigger=7,

        #region SpecificParam
        /// <summary>
        /// Param setting for temperature
        /// </summary>
        Temperature=50,

        /// <summary>
        /// Param setting for time, usually used for time-drive mode
        /// </summary>
        Time = 51,

        /// <summary>
        /// Param setting for each cell's position in microplatereader
        /// </summary>
        MicroplateReader_Position = 52,

        /// <summary>
        /// Param setting for wavelength
        /// </summary>
        WaveLength = 53,

        /// <summary>
        /// PeltierScan
        /// </summary>
        TemperatureScan = 54,
        #endregion

        /// <summary>
        /// Experiment has finished
        /// </summary>
        End =100,
    }
}
