namespace GuessGame
{
    public partial class MainPage : ContentPage
    {
        int targetGuess;
        int maxGuess = 21;
        int userGuess = -100;

        public MainPage()
        {
            InitializeComponent();
            targetGuess = random.Next(1, maxGuess);
        }
        public Random random = new Random();
        public int counter = 0;
        int record = 1000;
        
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
            probyLabel.Text = $"Próby: {counter}";
            userGuess = -100;
            strzalEntry.Text = "";
            podpowiedzLabel.Text = "Wpisz liczbe";
        }
        private void OnFromStart(object sender, EventArgs e)
        {
            //Clear try amount, user guess and entry
            targetGuess = random.Next(1, maxGuess);
            counter = 0;
            probyLabel.Text = $"Próby: {counter}";
            userGuess = -100;
            strzalEntry.Text = "";
            podpowiedzLabel.Text = "Wpisz liczbe";
        }

        private void OnSprawdz(object? sender, EventArgs e)
        {

            userGuess = -100;
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
            probyLabel.Text = $"Próby: {counter}";
            if (userGuess > targetGuess)
            {
                podpowiedzLabel.Text = "Za dużo! Celuj niżej.";
            } else if (userGuess < targetGuess)
            {
                podpowiedzLabel.Text = "Za mało! Celuj wyżej.";
            } else
            {
                if (record > counter)
                {
                    record = counter;
                    
                    recordLabel.Text = $"Rekord: {record}";
                    
                }
                strzalEntry.Text = "";
                
                podpowiedzLabel.Text = $"Trafione w {counter} próbach! Brawo!";
                counter = 0;

            }

            
        }
    }
}
