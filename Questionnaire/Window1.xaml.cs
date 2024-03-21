using System.Windows;

namespace PrincessQuestionnaire
{
    public partial class ResultsWindow : Window
    {
        public ResultsWindow(string name, string pet, string cartoon2D, string cartoon3D, string interests)
        {
            InitializeComponent();
            ResultsTextBlock.Text = $"Name: {name}\n" +
                                    $"Favourite Pet: {pet}\n" +
                                    $"Favourite 2D Cartoon: {cartoon2D}\n" +
                                    $"Favourite 3D Cartoon: {cartoon3D}\n" +
                                    $"Interests: {interests}";
        }
    }
}
