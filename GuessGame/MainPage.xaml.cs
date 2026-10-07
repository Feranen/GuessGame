namespace GuessGame
{
    public partial class MainPage : ContentPage
    {
        int targetGuess;
        int maxGuess = 21;

        public MainPage()
        {
            InitializeComponent();
            targetGuess = random.Next(1, maxGuess);
        }
        public Random random = new Random();
        public int counter = 0;
        
        private void OnLevelRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //Change max number and clear try amount, user guess and entry
            if (easyLevel.IsChecked)
            {
                maxGuess = 21;
            }
            else if (mediumLevel.IsChecked) {
            
                maxGuess = 51;
            } else
            {
                maxGuess = 101;
            }
            targetGuess = random.Next(1, maxGuess);
            counter = 0;
            probylabel.Text = $"Próby: {counter}";
            int userGuess = -100;
            strzalEntry.Text = "";
            podpowiedzLabel.Text = "Wpisz liczbe";
        }

        private void OnSprawdz(object? sender, EventArgs e)
        {

            int userGuess = -100;
            try {
                if (string.IsNullOrEmpty(strzalEntry.Text))
                {
                podpowiedzLabel.Text = "Wpisz liczbe";
                    return;
                }
                userGuess = int.Parse(strzalEntry.Text);
            }
            catch (Exception)
            {
                podpowiedzLabel.Text = "Wpisz poprawną liczbe";
                return;
            }

            counter++;
            probylabel.Text = $"Próby: {counter}";

            if (userGuess > targetGuess)
            {
                podpowiedzLabel.Text = "Za dużo! Celuj niżej.";
            } else if (userGuess < targetGuess)
            {
                podpowiedzLabel.Text = "Za mało! Celuj wyżej.";
            } else
            {
                podpowiedzLabel.Text = $"Trafione w {counter} próbach! Brawo!";
                strzalEntry.Text = "";
            }
        }
    }
}
