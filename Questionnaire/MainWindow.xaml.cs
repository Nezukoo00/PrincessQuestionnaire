using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;

namespace PrincessQuestionnaire
{
    public partial class MainWindow : Window
    {
        private const string DefaultNameText = "Введите имя";
        private const string DefaultInterestsText = "Введите свои интересы";

        public MainWindow()
        {
            InitializeComponent();
            SetDefaultText(NameTextBox, DefaultNameText);
            SetDefaultText(InterestsTextBox, DefaultInterestsText);
        }
        private void SetDefaultText(TextBox textBox, string defaultText)
        {
            textBox.Text = defaultText;
            textBox.Foreground = Brushes.Gray;
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == DefaultNameText || textBox.Text == DefaultInterestsText)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                SetDefaultText(textBox, textBox == NameTextBox ? DefaultNameText : DefaultInterestsText);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            string name = NameTextBox.Text != DefaultNameText ? NameTextBox.Text : string.Empty;
            string favouritePet = PetsPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true)?.Content.ToString();
            string favouriteCartoon2D = Cartoons2DPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true)?.Content.ToString();
            string favouriteCartoon3D = Cartoons3DPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true)?.Content.ToString();
            string interests = InterestsTextBox.Text != DefaultInterestsText ? InterestsTextBox.Text : string.Empty;

            ResultsWindow resultsWindow = new ResultsWindow(name, favouritePet, favouriteCartoon2D, favouriteCartoon3D, interests);
            resultsWindow.Show();
        }
    }
}
