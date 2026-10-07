namespace GuessGame
{
    public partial class MainPage : ContentPage
    {
        double targetGuess;
        int maxGuess = 21;
        double userGuess = -100;

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
                userGuess = double.Parse(strzalEntry.Text);
            }
            catch (Exception)
            {
                podpowiedzLabel.Text = "Wpisz poprawną liczbe";
                return;
            }
            // Divide user guess and target guess and to guess number result should be 1
            double ratio = userGuess / targetGuess; // must be 1 to count as guessed


            counter++;
            probyLabel.Text = $"Próby: {counter}";
            if (ratio < 1)
            {
                /*🔥 Very close
🟠 Close
🟡 Warm
❄️ Cold*/
                if (ratio < 0.50)
                {
                    podpowiedzLabel.Text = "Za mało! Celuj wyżej. ❄️ Chłodno";
                     
                } else if (ratio < 0.70)
                {
                    podpowiedzLabel.Text = "Za mało! Celuj wyżej. 🟡 Ciepło";
                    
                    
                }else if (ratio < 0.80)
                {
                    podpowiedzLabel.Text = "Za mało! Celuj wyżej. 🟠 Blisko";

                }
                else if (ratio < 0.90)
                {
                    podpowiedzLabel.Text = "Za mało! Celuj wyżej. 🔥 Bardzo blisko";

                }
            } else if (ratio > 1)
            {
                if (ratio > 1.50)
                {
                    podpowiedzLabel.Text = "Za dużo! Celuj niżej. ❄️ Chłodno";
                }
                else if (ratio > 1.30)
                {
                    podpowiedzLabel.Text = "Za dużo! Celuj niżej. 🟡 Ciepło";
                }
                else if (ratio > 1.20)
                {
                    
                    podpowiedzLabel.Text = "Za dużo! Celuj niżej. 🟠 Blisko";

                }
                else if (ratio > 1)
                {
                    podpowiedzLabel.Text = "Za dużo! Celuj niżej. 🔥 Bardzo blisko";
                    

                }
            } else if (ratio == 1)
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
