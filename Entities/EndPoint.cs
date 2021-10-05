using System;
using Exceptions.EndPoint;

namespace App.Entities
{
    public enum States
    {
        Connected = 0,
        Disconnected = 1,
        Armed = 2
    }

    public enum ModelsId
    {
        NSX1P2W = 16,
        NSX1P3W = 17,
        NSX2P3W = 18,
        NSX3P4W = 19,
    }
    public class EndPoint
    {
        
        public string SerialNumber { get; }
        public int Number { get; }
        public string FirmwareVersion { get; }
        private int _state;
        private int _modelId;
        public int ModelId 
        { 
            get => _modelId;
            set
            {
                switch (value)
                {
                    case (int)ModelsId.NSX1P2W:
                        _modelId = value;
                        break;
                    case (int)ModelsId.NSX1P3W:
                        _modelId = value;
                        break;
                    case (int)ModelsId.NSX2P3W:
                        _modelId = value;
                        break;
                    case (int)ModelsId.NSX3P4W:
                        _modelId = value;
                        break;
                    default:
                        throw new ModelIdNotExistsException("Model id not exists");
                }
                
            } 
        }
        public int State 
        { 
            get => _state;
            set
            {
                switch (value)
                {
                    case (int)States.Armed:
                        _state = value;
                        break;
                    case (int)States.Connected:
                        _state = value;
                        break;
                    case (int)States.Disconnected:
                        _state = value;
                        break;
                    default:
                        throw new StateNotExistsException("State not exists");
                }
                
            } 
        }

        public EndPoint(int modelId, string serialNumber, int number, string firmwareVersion, int state)
        {
            ModelId = modelId;
            SerialNumber = serialNumber;
            Number = number;
            FirmwareVersion = firmwareVersion;
            State = state;
        }
    }
}