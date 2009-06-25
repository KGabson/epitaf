using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

using Liquid;

namespace SilverlightControlsDemo
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            fileTree.Selected = fileTree.Nodes[0];
            InitMagnifier();

            _timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            _timer.Tick += new EventHandler(Tick);
            _timer.Start();
        }
        
        #region Popup Handling

        private void Dialog_Minimizing(object sender, DialogEventArgs e)
        {
            Dialog dialog = (Dialog)sender;

            // Work out the position where the dialog should be minimized to
            e.Parameter = dockPanel.TransformToVisual(RootVisual).Transform(new Point(0, -dialog.MinimizedSize.Height));
        }

        private void Dialog_Minimized(object sender, DialogEventArgs e)
        {
            Dialog dialog = (Dialog)sender;

            if (dialogCanvas.Children.Contains(dialog))
            {
                dialogCanvas.Children.Remove(dialog);
                dockPanel.Children.Insert(0, dialog);
            }
        }

        private void Dialog_Restoring(object sender, DialogEventArgs e)
        {
            Dialog dialog = (Dialog)sender;

            if (dialog.SizeState == DialogSizeState.Minimized)
            {
                dockPanel.Children.Remove((Dialog)sender);
                dialogCanvas.Children.Add((Dialog)sender);
            }
        }

        #endregion

        #region Button Clicking

        private void TreeButton_Click(object sender, RoutedEventArgs e)
        {
            treeNavDialog.ShowAsModal();
        }

        private void RichTextBoxButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBoxPopup.Show();
        }

        private void ViewerButton_Click(object sender, RoutedEventArgs e)
        {
            viewerPopup.Show();
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            itemViewerPopup.Show();
        }

        private void FieldSetButton_Click(object sender, RoutedEventArgs e)
        {
            fieldsetPopup.Show();
        }

        private void RollerBlindButton_Click(object sender, RoutedEventArgs e)
        {
            rollerBlindPopup.Show();
        }

        private void ProgressButton_Click(object sender, RoutedEventArgs e)
        {
            progressPopup.Show();
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            menuPopup.Show();
        }

        private void scrollerButton_Click(object sender, RoutedEventArgs e)
        {
            scrollerPopup.Show();
        }

        private void dialogButton_Click(object sender, RoutedEventArgs e)
        {
            dialogPopup.Show();
        }

        private void magnifierButton_Click(object sender, RoutedEventArgs e)
        {
            magnifierPopup.Show();
        }

        #endregion

        #region Background Light

        private Point _whiteOrigin = new Point(0.9, 0.4);
        private Point _whiteDir = new Point(-0.005, -0.005);

        private void BackgroundTick()
        {
            UpdateLight(backgroundBrush, ref _whiteOrigin, ref _whiteDir);
        }

        private void UpdateLight(RadialGradientBrush brush, ref Point origin, ref Point dir)
        {
            origin.X += dir.X;
            if (origin.X < 0)
            {
                origin.X = 0;
                dir.X = -dir.X;
            }
            else if (origin.X > 1)
            {
                origin.X = 1;
                dir.X = -dir.X;
            }

            origin.Y += dir.Y;
            if (origin.Y < 0)
            {
                origin.Y = 0;
                dir.Y = -dir.Y;
            }
            else if (origin.Y > 1)
            {
                origin.Y = 1;
                dir.Y = -dir.Y;
            }

            brush.SetValue(RadialGradientBrush.GradientOriginProperty, origin);
        }

        #endregion

        #region Progress Bar Popup

        private DispatcherTimer _timer = new DispatcherTimer();

        protected void Tick(object sender, EventArgs e)
        {
            progress.Complete += 1;
            if (progress.Complete >= 100)
            {
                progress.Complete = 0;
            }
            progress.Text = progress.Complete.ToString() + "% Complete";

            BackgroundTick();
        }

        #endregion

        #region RichTextBox Popup

        #region Private Properties

        private SolidColorBrush _buttonFillStyleNotApplied = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        private SolidColorBrush _buttonFillStyleApplied = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        private bool _ignoreFormattingChanges = false;

        #endregion

        #region Formatting Handling

        private void UpdateFormattingControls()
        {
            makeBold.Background = _buttonFillStyleNotApplied;
            makeItalic.Background = _buttonFillStyleNotApplied;
            makeUnderline.Background = _buttonFillStyleNotApplied;
            makeLeft.Background = _buttonFillStyleNotApplied;
            makeCenter.Background = _buttonFillStyleNotApplied;
            makeRight.Background = _buttonFillStyleNotApplied;
            bulletList.Background = _buttonFillStyleNotApplied;
            numberList.Background = _buttonFillStyleNotApplied;

            if (richTextBox.SelectionStyle.Weight == FontWeights.Bold)
            {
                makeBold.Background = _buttonFillStyleApplied;
            }

            if (richTextBox.SelectionStyle.Style == FontStyles.Italic)
            {
                makeItalic.Background = _buttonFillStyleApplied;
            }

            if (richTextBox.SelectionStyle.Decorations == TextDecorations.Underline)
            {
                makeUnderline.Background = _buttonFillStyleApplied;
            }

            if (richTextBox.SelectionAlignment == HorizontalAlignment.Left)
            {
                makeLeft.Background = _buttonFillStyleApplied;
            }
            else if (richTextBox.SelectionAlignment == HorizontalAlignment.Center)
            {
                makeCenter.Background = _buttonFillStyleApplied;
            }
            else if (richTextBox.SelectionAlignment == HorizontalAlignment.Right)
            {
                makeRight.Background = _buttonFillStyleApplied;
            }

            if (richTextBox.SelectionListType != null)
            {
                if (richTextBox.SelectionListType.Type == BulletType.Bullet)
                {
                    bulletList.Background = _buttonFillStyleApplied;
                }
                else if (richTextBox.SelectionListType.Type == BulletType.Number)
                {
                    numberList.Background = _buttonFillStyleApplied;
                }
            }

            SetSelected(selectFontFamily, richTextBox.SelectionStyle.Family);
            SetSelected(selectFontSize, richTextBox.SelectionStyle.Size.ToString());
        }

        #endregion

        #region Formatting Events

        public void RichTextBox_SelectionChanged(object sender, RichTextBoxEventArgs e)
        {
            UpdateFormattingControls();
        }

        private void MakeBold_Click(object sender, RoutedEventArgs e)
        {
            Formatting format = (makeBold.Background == _buttonFillStyleNotApplied ? Formatting.Bold : Formatting.RemoveBold);

            ExecuteFormatting(format, null);
        }

        private void MakeItalic_Click(object sender, RoutedEventArgs e)
        {
            Formatting format = (makeItalic.Background == _buttonFillStyleNotApplied ? Formatting.Italic : Formatting.RemoveItalic);

            ExecuteFormatting(format, null);
        }

        private void MakeUnderline_Click(object sender, RoutedEventArgs e)
        {
            Formatting format = (makeUnderline.Background == _buttonFillStyleNotApplied ? Formatting.Underline : Formatting.RemoveUnderline);

            ExecuteFormatting(format, null);
        }

        private void MakeLeft_Click(object sender, RoutedEventArgs e)
        {
            ExecuteFormatting(Formatting.AlignLeft, null);
        }

        private void MakeCenter_Click(object sender, RoutedEventArgs e)
        {
            ExecuteFormatting(Formatting.AlignCenter, null);
        }

        private void MakeRight_Click(object sender, RoutedEventArgs e)
        {
            ExecuteFormatting(Formatting.AlignRight, null);
        }

        private void Indent_Click(object sender, RoutedEventArgs e)
        {
            ExecuteFormatting(Formatting.Indent, null);
        }

        private void Outdent_Click(object sender, RoutedEventArgs e)
        {
            ExecuteFormatting(Formatting.Outdent, null);
        }

        private void BulletList_Click(object sender, RoutedEventArgs e)
        {
            Formatting format = (bulletList.Background == _buttonFillStyleNotApplied ? Formatting.BulletList : Formatting.RemoveBullet);

            ExecuteFormatting(format, null);
        }

        private void NumberList_Click(object sender, RoutedEventArgs e)
        {
            Formatting format = (numberList.Background == _buttonFillStyleNotApplied ? Formatting.NumberList : Formatting.RemoveNumber);

            ExecuteFormatting(format, null);
        }

        private void SelectFontFamily_ItemSelected(object sender, EventArgs e)
        {
            if (selectFontFamily != null)
            {
                ExecuteFormatting(Formatting.FontFamily, ((ComboBoxItem)selectFontFamily.SelectedItem).Content.ToString());
            }
        }

        private void SelectFontSize_ItemSelected(object sender, EventArgs e)
        {
            if (selectFontSize != null)
            {
                ExecuteFormatting(Formatting.FontSize, double.Parse(((ComboBoxItem)selectFontSize.SelectedItem).Content.ToString()));
            }
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Cut();
            richTextBox.ReturnFocus();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Copy();
            richTextBox.ReturnFocus();
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Paste();
            richTextBox.ReturnFocus();
        }

        private void Painter_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Painter();
            richTextBox.ReturnFocus();
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Undo();
            richTextBox.ReturnFocus();
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Redo();
            richTextBox.ReturnFocus();
        }

        private void ExecuteFormatting(Formatting format, object param)
        {
            if (!_ignoreFormattingChanges)
            {
                richTextBox.ApplyFormatting(format, param);
                richTextBox.ReturnFocus();
            }
        }

        private void SetSelected(ComboBox combo, string value)
        {
            if (value != null)
            {
                _ignoreFormattingChanges = true;

                foreach (ComboBoxItem item in combo.Items)
                {
                    if (item.Content.ToString().ToLower() == value.ToLower())
                    {
                        combo.SelectedItem = item;
                        break;
                    }
                }

                _ignoreFormattingChanges = false;
            }
        }

        #endregion

        #region Menu Selection

        private void mainMenu_ItemSelected(object sender, MenuEventArgs e)
        {
            switch (e.Tag.ToString())
            {
                case "new":
                    richTextBox.Text = "";
                    break;
                case "save":
                    // TODO: Save functionality
                    break;
                case "exit":
                    richTextBoxPopup.Close();
                    break;
                case "cut":
                    richTextBox.Cut();
                    break;
                case "copy":
                    richTextBox.Copy();
                    break;
                case "paste":
                    richTextBox.Paste();
                    break;
                case "undo":
                    richTextBox.Undo();
                    break;
                case "redo":
                    richTextBox.Redo();
                    break;
                case "delete":
                    richTextBox.Delete(false);
                    break;
                case "selectAll":
                    richTextBox.SelectAll();
                    break;
                case "find":
                    // TODO: A find dialog
                    break;
                case "left":
                    richTextBox.ApplyFormatting(Formatting.AlignLeft, null);
                    break;
                case "center":
                    richTextBox.ApplyFormatting(Formatting.AlignCenter, null);
                    break;
                case "right":
                    richTextBox.ApplyFormatting(Formatting.AlignRight, null);
                    break;
                case "bold":
                    richTextBox.ApplyFormatting(Formatting.Bold, null);
                    break;
                case "italic":
                    richTextBox.ApplyFormatting(Formatting.Italic, null);
                    break;
                case "underline":
                    richTextBox.ApplyFormatting(Formatting.Underline, null);
                    break;
                case "subscript":
                    richTextBox.ApplyFormatting(Formatting.SubScript, null);
                    break;
                case "superscript":
                    richTextBox.ApplyFormatting(Formatting.SuperScript, null);
                    break;
                case "numberedList":
                    richTextBox.ApplyFormatting(Formatting.NumberList, null);
                    break;
                case "bulletedList":
                    richTextBox.ApplyFormatting(Formatting.BulletList, null);
                    break;
                default:
                    break;
            }

            richTextBox.ReturnFocus();
        }

        #endregion

        #endregion

        #region Text Roller Blind Popup

        private void CurrentStatus_Click(object sender, RoutedEventArgs e)
        {
            currentStatus.Value = ((RadioButton)sender).Content.ToString();
        }

        private void Preference_Click(object sender, RoutedEventArgs e)
        {
            preferred.Value = ((RadioButton)sender).Content.ToString();
        }

        private void Experience_Click(object sender, RoutedEventArgs e)
        {
            exp.Value = ((RadioButton)sender).Content.ToString();
        }

        #endregion

        #region TreeView Popup Handling

        #region Private Properties

        private Node _selected = null;

        #endregion

        private void PropertiesButton_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = (treeNavDialog.ExpandedState == Dialog.State.Normal ? "<< Properties" : "Properties >>");

            PopulateProperties();
            treeNavDialog.Expand();
        }

        private void PopulateProperties()
        {
            pageTitleTextBox.Text = _selected.Title;
            templateDropDownList.SelectedIndex = 0;
            startDatePicker.SelectedDate = DateTime.Now.AddHours(3);
            endDatePicker.SelectedDate = DateTime.Now.AddMonths(1).AddHours(3);
            tagsTextArea.Text = "silverlight, test, page, content, management, free";
        }

        private void Tree_ButtonClick(object sender, RoutedEventArgs e)
        {
            treeNavDialog.Show();
        }

        private void TreeNavDialog_NodeClick(object sender, EventArgs e)
        {
            UpdatePageTitle();
            _selected = (Node)sender;

            propertiesButton.IsEnabled = true;

            PopulateProperties();
        }

        private void UpdatePageTitle()
        {
            if (_selected != null)
            {
                _selected.Title = pageTitleTextBox.Text;
            }
        }

        #endregion

        #region ItemViewer Handling

        private void fileTree_NodeClick(object sender, TreeEventArgs e)
        {
            Node n = (Node)sender;
            List<ItemViewerItem> toAdd = new List<ItemViewerItem>();

            fileItems.Clear();

            switch (n.ID)
            {
                case "0":
                    toAdd.Add(CreateItem("xls", "Expenses.xls", "456.3KB"));
                    toAdd.Add(CreateItem("pdf", "Locations.pdf", "156.2KB"));
                    toAdd.Add(CreateItem("doc", "Readthis.doc", "98.1KB"));
                    toAdd.Add(CreateItem("xls", "Spreadsheet.xls", "56.5KB"));
                    toAdd.Add(CreateItem("pdf", "Targets.pdf", "90.8KB"));
                    break;
                case "1":
                    toAdd.Add(CreateItem("zip", "Silverlight-2.msi", "4.56MB"));
                    break;
                case "2":
                    toAdd.Add(CreateItem("mp3", "Cant Touch this.mp3", "2.45MB"));
                    toAdd.Add(CreateItem("mp3", "Rock Is Dead.mp3", "3.28MB"));
                    toAdd.Add(CreateItem("mp3", "Wake Up.mp3", "3.08MB"));
                    break;
                case "3":
                    toAdd.Add(CreateItem("jpg", "Beach.jpg", "3.67MB"));
                    toAdd.Add(CreateItem("jpg", "Boat.jpg", "3.50MB"));
                    toAdd.Add(CreateItem("jpg", "Jungle.jpg", "3.56MB"));
                    toAdd.Add(CreateItem("jpg", "Pool.jpg", "3.23MB"));
                    toAdd.Add(CreateItem("jpg", "Reef.jpg", "3.98MB"));
                    break;
                case "4":
                    toAdd.Add(CreateItem("unknown", "info.dat", "926.5KB"));
                    break;
                case "5":
                    toAdd.Add(CreateItem("avi", "Diving.avi", "35.2MB"));
                    toAdd.Add(CreateItem("avi", "Driving.avi", "24.1MB"));
                    toAdd.Add(CreateItem("avi", "Life.avi", "45.6MB"));
                    toAdd.Add(CreateItem("avi", "Test.avi", "6.9MB"));
                    break;
            }

            fileItems.Add(toAdd);
        }

        private FileItem CreateItem(string type, string filename, string desc)
        {
            return new FileItem() { Icon = "images/large/" + type + ".png", Text = filename, OtherText = desc };
        }

        private void fileItems_SlowDoubleClick(object sender, EventArgs e)
        {
            fileItems.Selected.IsEditable = true;
        }

        private void fileItems_EditingFinished(object sender, ItemViewerEventArgs e)
        {
            e.Cancel = false;
        }

        #endregion

        #region Magnifier Handling

        private void InitMagnifier()
        {
            magnifier.CornerRadius = 45;
            magnifierCover.Fill = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            targetHorizontal.Visibility = Visibility.Collapsed;
            targetVertical.Visibility = Visibility.Collapsed;
            UpdateMagnifier();
        }

        private void magnifierSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (magnifierSelect == null)
            {
                return;
            }

            InitMagnifier();

            switch (((ComboBoxItem)magnifierSelect.SelectedItem).Tag.ToString())
            {
                case "glass":
                    break;
                case "night":
                    magnifierCover.Fill = new SolidColorBrush(Color.FromArgb(160, 0, 255, 0));
                    targetHorizontal.Visibility = Visibility.Visible;
                    targetVertical.Visibility = Visibility.Visible;
                    break;
                case "square":
                    magnifier.CornerRadius = 5;
                    magnifierCover.Fill = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
                    break;
            }
            UpdateMagnifier();
        }

        private void magnifierZoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (magnifierZoom == null)
            {
                return;
            }

            magnifier.Zoom = double.Parse(((ComboBoxItem)magnifierZoom.SelectedItem).Tag.ToString());
            UpdateMagnifier();
        }

        private void UpdateMagnifier()
        {
            magnifierCover.RadiusX = magnifier.CornerRadius * magnifier.Zoom;
            magnifierCover.RadiusY = magnifier.CornerRadius * magnifier.Zoom;
            targetHorizontal.Height = magnifier.Size * magnifier.Zoom;
            targetVertical.Width = magnifier.Size * magnifier.Zoom;
        }

        #endregion
    }
}
