using System.Collections.ObjectModel;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;

namespace LayeredPieChart_WPF
{
    public class VitaminFoodViewModel : ModelBase
    {
        public ObservableCollection<Vitamin> Vitamins { get; set; }
        public ObservableCollection<FoodSource> FoodSources { get; set; }


        public VitaminFoodViewModel()
        {
            Vitamins = new ObservableCollection<Vitamin>
            {
                new Vitamin { Name = "Vitamin A", Value = 15, Color = new SolidColorBrush(Color.FromRgb(147, 33, 98)) },
                new Vitamin { Name = "Vitamin B", Value = 25, Color = new SolidColorBrush(Color.FromRgb(14, 66, 108)) },
                new Vitamin { Name = "Vitamin C", Value = 15, Color = new SolidColorBrush(Color.FromRgb(161, 79, 11)) },
                new Vitamin { Name = "Vitamin D", Value = 20, Color = new SolidColorBrush(Color.FromRgb(86, 45, 98)) },
                new Vitamin { Name = "Vitamin E", Value = 25, Color = new SolidColorBrush(Color.FromRgb(12, 99, 99)) }
            };

            FoodSources = new ObservableCollection<FoodSource>
            {
                new FoodSource { Source = "Carrot", Value = 5, VitaminGroup = "A", Color = new SolidColorBrush(Color.FromRgb(167, 34, 111)) },
                new FoodSource { Source = "Sweet Potato", Value = 10, VitaminGroup = "A", Color = new SolidColorBrush(Color.FromRgb(167, 34, 111)) },

                new FoodSource { Source = "Eggs", Value = 5, VitaminGroup = "B", Color = new SolidColorBrush(Color.FromRgb(9, 78, 131)) },
                new FoodSource { Source = "Whole Grains", Value = 10, VitaminGroup = "B", Color = new SolidColorBrush(Color.FromRgb(9, 78, 131)) },
                new FoodSource { Source = "Meat", Value = 10, VitaminGroup = "B", Color = new SolidColorBrush(Color.FromRgb(9, 78, 131)) },

                new FoodSource { Source = "Oranges", Value = 9, VitaminGroup = "C", Color = new SolidColorBrush(Color.FromRgb(185, 95, 4)) },
                new FoodSource { Source = "Bell Peppers", Value = 6, VitaminGroup = "C", Color = new SolidColorBrush(Color.FromRgb(185, 95, 4)) },

                new FoodSource { Source = "Mushrooms", Value = 9, VitaminGroup = "D", Color = new SolidColorBrush(Color.FromRgb(102, 49, 119)) },
                new FoodSource { Source = "Milk", Value = 11, VitaminGroup = "D", Color = new SolidColorBrush(Color.FromRgb(102, 49, 119)) },

                new FoodSource { Source = "Almonds", Value = 8, VitaminGroup = "E", Color = new SolidColorBrush(Color.FromRgb(8, 125, 124)) },
                new FoodSource { Source = "Spinach", Value = 5, VitaminGroup = "E", Color = new SolidColorBrush(Color.FromRgb(8, 125, 124)) },
                new FoodSource { Source = "Sunflower Seeds", Value = 12, VitaminGroup = "E", Color = new SolidColorBrush(Color.FromRgb(8, 125, 124)) }
            };

        }
    }

