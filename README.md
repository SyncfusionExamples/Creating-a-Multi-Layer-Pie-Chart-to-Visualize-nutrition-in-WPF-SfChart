# Creating a Multi Layer Pie Chart to Visualize Nutrition using WPF SfChart
This blog will guide you through creating a multi-layered pie chart in WPF using the [Syncfusion Circular Chart control](https://www.syncfusion.com/wpf-controls/charts/2d-chart). We’ll build an interactive chart that not only visualizes vitamin and food source data but also dynamically displays detailed information using the [Syncfusion Diagram](https://www.syncfusion.com/wpf-controls/diagram) control upon selection.

## Understanding Circular Charts
A [Circular chart](https://www.syncfusion.com/wpf-controls/charts/2d-chart) is a type of data visualization that displays information in a round format, often used to represent proportions, categories, or hierarchical relationships. Common examples include pie charts, and doughnut charts. These charts are especially effective for showing how parts contribute to a whole, making them popular in dashboards, reports, and nutrition visualizations.

## Why Choose Syncfusion WPF Circular Chart for Data Visualization?
The [Syncfusion WPF Circular Chart](https://www.syncfusion.com/wpf-controls/charts/2d-chart#circular-charts) is a powerful and flexible control that offers several advantages for creating sophisticated data visualizations:
* Multi-Level Visualization: Easily create multi-layered [pie](https://www.syncfusion.com/wpf-controls/charts/wpf-pie-chart) and [doughnut](https://www.syncfusion.com/wpf-controls/charts/wpf-doughnut-chart) charts to represent complex, hierarchical, or related data.
* Rich Interactivity: Comes with built-in support for [selection](https://help.syncfusion.com/wpf/charts/interactive-features/selection), [tooltips](https://help.syncfusion.com/wpf/charts/interactive-features/tooltip), and [animations](https://help.syncfusion.com/wpf/charts/animation) that enhance the user experience.
* High Performance: Optimized for smooth rendering and interaction, even with large datasets.
* Customization: Provides extensive options for customizing every aspect of the chart, from [labels](https://help.syncfusion.com/wpf/charts/adornments/label) and [colors](https://help.syncfusion.com/wpf/charts/appearance) to [adornments](https://help.syncfusion.com/wpf/charts/adornments/datamarkers) and [legends](https://help.syncfusion.com/wpf/charts/legend).

In this blog, we’ll explore how to visualize the relationship between various vitamin groups and their corresponding food sources using a multi-layered pie chart in WPF. Additionally, we’ll enhance the user experience by integrating the Syncfusion Diagram control to dynamically display detailed nutritional information upon selection.

## Define the Model
Set up data models to represent the vitamins and their food sources structure.
The chart will be structured as follows:
* The inner pie represents major vitamin groups (A, B, C, D, E).
* The outer pie shows specific food sources for all those vitamins.
* When a user clicks on a segment (either a vitamin or a food source), the chart highlights the selected vitamin group and its corresponding foods.
* Simultaneously, a Syncfusion Diagram control on the right updates to display the selected vitamin, its food sources, and their caloric information in a clear, hierarchical tree structure.

Refer to the following image.

![Multilayered-PieChart](https://github.com/user-attachments/assets/cd480a75-3cf3-4b3b-ad8f-b28a20120eef)

## Troubleshooting:
### Path too long exception:
If you are facing a "Path too long" exception when building this example project, close Visual Studio and rename the repository to a shorter name before building the project.

For a step-by-step procedure, refer to the blog on [Creating-a-Multi-Layer-Pie-Chart-to-Visualize-nutrition-in-WPF-SfChart blog](https://www.syncfusion.com/blogs/post/multi-layer-pie-chart-wpf).
