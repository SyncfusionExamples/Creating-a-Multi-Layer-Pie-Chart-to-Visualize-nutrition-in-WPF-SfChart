using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace LayeredPieChart_WPF
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Vitamin : ModelBase
    {
        private string? _name;
        private double _value;
        private Brush? _color;

        public string? Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }

        public Brush? Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }
    }

    public class FoodSource : ModelBase
    {
        private string? _source;
        private double _value;
        private string? _vitaminGroup;
        private Brush? _color;

        public string? Source
        {
            get => _source;
            set
            {
                if (_source != value)
                {
                    _source = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? VitaminGroup
        {
            get => _vitaminGroup;
            set
            {
                if (_vitaminGroup != value)
                {
                    _vitaminGroup = value;
                    OnPropertyChanged();
                }
            }
        }

        public Brush? Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }
    }

    public class FoodSourceInfo
    {
        public string? Name { get; set; }
        public string? Calories { get; set; }
    }

    public class VitaminData
    {
        public string? Name { get; set; }
        public string? Color1 { get; set; }
        public string? Color2 { get; set; }
        public string? Color3 { get; set; }
        public List<FoodSourceInfo>? FoodSources { get; set; }
    }

    public class ItemInfo
    {
        public ItemInfo(string nodeId, string color, string nodeName)
        {
            this.NodeId = nodeId;
            this.NodeColor = color;
            this.NodeName = nodeName;
            this.ReportingPerson = new List<string>();
        }

        public string NodeColor { get; set; }
        public string NodeId { get; set; }
        public List<string> ReportingPerson { get; set; }
        public string NodeName { get; set; }
    }
}