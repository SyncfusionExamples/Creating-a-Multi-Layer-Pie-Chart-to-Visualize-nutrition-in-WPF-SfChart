using Syncfusion.UI.Xaml.Charts;
using System.Windows;
using System.Windows.Media;

namespace LayeredPieChart_WPF
{
    public partial class MainWindow : Window
    {
        private class VitaminColorInfo
        {
            public string Group;
            public Color Color;
        }

        private class VitaminGroupColorInfo
        {
            public string Group;
            public Color BaseColor;
            public int Count;
        }

        private static VitaminColorInfo[] InnerPieColors =
        {
            new VitaminColorInfo { Group = "A", Color = Color.FromRgb(147, 33, 98) },
            new VitaminColorInfo { Group = "B", Color = Color.FromRgb(14, 66, 108) },
            new VitaminColorInfo { Group = "C", Color = Color.FromRgb(161, 79, 11) },
            new VitaminColorInfo { Group = "D", Color = Color.FromRgb(86, 45, 98) },
            new VitaminColorInfo { Group = "E", Color = Color.FromRgb(12, 99, 99) }
        };

        private static VitaminGroupColorInfo[] OuterPieColors =
        {
            new VitaminGroupColorInfo { Group = "A", BaseColor = Color.FromRgb(167, 34, 111), Count = 2 },
            new VitaminGroupColorInfo { Group = "B", BaseColor = Color.FromRgb(9, 78, 131), Count = 3 },
            new VitaminGroupColorInfo { Group = "C", BaseColor = Color.FromRgb(185, 95, 4), Count = 2 },
            new VitaminGroupColorInfo { Group = "D", BaseColor = Color.FromRgb(102, 49, 119), Count = 2 },
            new VitaminGroupColorInfo { Group = "E", BaseColor = Color.FromRgb(8, 125, 124), Count = 3 }
        };

        MultiParent parent;
        private string lastSelectedSegment;

        public MainWindow()
        {
            InitializeComponent();
            parent = new MultiParent();
        }

        private void SfChart_SelectionChanged(object sender, ChartSelectionChangedEventArgs e)
        {
            if (e.SelectedSegment?.Item == null) return;

            string vitaminGroup = "";
            if (e.SelectedSegment.Item is FoodSource foodSource)
            {
                vitaminGroup = foodSource.VitaminGroup;
            }
            else if (e.SelectedSegment.Item is Vitamin vitamin)
            {
                vitaminGroup = vitamin.Name.Replace("Vitamin ", "");
            }

            if (string.IsNullOrEmpty(vitaminGroup) || lastSelectedSegment == vitaminGroup)
            {
                return;
            }

            lastSelectedSegment = vitaminGroup;

            pieSeries1.Palette = ChartColorPalette.Custom;
            pieSeries1.SegmentColorPath = string.Empty;
            pieSeries1.ColorModel = ApplyInnerPieSelection(vitaminGroup);

            pieSeries2.Palette = ChartColorPalette.Custom;
            pieSeries2.SegmentColorPath = string.Empty;
            pieSeries2.ColorModel = ApplyOuterPieSelection(vitaminGroup);

            UpdateDiagram(vitaminGroup);
        }

        private ChartColorModel ApplyOuterPieSelection(string vitaminGroup)
        {
            var colorModel = new ChartColorModel();
            string selectedUpper = vitaminGroup.ToUpper();

            foreach (var data in OuterPieColors)
            {
                Color finalColor = (data.Group == selectedUpper)
                    ? data.BaseColor
                    : Color.FromArgb(80, data.BaseColor.R, data.BaseColor.G, data.BaseColor.B);

                var brush = new SolidColorBrush(finalColor);
                for (int i = 0; i < data.Count; i++)
                {
                    colorModel.CustomBrushes.Add(brush);
                }
            }
            return colorModel;
        }

        private ChartColorModel ApplyInnerPieSelection(string vitaminGroup)
        {
            var colorModel = new ChartColorModel();
            string selectedGroup = vitaminGroup.ToUpper();

            foreach (var vitamin in InnerPieColors)
            {
                Color finalColor = (vitamin.Group == selectedGroup)
                    ? vitamin.Color
                    : Color.FromArgb(80, vitamin.Color.R, vitamin.Color.G, vitamin.Color.B);

                colorModel.CustomBrushes.Add(new SolidColorBrush(finalColor));
            }
            return colorModel;
        }

        private void UpdateDiagram(string vitaminGroup)
        {
            if (diagram.DataSourceSettings != null)
            {
                this.diagram.DataSourceSettings.DataSource = parent.GetVitaminData(vitaminGroup);
            }
        }
    }
}