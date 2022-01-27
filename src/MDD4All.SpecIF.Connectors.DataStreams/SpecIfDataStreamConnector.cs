using MDD4All.SpecIF.DataProvider.Contracts.DataStreams;
using System.Collections.Generic;

namespace MDD4All.SpecIF.Connectors.DataStreams
{
    public class SpecIfDataStreamConnector
    {
        private ISpecIfDataSubscriber _specIfDataSubscriber;
        private ISpecIfDataPublisher _specIfDataPublisher;

        public SpecIfDataStreamConnector(ISpecIfDataSubscriber specIfDataSubscriber,
                                         ISpecIfDataPublisher specIfDataPublisher)
        {
            _specIfDataSubscriber = specIfDataSubscriber;
            _specIfDataPublisher = specIfDataPublisher;

            if (_specIfDataSubscriber != null)
            {
                _specIfDataSubscriber.SpecIfDataReceived += OnSpecIfDataReceived;
            } 
        }

        private void OnSpecIfDataReceived(object eventSource, List<DataModels.Resource> specIfData)
        {
            if(_specIfDataPublisher != null)
            {
                _specIfDataPublisher.PublishData(specIfData);
            }
        }
    }
}
