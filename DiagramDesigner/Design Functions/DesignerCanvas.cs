using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;
using System.Threading.Tasks;

namespace RobotRecipeManager
{
    public partial class DesignerCanvas : Canvas
    {
        private Point? rubberbandSelectionStartPoint = null;

        private SelectionService selectionService;
        internal SelectionService SelectionService
        {
            get
            {
                if (selectionService == null)
                    selectionService = new SelectionService(this);

                return selectionService;
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Source == this)
            {
                // in case that this click is the start of a 
                // drag operation we cache the start point
                this.rubberbandSelectionStartPoint = new Point?(e.GetPosition(this));

                // if you click directly on the canvas all 
                // selected items are 'de-selected'
                SelectionService.ClearSelection();
                Focus();
                e.Handled = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // if mouse button is not pressed we have no drag operation, ...
            if (e.LeftButton != MouseButtonState.Pressed)
                this.rubberbandSelectionStartPoint = null;

            // ... but if mouse button is pressed and start
            // point value is set we do have one
            if (this.rubberbandSelectionStartPoint.HasValue)
            {
                // create rubberband adorner
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
                if (adornerLayer != null)
                {
                    RubberbandAdorner adorner = new RubberbandAdorner(this, rubberbandSelectionStartPoint);
                    if (adorner != null)
                    {
                        adornerLayer.Add(adorner);
                    }
                }
            }
            e.Handled = true;
        }

        protected override void OnDrop(DragEventArgs e)
        {
            Custom_Functions.Validation_OnDrop validation = new Custom_Functions.Validation_OnDrop();

            bool check = validation.Validation_Check(e);

            if (check == false)
            {
                return;
            }
            else
            {
                base.OnDrop(e);
                DragObject dragObject = e.Data.GetData(typeof(DragObject)) as DragObject;
                if (dragObject != null && !String.IsNullOrEmpty(dragObject.Xaml))
                {
                    DesignerItem newItem = null;
                    Object content = XamlReader.Load(XmlReader.Create(new StringReader(dragObject.Xaml)));

                    if (content != null)
                    {
                        newItem = new DesignerItem();
                        newItem.Content = content;
                        newItem.Init();

                        Point position = e.GetPosition(this);

                        if (dragObject.DesiredSize.HasValue)
                        {
                            Size desiredSize = dragObject.DesiredSize.Value;
                            newItem.Width = desiredSize.Width;
                            newItem.Height = desiredSize.Height;
                             
                            DesignerCanvas.SetLeft(newItem, Math.Max(0, position.X - newItem.Width / 2));
                            DesignerCanvas.SetTop(newItem, Math.Max(0, position.Y - newItem.Height / 2));
                        }
                        else
                        {
                            DesignerCanvas.SetLeft(newItem, Math.Max(0, position.X));
                            DesignerCanvas.SetTop(newItem, Math.Max(0, position.Y));
                        }

                        Canvas.SetZIndex(newItem, this.Children.Count);
                        this.Children.Add(newItem);
                        SetConnectorDecoratorTemplate(newItem);

                        //update selection
                        this.SelectionService.SelectItem(newItem);
                        newItem.Focus();                        

                        var timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(0.5) };
                        timer.Start();
                        timer.Tick += (sender, args) =>
                        {
                            timer.Stop();
                            this.connectAutomatically();
                        };
                    }

                    e.Handled = true;
                }
            }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            Size size = new Size();

            foreach (UIElement element in this.InternalChildren)
            {
                double left = Canvas.GetLeft(element);
                double top = Canvas.GetTop(element);
                left = double.IsNaN(left) ? 0 : left;
                top = double.IsNaN(top) ? 0 : top;

                //measure desired size for each child
                element.Measure(constraint);

                Size desiredSize = element.DesiredSize;
                if (!double.IsNaN(desiredSize.Width) && !double.IsNaN(desiredSize.Height))
                {
                    size.Width = Math.Max(size.Width, left + desiredSize.Width);
                    size.Height = Math.Max(size.Height, top + desiredSize.Height);
                }
            }
            // add margin 
            size.Width += 10;
            size.Height += 10;
            return size;
        }
        private void connectAutomatically()
        {
            UIElementCollection myUIElementCollection = this.Children;
            DesignerItem source = null, sink = null;
            foreach (UIElement childElement in myUIElementCollection)
            {
                DesignerItem designerItem = childElement as DesignerItem;
                if(designerItem != null)
                {
                    if(source == null)
                    {
                        if (designerItem.IsAvailableForConnect())
                        {
                            source = designerItem;
                        }
                    }
                    else
                    {
                        if(designerItem.Current_Sink_Connection_Cnt == 0)
                        {
                            sink = designerItem;
                            break;
                        }
                    }
                }
            }
            if(source != null && sink != null)
            {
                var temp_grid = System.Windows.Media.VisualTreeHelper.GetChild(source, 0);                
                var part_connector = System.Windows.LogicalTreeHelper.FindLogicalNode(temp_grid, "PART_ConnectorDecorator");
                var source_part_connector_grid = System.Windows.Media.VisualTreeHelper.GetChild(part_connector, 0);

                temp_grid = System.Windows.Media.VisualTreeHelper.GetChild(sink, 0);
                part_connector = System.Windows.LogicalTreeHelper.FindLogicalNode(temp_grid, "PART_ConnectorDecorator");
                var sink_part_connector_grid = System.Windows.Media.VisualTreeHelper.GetChild(part_connector, 0);
                Connector sink_top_connector = System.Windows.LogicalTreeHelper.FindLogicalNode(sink_part_connector_grid, "Top") as Connector;
                Connection newConnection = null;
                switch (source.Current_Connection_Cnt)
                {
                    case 0:
                        Connector botom_connector = System.Windows.LogicalTreeHelper.FindLogicalNode(source_part_connector_grid, "Bottom") as Connector;
                        newConnection = new Connection(botom_connector, sink_top_connector);
                        break;
                    case 1:
                        botom_connector = System.Windows.LogicalTreeHelper.FindLogicalNode(source_part_connector_grid, "Bottom") as Connector;
                        Connector left_connector = System.Windows.LogicalTreeHelper.FindLogicalNode(source_part_connector_grid, "Left") as Connector;
                        Connector right_connector = System.Windows.LogicalTreeHelper.FindLogicalNode(source_part_connector_grid, "Right") as Connector;
                        if (botom_connector.Connections.Capacity >= 1)
                        {
                            botom_connector.Connections.ForEach(delegate (Connection connection)
                                {
                                    if(connection.Source == botom_connector)
                                    {
                                        connection.Source = left_connector;                                        
                                    }
                                });
                        }
                        if(source.Max_Connection_Cnt == 2)
                            newConnection = new Connection(right_connector, sink_top_connector);
                        else
                            newConnection = new Connection(botom_connector, sink_top_connector);
                        break;
                    case 2:
                        right_connector = System.Windows.LogicalTreeHelper.FindLogicalNode(source_part_connector_grid, "Right") as Connector;                       
                        newConnection = new Connection(right_connector, sink_top_connector);
                        break;
                }
                if(newConnection != null)
                {
                    Canvas.SetZIndex(newConnection, this.Children.Count);
                    this.Children.Add(newConnection);
                }

            }
        }
        private void SetConnectorDecoratorTemplate(DesignerItem item)
        {
            if (item.ApplyTemplate() && item.Content is UIElement)
            {
                ControlTemplate template = DesignerItem.GetConnectorDecoratorTemplate(item.Content as UIElement);
                Control decorator = item.Template.FindName("PART_ConnectorDecorator", item) as Control;
                if (decorator != null && template != null)
                    decorator.Template = template;
            }
        }

        
    }
}
