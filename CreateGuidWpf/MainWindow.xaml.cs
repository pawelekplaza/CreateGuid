using System;
using System.Windows;
using System.Windows.Controls;

namespace CreateGuidWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _withPauses = true;
        private bool _uppercase = true;

        public MainWindow()
        {
            InitializeComponent();
            GenerateGuid();
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(GuidTextBlock.Text);
            GenerateGuid();
        }

        private void GenerateGuid()
        {
            GuidTextBlock.Text = Guid.NewGuid().ToString();

            if (!_withPauses)
                GuidTextBlock.Text = GuidTextBlock.Text.Replace("-", "");

            if (_uppercase)
                GuidTextBlock.Text = GuidTextBlock.Text.ToUpper();
        }

        private void withPausesCheckedChanged(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            if (checkbox == null)
                return;

            if (!checkbox.IsChecked.HasValue)
                return;

            _withPauses = checkbox.IsChecked.Value;
            GenerateGuid();
        }

        private void uppercaseCheckedChanged(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            if (checkbox == null)
                return;

            if (!checkbox.IsChecked.HasValue)
                return;

            _uppercase = checkbox.IsChecked.Value;
            GenerateGuid();
        }
    }
}
