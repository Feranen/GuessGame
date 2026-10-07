namespace GuessGame
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        int targetGuess;

        public MainPage()
        {
            InitializeComponent();
            targetGuess = random.Next(1, 21);
        }
        public Random random = new Random();
        public int counter = 0;
        

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

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
