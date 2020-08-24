using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowController
{
    public class WaveLengthOperation : Operation
    {
        public string WaveLengthName { get; set; }
        public WaveLengthOperation() : base(OperationType.WaveLength)
        {

        }
    }
}