    public class MultiParent : DiagramViewModel
    {
        public MultiParent()
        {
            //Initialize Diagram Properties
            Connectors = new ObservableCollection<ConnectorVM>();
            Constraints = Constraints.Remove(GraphConstraints.PageEditing, GraphConstraints.PanRails);
            Menu = null;
            Tool = Tool.ZoomPan;

            // Initialize DataSourceSettings for SfDiagram
            DataSourceSettings = new DataSourceSettings()
            {
                ParentId = "ReportingPerson",
                Id = "NodeId",
                DataSource = GetVitaminData("A"),
            };

            // Initialize LayoutSettings for SfDiagram
            LayoutManager = new LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    Type = LayoutType.Hierarchical,
                    Orientation = TreeOrientation.LeftToRight,
                    AvoidSegmentOverlapping = false,

                    HorizontalSpacing = 40,
                    VerticalSpacing = 100,
                },
            };
        }

        private readonly Dictionary<string, VitaminData> _vitaminDataSource = new Dictionary<string, VitaminData>(){
        {   "A", new VitaminData {
            Name = "Vitamin A", Color1 = "#7b2054", Color2 = "#932162", Color3 = "#b22477",
            FoodSources = new List<FoodSourceInfo>
            {
                new FoodSourceInfo { Name = "Carrot", Calories = "100g, ~41 calories" },
                new FoodSourceInfo { Name = "Sweet Potato", Calories = "100g, ~86 calories" },
                new FoodSourceInfo { Name = "Spinach", Calories = "100g, ~23 calories" },
                new FoodSourceInfo { Name = "Kale", Calories = "100g, ~49 calories" },
                new FoodSourceInfo { Name = "Butternut Squash", Calories = "100g, ~45 calories" },
                new FoodSourceInfo { Name = "Red Pepper", Calories = "100g, ~31 calories" },
                new FoodSourceInfo { Name = "Mango", Calories = "100g, ~60 calories" }
            }
        }},
        { "B", new VitaminData {
            Name = "Vitamin B", Color1 = "#0a4e82", Color2 = "#065c9e", Color3 = "#0674c3",
            FoodSources = new List<FoodSourceInfo> {
                new FoodSourceInfo { Name = "Eggs", Calories = "100g, ~155 calories" },
                new FoodSourceInfo { Name = "Whole Grains", Calories = "100g, ~340 calories" },
                new FoodSourceInfo { Name = "Meat", Calories = "100g, ~239 calories" },
                new FoodSourceInfo { Name = "Fish", Calories = "100g, ~206 calories" },
                new FoodSourceInfo { Name = "Milk", Calories = "100ml, ~42 calories" },
                new FoodSourceInfo { Name = "Legumes", Calories = "100g, ~110 calories" },
                new FoodSourceInfo { Name = "Bananas", Calories = "100g, ~89 calories" }
            }
        }},
        { "C", new VitaminData {
            Name = "Vitamin C", Color1 = "#a14f0b", Color2 = "#b95f04", Color3 = "#df8800",
            FoodSources = new List<FoodSourceInfo> {
                new FoodSourceInfo { Name = "Oranges", Calories = "100g, ~47 calories" },
                new FoodSourceInfo { Name = "Bell Peppers", Calories = "100g, ~31 calories" },
                new FoodSourceInfo { Name = "Kiwi", Calories = "100g, ~61 calories" },
                new FoodSourceInfo { Name = "Strawberries", Calories = "100g, ~32 calories" },
                new FoodSourceInfo { Name = "Broccoli", Calories = "100g, ~55 calories" },
                new FoodSourceInfo { Name = "Pineapple", Calories = "100g, ~50 calories" },
                new FoodSourceInfo { Name = "Papaya", Calories = "100g, ~43 calories" }
            }
        }},
        { "D", new VitaminData {
            Name = "Vitamin D", Color1 = "#653276", Color2 = "#7a3b90", Color3 = "#934aaf",
            FoodSources = new List<FoodSourceInfo> {
                new FoodSourceInfo { Name = "Mushrooms", Calories = "100g, ~22 calories" },
                new FoodSourceInfo { Name = "Milk", Calories = "100ml, ~42 calories" },
                new FoodSourceInfo { Name = "Salmon", Calories = "100g, ~208 calories" },
                new FoodSourceInfo { Name = "Tuna", Calories = "100g, ~184 calories" },
                new FoodSourceInfo { Name = "Egg Yolk", Calories = "50g, ~55 calories" },
                new FoodSourceInfo { Name = "Sardines", Calories = "100g, ~208 calories" },
                new FoodSourceInfo { Name = "Fortified Cereals", Calories = "30g, ~110 calories" }
            }
        }},
        { "E", new VitaminData {
            Name = "Vitamin E", Color1 = "#0c6363", Color2 = "#087d7c", Color3 = "#049d99",
            FoodSources = new List<FoodSourceInfo> {
                new FoodSourceInfo { Name = "Almonds", Calories = "100g, ~579 calories" },
                new FoodSourceInfo { Name = "Spinach", Calories = "100g, ~23 calories" },
                new FoodSourceInfo { Name = "Sunflower Seeds", Calories = "100g, ~584 calories" },
                new FoodSourceInfo { Name = "Avocado", Calories = "100g, ~160 calories" },
                new FoodSourceInfo { Name = "Olive Oil", Calories = "100ml, ~884 calories" },
                new FoodSourceInfo { Name = "Hazelnuts", Calories = "100g, ~628 calories" },
                new FoodSourceInfo { Name = "Peanut Butter", Calories = "100g, ~588 calories" }
            }
        }}
};

        public ObservableCollection<ItemInfo> GetVitaminData(string vitaminGroup)
        {
            var groupKey = vitaminGroup.ToUpper();
            if (!_vitaminDataSource.ContainsKey(groupKey))
            {
                return new ObservableCollection<ItemInfo>(); // Return empty collection if key not found
            }

            var vitaminInfo = _vitaminDataSource[groupKey];
            var data = new ObservableCollection<ItemInfo>();

            // Add the top-level vitamin node
            string parentNodeId = "n11";
            if (vitaminInfo.Color1 != null && vitaminInfo.Name != null)
            {
                data.Add(new ItemInfo(parentNodeId, vitaminInfo.Color1, vitaminInfo.Name));
            }

            // Loop through the food sources to create child and grandchild nodes
            if (vitaminInfo.FoodSources != null)
            {
                for (int i = 0; i < vitaminInfo.FoodSources.Count; i++)
                {
                    var foodSource = vitaminInfo.FoodSources[i];
                    string foodNodeId = $"n2{i + 1}";
                    string calorieNodeId = $"n3{i + 1}";

                    // Add food source node (Level 2)
                    if (vitaminInfo.Color2 != null && foodSource.Name != null)
                    {
                        data.Add(new ItemInfo(foodNodeId, vitaminInfo.Color2, foodSource.Name)
                        {
                            ReportingPerson = new List<string> { parentNodeId }
                        });
                    }

                    // Add calorie info node (Level 3)
                    if (vitaminInfo.Color3 != null && foodSource.Calories != null)
                    {
                        data.Add(new ItemInfo(calorieNodeId, vitaminInfo.Color3, foodSource.Calories)
                        {
                            ReportingPerson = new List<string> { foodNodeId }
                        });
                    }
                }
            }

            return data;
        }
    }

    public class ConnectorVM : ConnectorViewModel
    {
        public ConnectorVM()
            : base()
        {
            this.CornerRadius = 10;
        }
    }
}